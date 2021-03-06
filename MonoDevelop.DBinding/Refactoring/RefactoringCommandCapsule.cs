//
// RefactoringCommandCapsule.cs
//
// Author:
//       Alexander Bothe <info@alexanderbothe.com>
//
// Copyright (c) 2013 Alexander Bothe
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using D_Parser.Resolver;
using D_Parser.Resolver.TypeResolution;
using D_Parser.Dom;
using MonoDevelop.Ide;
using D_Parser.Refactoring;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Core;
using MonoDevelop.Ide.FindInFiles;
using System.Threading;
using MonoDevelop.D.Resolver;
namespace MonoDevelop.D.Refactoring
{
	class RefactoringCommandCapsule
	{
		public ResolutionContext ctxt;
		public D_Parser.Completion.IEditorData ed;
		public AbstractType[] lastResults;
		public DResolver.NodeResolutionAttempt resultResolutionAttempt;

		public bool Update(Document doc = null)
		{
			lastResults = DResolverWrapper.ResolveHoveredCodeLoosely(out ctxt, out ed, out resultResolutionAttempt, doc);

			return lastResults != null && lastResults.Length > 0;
		}

		AbstractType GetResult()
		{
			if (lastResults.Length == 1)
				return lastResults [0];

			return ImportSymbolSelectionDlg.Show (lastResults, GettextCatalog.GetString("Select symbol"), 
				(object o) => o is DSymbol ? (o as DSymbol).Definition.ToString(false, true) : o.ToString());
		}

		public void GotoDeclaration()
		{
			AbstractType res = GetResult();
			if (res != null)
				GotoDeclaration(res);
		}

		internal static void GotoDeclaration(AbstractType lastResult)
		{
			GotoDeclaration (DResolver.GetResultMember (lastResult, true));
		}

		public static void GotoDeclaration(INode n)
		{
			if (n != null && n.NodeRoot is DModule)
				IdeApp.Workbench.OpenDocument(
					((DModule)n.NodeRoot).FileName,
					n.NameLocation.Line,
					n.NameLocation.Column);
		}

		public void FindReferences(bool allOverloads = false)
		{
			AbstractType res = GetResult();
			INode n;
			if (res != null && (n = DResolver.GetResultMember(res, true)) != null)
				ReferenceFinding.StartReferenceSearchAsync(n, allOverloads);
		}

		public void FindDerivedClasses()
		{
			ThreadPool.QueueUserWorkItem(FindDerivedClassesThread);
		}

		void FindDerivedClassesThread(object s)
		{
			var monitor = IdeApp.Workbench.ProgressMonitors.GetSearchProgressMonitor(true, true);
			monitor.BeginStepTask (GettextCatalog.GetString ("Find Derived Classes"), lastResults.Length,1);

			foreach (var t in lastResults)
			{
				var t_ = DResolver.StripMemberSymbols(t);
				if (!(t_ is ClassType || t_ is InterfaceType)) {
					monitor.Step (1);
					continue;
				}

				foreach (var res in ClassInterfaceDerivativeFinder.SearchForClassDerivatives(t_ as TemplateIntermediateType, ctxt)) {
					var dc = res.Definition;
					var file = (dc.NodeRoot as DModule).FileName;
					var targetDoc = TextFileProvider.Instance.GetTextEditorData(new FilePath(file));

					monitor.ReportResult(new SearchResult(new FileProvider(file, IdeApp.Workspace.GetProjectContainingFile(file)),
						targetDoc.LocationToOffset(dc.NameLocation.Line,dc.NameLocation.Column),dc.Name.Length));
				}
				monitor.Step (1);
			}

			monitor.EndTask();
			monitor.Dispose ();
		}

		public void RenameSymbol()
		{
			AbstractType res = GetResult();
			INode n;
			if (res != null && (n = DResolver.GetResultMember(res, true)) != null &&
				DRenameRefactoring.CanRenameNode(n))
				new DRenameHandler().Start(n);
		}

		public void TryImportMissingSymbol()
		{
			var t = GetResult ();
			if (t is DSymbol)
				ImportStmtCreation.GenerateImportStatementForNode ((t as DSymbol).Definition, ed, (loc, s) => {
					var doc = IdeApp.Workbench.ActiveDocument.Editor;
					doc.Insert (doc.LocationToOffset (loc.Line, loc.Column), s);
				});
		}
	}
}

