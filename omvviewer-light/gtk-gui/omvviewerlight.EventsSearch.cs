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
    
    
    public partial class EventsSearch {
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Label label1;
        
        private Gtk.Entry entry1;
        
        private Gtk.Button button_search;
        
        private Gtk.Label label_info;
        
        private Gtk.HBox hbox4;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView treeview1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.EventsSearch
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.EventsSearch";
            // Container child omvviewerlight.EventsSearch.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Find");
            this.hbox3.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox3[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.entry1 = new Gtk.Entry();
            this.entry1.CanFocus = true;
            this.entry1.Name = "entry1";
            this.entry1.IsEditable = true;
            this.entry1.InvisibleChar = '●';
            this.hbox3.Add(this.entry1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox3[this.entry1]));
            w2.Position = 1;
            // Container child hbox3.Gtk.Box+BoxChild
            this.button_search = new Gtk.Button();
            this.button_search.CanFocus = true;
            this.button_search.Name = "button_search";
            this.button_search.UseUnderline = true;
            // Container child button_search.Gtk.Container+ContainerChild
            Gtk.Alignment w3 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w4 = new Gtk.HBox();
            w4.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w5 = new Gtk.Image();
            w5.Pixbuf = Gdk.Pixbuf.LoadFromResource("omvviewer-light.art.status_search_btn.png");
            w4.Add(w5);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w7 = new Gtk.Label();
            w7.LabelProp = Mono.Unix.Catalog.GetString("Search");
            w7.UseUnderline = true;
            w4.Add(w7);
            w3.Add(w4);
            this.button_search.Add(w3);
            this.hbox3.Add(this.button_search);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox3[this.button_search]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            this.vbox1.Add(this.hbox3);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
            w12.Position = 0;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_info = new Gtk.Label();
            this.label_info.Name = "label_info";
            this.label_info.Xalign = 0.01F;
            this.label_info.LabelProp = Mono.Unix.Catalog.GetString("Type the name of events to search for and press the search button");
            this.vbox1.Add(this.label_info);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_info]));
            w13.Position = 1;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.treeview1 = new Gtk.TreeView();
            this.treeview1.CanFocus = true;
            this.treeview1.Name = "treeview1";
            this.treeview1.HeadersClickable = true;
            this.GtkScrolledWindow.Add(this.treeview1);
            this.hbox4.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.hbox4[this.GtkScrolledWindow]));
            w15.Position = 0;
            this.vbox1.Add(this.hbox4);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
            w16.Position = 2;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button_search.Clicked += new System.EventHandler(this.OnButtonSearchClicked);
        }
    }
}
