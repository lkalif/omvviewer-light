// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace omvviewerlight {
    
    
    public partial class GroupSearch {
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Label label1;
        
        private Gtk.Entry entry_search;
        
        private Gtk.Button button1;
        
        private Gtk.Label label_search_progress;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView treeview1;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Button button_view_group_profile;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.GroupSearch
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.GroupSearch";
            // Container child omvviewerlight.GroupSearch.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Search for");
            this.hbox1.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.entry_search = new Gtk.Entry();
            this.entry_search.CanFocus = true;
            this.entry_search.Name = "entry_search";
            this.entry_search.IsEditable = true;
            this.entry_search.InvisibleChar = '●';
            this.hbox1.Add(this.entry_search);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.entry_search]));
            w2.Position = 1;
            // Container child hbox1.Gtk.Box+BoxChild
            this.button1 = new Gtk.Button();
            this.button1.CanFocus = true;
            this.button1.Name = "button1";
            this.button1.UseUnderline = true;
            // Container child button1.Gtk.Container+ContainerChild
            Gtk.Alignment w3 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w4 = new Gtk.HBox();
            w4.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w5 = new Gtk.Image();
            w5.Pixbuf = Gdk.Pixbuf.LoadFromResource("status_search_btn.png");
            w4.Add(w5);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w7 = new Gtk.Label();
            w7.LabelProp = Mono.Unix.Catalog.GetString("Search");
            w7.UseUnderline = true;
            w4.Add(w7);
            w3.Add(w4);
            this.button1.Add(w3);
            this.hbox1.Add(this.button1);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox1[this.button1]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w12.Position = 0;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_search_progress = new Gtk.Label();
            this.label_search_progress.Name = "label_search_progress";
            this.label_search_progress.Xalign = 0F;
            this.label_search_progress.LabelProp = Mono.Unix.Catalog.GetString("Type a name or partial group name to search for and press search");
            this.vbox1.Add(this.label_search_progress);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_search_progress]));
            w13.Position = 1;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.treeview1 = new Gtk.TreeView();
            this.treeview1.CanFocus = true;
            this.treeview1.Name = "treeview1";
            this.treeview1.HeadersClickable = true;
            this.GtkScrolledWindow.Add(this.treeview1);
            this.vbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
            w15.Position = 2;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button_view_group_profile = new Gtk.Button();
            this.button_view_group_profile.CanFocus = true;
            this.button_view_group_profile.Name = "button_view_group_profile";
            this.button_view_group_profile.UseUnderline = true;
            this.button_view_group_profile.Label = Mono.Unix.Catalog.GetString("View full group profile");
            this.hbox2.Add(this.button_view_group_profile);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.hbox2[this.button_view_group_profile]));
            w16.Position = 0;
            w16.Expand = false;
            w16.Fill = false;
            this.vbox1.Add(this.hbox2);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
            w17.Position = 3;
            w17.Expand = false;
            w17.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button1.Clicked += new System.EventHandler(this.OnButton1Clicked);
            this.button_view_group_profile.Clicked += new System.EventHandler(this.OnButtonViewGroupProfileClicked);
        }
    }
}
