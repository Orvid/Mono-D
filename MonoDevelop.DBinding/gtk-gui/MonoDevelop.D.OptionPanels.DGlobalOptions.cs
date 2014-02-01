
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.D.OptionPanels
{
	public partial class DGlobalOptions
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.Table table1;
		private global::Gtk.CheckButton check_EnableDiffbasedColoring;
		private global::Gtk.CheckButton check_EnableMixinAnalysis;
		private global::Gtk.CheckButton check_EnableSuggestionMode;
		private global::Gtk.CheckButton check_EnableUFCSCompletion;
		private global::Gtk.CheckButton check_GrayOutNonPublic;
		private global::Gtk.CheckButton check_HideDeprecatedItems;
		private global::Gtk.CheckButton check_IndentInsteadFormatCode;
		private global::Gtk.CheckButton check_ShowFunctionParams;
		private global::Gtk.CheckButton check_ShowFunctionVariables;
		private global::Gtk.CheckButton check_ShowTypes;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label5;
		private global::Gtk.ComboBox combo_ExpansionBehaviour;
		private global::Gtk.Label label2;
		private global::Gtk.Label label3;
		private global::Gtk.Label label4;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.D.OptionPanels.DGlobalOptions
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.D.OptionPanels.DGlobalOptions";
			// Container child MonoDevelop.D.OptionPanels.DGlobalOptions.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(15)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.check_EnableDiffbasedColoring = new global::Gtk.CheckButton ();
			global::Gtk.Tooltips w1 = new Gtk.Tooltips ();
			w1.SetTip (this.check_EnableDiffbasedColoring, "If enabled, deadlocks might occur if mixins are used too often", "If enabled, deadlocks might occur if mixins are used too often");
			this.check_EnableDiffbasedColoring.CanFocus = true;
			this.check_EnableDiffbasedColoring.Name = "check_EnableDiffbasedColoring";
			this.check_EnableDiffbasedColoring.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Enable diff-based syntax highlighting (shortcut: Ctrl+Alt+K)");
			this.check_EnableDiffbasedColoring.DrawIndicator = true;
			this.check_EnableDiffbasedColoring.UseUnderline = true;
			this.table1.Add (this.check_EnableDiffbasedColoring);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_EnableDiffbasedColoring]));
			w2.TopAttach = ((uint)(5));
			w2.BottomAttach = ((uint)(6));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_EnableMixinAnalysis = new global::Gtk.CheckButton ();
			w1.SetTip (this.check_EnableMixinAnalysis, "If enabled, deadlocks might occur if mixins are used too often", "If enabled, deadlocks might occur if mixins are used too often");
			this.check_EnableMixinAnalysis.CanFocus = true;
			this.check_EnableMixinAnalysis.Name = "check_EnableMixinAnalysis";
			this.check_EnableMixinAnalysis.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Enable Mixin & Template Mixin Analysis");
			this.check_EnableMixinAnalysis.DrawIndicator = true;
			this.check_EnableMixinAnalysis.UseUnderline = true;
			this.table1.Add (this.check_EnableMixinAnalysis);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_EnableMixinAnalysis]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_EnableSuggestionMode = new global::Gtk.CheckButton ();
			w1.SetTip (this.check_EnableSuggestionMode, "If true, the selected text in the completion box will not be inserted into the co" +
			"de unless the <Return> key has been pressed.", "If true, the selected text in the completion box will not be inserted into the co" +
			"de unless the <Return> key has been pressed.");
			this.check_EnableSuggestionMode.CanFocus = true;
			this.check_EnableSuggestionMode.Name = "check_EnableSuggestionMode";
			this.check_EnableSuggestionMode.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Enable suggestive completion mode");
			this.check_EnableSuggestionMode.DrawIndicator = true;
			this.check_EnableSuggestionMode.UseUnderline = true;
			this.table1.Add (this.check_EnableSuggestionMode);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_EnableSuggestionMode]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_EnableUFCSCompletion = new global::Gtk.CheckButton ();
			this.check_EnableUFCSCompletion.CanFocus = true;
			this.check_EnableUFCSCompletion.Name = "check_EnableUFCSCompletion";
			this.check_EnableUFCSCompletion.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Enable UFCS Completion");
			this.check_EnableUFCSCompletion.DrawIndicator = true;
			this.check_EnableUFCSCompletion.UseUnderline = true;
			this.table1.Add (this.check_EnableUFCSCompletion);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_EnableUFCSCompletion]));
			w5.TopAttach = ((uint)(2));
			w5.BottomAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_GrayOutNonPublic = new global::Gtk.CheckButton ();
			this.check_GrayOutNonPublic.CanFocus = true;
			this.check_GrayOutNonPublic.Name = "check_GrayOutNonPublic";
			this.check_GrayOutNonPublic.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Gray-out non public members");
			this.check_GrayOutNonPublic.Active = true;
			this.check_GrayOutNonPublic.DrawIndicator = true;
			this.check_GrayOutNonPublic.UseUnderline = true;
			this.table1.Add (this.check_GrayOutNonPublic);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_GrayOutNonPublic]));
			w6.TopAttach = ((uint)(10));
			w6.BottomAttach = ((uint)(11));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_HideDeprecatedItems = new global::Gtk.CheckButton ();
			w1.SetTip (this.check_HideDeprecatedItems, "If enabled, deadlocks might occur if mixins are used too often", "If enabled, deadlocks might occur if mixins are used too often");
			this.check_HideDeprecatedItems.CanFocus = true;
			this.check_HideDeprecatedItems.Name = "check_HideDeprecatedItems";
			this.check_HideDeprecatedItems.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Hide deprecated items in the completion list");
			this.check_HideDeprecatedItems.Active = true;
			this.check_HideDeprecatedItems.DrawIndicator = true;
			this.check_HideDeprecatedItems.UseUnderline = true;
			this.table1.Add (this.check_HideDeprecatedItems);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_HideDeprecatedItems]));
			w7.TopAttach = ((uint)(4));
			w7.BottomAttach = ((uint)(5));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_IndentInsteadFormatCode = new global::Gtk.CheckButton ();
			this.check_IndentInsteadFormatCode.CanFocus = true;
			this.check_IndentInsteadFormatCode.Name = "check_IndentInsteadFormatCode";
			this.check_IndentInsteadFormatCode.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Only indent code lines instead of rearrange code parts\n(because the actual format" +
			"ter isn\'t finished currently)");
			this.check_IndentInsteadFormatCode.Active = true;
			this.check_IndentInsteadFormatCode.DrawIndicator = true;
			this.check_IndentInsteadFormatCode.UseUnderline = true;
			this.table1.Add (this.check_IndentInsteadFormatCode);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_IndentInsteadFormatCode]));
			w8.TopAttach = ((uint)(13));
			w8.BottomAttach = ((uint)(14));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_ShowFunctionParams = new global::Gtk.CheckButton ();
			this.check_ShowFunctionParams.CanFocus = true;
			this.check_ShowFunctionParams.Name = "check_ShowFunctionParams";
			this.check_ShowFunctionParams.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Show function parameters");
			this.check_ShowFunctionParams.Active = true;
			this.check_ShowFunctionParams.DrawIndicator = true;
			this.check_ShowFunctionParams.UseUnderline = true;
			this.table1.Add (this.check_ShowFunctionParams);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_ShowFunctionParams]));
			w9.TopAttach = ((uint)(7));
			w9.BottomAttach = ((uint)(8));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_ShowFunctionVariables = new global::Gtk.CheckButton ();
			this.check_ShowFunctionVariables.CanFocus = true;
			this.check_ShowFunctionVariables.Name = "check_ShowFunctionVariables";
			this.check_ShowFunctionVariables.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Show function variables");
			this.check_ShowFunctionVariables.DrawIndicator = true;
			this.check_ShowFunctionVariables.UseUnderline = true;
			this.table1.Add (this.check_ShowFunctionVariables);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_ShowFunctionVariables]));
			w10.TopAttach = ((uint)(8));
			w10.BottomAttach = ((uint)(9));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.check_ShowTypes = new global::Gtk.CheckButton ();
			this.check_ShowTypes.CanFocus = true;
			this.check_ShowTypes.Name = "check_ShowTypes";
			this.check_ShowTypes.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Display node base types");
			this.check_ShowTypes.Active = true;
			this.check_ShowTypes.DrawIndicator = true;
			this.check_ShowTypes.UseUnderline = true;
			this.table1.Add (this.check_ShowTypes);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.check_ShowTypes]));
			w11.TopAttach = ((uint)(9));
			w11.BottomAttach = ((uint)(10));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("Expansion behaviour on tree rebuild");
			this.hbox2.Add (this.label5);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label5]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.combo_ExpansionBehaviour = global::Gtk.ComboBox.NewText ();
			this.combo_ExpansionBehaviour.AppendText (global::MonoDevelop.Core.GettextCatalog.GetString ("Collapse All"));
			this.combo_ExpansionBehaviour.AppendText (global::MonoDevelop.Core.GettextCatalog.GetString ("Leave expanded nodes expanded"));
			this.combo_ExpansionBehaviour.AppendText (global::MonoDevelop.Core.GettextCatalog.GetString ("Expand All"));
			this.combo_ExpansionBehaviour.Name = "combo_ExpansionBehaviour";
			this.combo_ExpansionBehaviour.Active = 0;
			this.hbox2.Add (this.combo_ExpansionBehaviour);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.combo_ExpansionBehaviour]));
			w13.Position = 1;
			this.table1.Add (this.hbox2);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1 [this.hbox2]));
			w14.TopAttach = ((uint)(11));
			w14.BottomAttach = ((uint)(12));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("<b>Editing &amp; Completion Options</b>");
			this.label2.UseMarkup = true;
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("<b>Document Outline</b>");
			this.label3.UseMarkup = true;
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w16.TopAttach = ((uint)(6));
			w16.BottomAttach = ((uint)(7));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("<b>Formatting (general)</b>");
			this.label4.UseMarkup = true;
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w17.TopAttach = ((uint)(12));
			w17.BottomAttach = ((uint)(13));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox1.Add (this.table1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.table1]));
			w18.Position = 0;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
		}
	}
}
