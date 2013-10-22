﻿using MonoDevelop.Core;
using MonoDevelop.Projects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using MonoDevelop.D.Building;
using System.Text.RegularExpressions;
using MonoDevelop.Ide.TypeSystem;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.D.Projects.Dub
{
	/// <summary>
	/// A dub package.
	/// </summary>
	public class DubProject : AbstractDProject
	{
		#region Properties
		List<string> authors = new List<string>();
		/// <summary>
		/// Project-wide cross-config build settings.
		/// </summary>
		public readonly DubBuildSettings CommonBuildSettings = new DubBuildSettings();

		public readonly DubReferencesCollection DubReferences;
		public override DProjectReferenceCollection References {get {return DubReferences;}} 

		public override string Name { get; set; } // override because the name is normally derived from the file name -- package.json is not the project's file name!
		public override FilePath FileName { get; set; }
		public string Homepage;
		public string Copyright;
		public List<string> Authors { get { return authors; } }

		public List<DubBuildSettings> GetBuildSettings(ConfigurationSelector sel)
		{
			var settingsToScan = new List<DubBuildSettings>(4);
			settingsToScan.Add(CommonBuildSettings);

			DubProjectConfiguration pcfg;
			if (sel == null || (pcfg = GetConfiguration(sel) as DubProjectConfiguration) == null)
				foreach (DubProjectConfiguration cfg in Configurations)
					settingsToScan.Add(cfg.BuildSettings);
			else
				settingsToScan.Add(pcfg.BuildSettings);

			return settingsToScan;
		}

		public IEnumerable<string> GetAdditionalDubIncludes(ConfigurationSelector sel = null)
		{
			foreach (var settings in GetBuildSettings(sel))
			{
				List<DubBuildSetting> l;
				if(settings.TryGetValue(DubBuildSettings.ImportPathsProperty, out l))
					for (int i = l.Count - 1; i >= 0; i--) // Ignore architecture/os/compiler restrictions for now
						for (int j = l[i].Values.Length - 1; j >= 0; j--)
							yield return (l[i].Values[j]);
			}
		}

		protected override List<FilePath> OnGetItemFiles(bool includeReferencedFiles)
		{
			var files = new List<FilePath>();

			foreach(var dir in GetSourcePaths((ConfigurationSelector)null))
				foreach (var f in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
					files.Add(new FilePath(f));

			return files;
		}

		public override IEnumerable<string> GetSourcePaths(ConfigurationSelector sel)
		{
			List<DubBuildSetting> l;
			string d;
			bool returnedOneItem = false;
			foreach (var sett in GetBuildSettings(sel)) {
				if (sett.TryGetValue (DubBuildSettings.SourcePathsProperty, out l))
					foreach (var setting in l) {
						foreach(var directory in setting.Values){
							d = directory;
							if (!Path.IsPathRooted (d))
								d = BaseDirectory.Combine (d).ToString ();

							// Ignore os/arch/version constraints for now

							if (!Directory.Exists (d))
								continue;

							yield return d;
							returnedOneItem = true;
						}
					}
			}

			if (returnedOneItem)
				yield break;

			d = BaseDirectory.Combine("source").ToString();
			if (Directory.Exists(d))
				yield return d;

			d = BaseDirectory.Combine("src").ToString();
			if (Directory.Exists(d))
				yield return d;
		}

		public override string ToString ()
		{
			return string.Format ("[DubProject: Name={0}]", Name);
		}
		#endregion

		#region Constructor & Init
		public DubProject()
		{
			DubReferences = new DubReferencesCollection (this);
		}
		#endregion

		#region Serialize & Deserialize
		internal void BeginLoad()
		{
			OnBeginLoad ();
		}

		internal void EndLoad()
		{
			OnEndLoad ();
		}

		public bool TryPopulateProperty(string propName, JsonReader j)
		{
			switch (propName)
			{
				case "name":
					Name = j.ReadAsString();
					break;
				case "description":
					Description = j.ReadAsString();
					break;
				case "copyright":
					Copyright = j.ReadAsString();
					break;
				case "homepage":
					Homepage = j.ReadAsString();
					break;
				case "authors":
					if (!j.Read() || j.TokenType != JsonToken.StartArray)
						throw new JsonReaderException("Expected [ when parsing Authors");
					authors.Clear();
					while (j.Read() && j.TokenType != JsonToken.EndArray)
						if (j.TokenType == JsonToken.String)
							authors.Add(j.Value as string);
					break;
				case "dependencies":
					if (!j.Read () || j.TokenType != JsonToken.StartObject)
						throw new JsonReaderException ("Expected { when parsing Authors");

					DubReferences.DeserializeDubPrjDependencies(j);
					break;
				case "configurations":
					if (!j.Read() || j.TokenType != JsonToken.StartArray)
						throw new JsonReaderException("Expected [ when parsing Configurations");
					if(ParentSolution != null)
						ParentSolution.Configurations.Clear();
					Configurations.Clear();

					while (j.Read() && j.TokenType != JsonToken.EndArray)
						AddProjectAndSolutionConfiguration(DubProjectConfiguration.DeserializeFromPackageJson(j));
					break;

				default:
					return CommonBuildSettings.TryDeserializeBuildSetting(j);
			}

			return true;
		}

		internal void AddProjectAndSolutionConfiguration(DubProjectConfiguration cfg)
		{
			if (ParentSolution != null)
			{
				var slnCfg = new SolutionConfiguration(cfg.Name, cfg.Platform);
				ParentSolution.Configurations.Add(slnCfg);
				slnCfg.AddItem(this).Build = true;
			}
			Configurations.Add(cfg);

			if (Configurations.Count == 1)
				DefaultConfigurationId = cfg.Id;
		}

		protected override void OnEndLoad ()
		{
			DubReferences.FireUpdate ();
			base.OnEndLoad ();
		}
		#endregion

		#region Building
		public bool BuildSettingMatchesConfiguration(DubBuildSetting sett, ConfigurationSelector config)
		{
			return true;
		}

		public override FilePath GetOutputFileName (ConfigurationSelector configuration)
		{
			var cfg = GetConfiguration (configuration) as DubProjectConfiguration;

			string targetPath = null, targetName = null, targetType = null;
			CommonBuildSettings.TryGetTargetFileProperties (this, configuration, ref targetType, ref targetName, ref targetPath);
			cfg.BuildSettings.TryGetTargetFileProperties (this, configuration, ref targetType, ref targetName, ref targetPath);

			if (string.IsNullOrWhiteSpace (targetPath))
				targetPath = BaseDirectory.ToString ();
			else if (!Path.IsPathRooted (targetPath))
				targetPath = BaseDirectory.Combine (targetPath).ToString ();

			if (string.IsNullOrWhiteSpace (targetName))
				targetName = Name;

			if(string.IsNullOrWhiteSpace(targetType) ||
				(targetType = targetType.ToLowerInvariant()) == "executable" ||
				targetType == "autodetect")
			{
				if(OS.IsWindows)
					targetName += ".exe";
			}
			else
			{
				//TODO
			}


			return Path.Combine(targetPath, targetName);
		}

		protected override void PopulateOutputFileList (List<FilePath> list, ConfigurationSelector configuration)
		{
			base.PopulateOutputFileList (list, configuration);
		}

		protected override BuildResult DoBuild(IProgressMonitor monitor, ConfigurationSelector configuration)
		{
			return DubBuilder.BuildProject(this, monitor, configuration);			
		}

		protected override bool OnGetCanExecute(ExecutionContext context, ConfigurationSelector configuration)
		{
			string targetPath = null, targetName = null, targetType = null;
			CommonBuildSettings.TryGetTargetFileProperties (this, configuration, ref targetType, ref targetName, ref targetPath);
			(GetConfiguration(configuration) as DubProjectConfiguration).BuildSettings
				.TryGetTargetFileProperties (this, configuration, ref targetType, ref targetName, ref targetPath);

			if (targetType == "autodetect" || string.IsNullOrWhiteSpace (targetType)) {
				if (string.IsNullOrEmpty (targetName))
					return true;

				var ext = Path.GetExtension(targetName);
				if(ext != null)
					switch (ext.ToLowerInvariant()) {
						case ".dylib":
						case ".so":
						case ".a":
							return false;
						case ".exe":
						case null:
						default:
							return true;
				}
			}

			return targetType.ToLowerInvariant() == "executable";
		}

		protected override void DoExecute(IProgressMonitor monitor, ExecutionContext context, ConfigurationSelector configuration)
		{
			DubBuilder.ExecuteProject(this,monitor, context, configuration);
		}

		public override SolutionItemConfiguration CreateConfiguration (string name)
		{
			return new DubProjectConfiguration { Name = name };
		}

		protected override void DoClean (IProgressMonitor monitor, ConfigurationSelector configuration)
		{
			base.DoClean (monitor, configuration);
		}
		#endregion
	}
}
