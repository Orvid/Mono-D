
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.D.Formatting
{
	public partial class FormattingPanelWidget
	{
		private global::Gtk.Table table1;
		private global::Gtk.CheckButton chk_CommentOutStdHeaders;
		private global::Gtk.CheckButton chk_InsertStarAtCommentNewLine;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.D.Formatting.FormattingPanelWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.D.Formatting.FormattingPanelWidget";
			// Container child MonoDevelop.D.Formatting.FormattingPanelWidget.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.chk_CommentOutStdHeaders = new global::Gtk.CheckButton ();
			this.chk_CommentOutStdHeaders.CanFocus = true;
			this.chk_CommentOutStdHeaders.Name = "chk_CommentOutStdHeaders";
			this.chk_CommentOutStdHeaders.Label = global::Mono.Unix.Catalog.GetString ("Comment out standard header");
			this.chk_CommentOutStdHeaders.DrawIndicator = true;
			this.chk_CommentOutStdHeaders.UseUnderline = true;
			this.table1.Add (this.chk_CommentOutStdHeaders);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1 [this.chk_CommentOutStdHeaders]));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.chk_InsertStarAtCommentNewLine = new global::Gtk.CheckButton ();
			this.chk_InsertStarAtCommentNewLine.CanFocus = true;
			this.chk_InsertStarAtCommentNewLine.Name = "chk_InsertStarAtCommentNewLine";
			this.chk_InsertStarAtCommentNewLine.Label = global::Mono.Unix.Catalog.GetString ("Insert * or + at comment new line");
			this.chk_InsertStarAtCommentNewLine.DrawIndicator = true;
			this.chk_InsertStarAtCommentNewLine.UseUnderline = true;
			this.table1.Add (this.chk_InsertStarAtCommentNewLine);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.chk_InsertStarAtCommentNewLine]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.table1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}