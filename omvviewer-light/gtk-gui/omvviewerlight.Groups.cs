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
    
    
    public partial class Groups {
        
        private Gtk.HBox hbox1;
        
        private Gtk.VBox vbox1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView treeview1;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Button button_groupim;
        
        private Gtk.Button button_info;
        
        private Gtk.Button Activate_group;
        
        private Gtk.VBox vbox2;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Groups
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.Groups";
            // Container child omvviewerlight.Groups.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.treeview1 = new Gtk.TreeView();
            this.treeview1.WidthRequest = 350;
            this.treeview1.CanFocus = true;
            this.treeview1.Name = "treeview1";
            this.treeview1.HeadersClickable = true;
            this.GtkScrolledWindow.Add(this.treeview1);
            this.vbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
            w2.Position = 0;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button_groupim = new Gtk.Button();
            this.button_groupim.CanFocus = true;
            this.button_groupim.Name = "button_groupim";
            this.button_groupim.UseUnderline = true;
            this.button_groupim.Label = Mono.Unix.Catalog.GetString("Start IM");
            this.hbox2.Add(this.button_groupim);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox2[this.button_groupim]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button_info = new Gtk.Button();
            this.button_info.CanFocus = true;
            this.button_info.Name = "button_info";
            this.button_info.UseUnderline = true;
            this.button_info.Label = Mono.Unix.Catalog.GetString("Group Info");
            this.hbox2.Add(this.button_info);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.button_info]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.Activate_group = new Gtk.Button();
            this.Activate_group.CanFocus = true;
            this.Activate_group.Name = "Activate_group";
            this.Activate_group.UseUnderline = true;
            this.Activate_group.Label = Mono.Unix.Catalog.GetString("Activate");
            this.hbox2.Add(this.Activate_group);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.Activate_group]));
            w5.Position = 2;
            w5.Expand = false;
            w5.Fill = false;
            this.vbox1.Add(this.hbox2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            this.hbox1.Add(this.vbox1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox1]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.hbox1.Add(this.vbox2);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
            w8.Position = 1;
            this.Add(this.hbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button_groupim.Clicked += new System.EventHandler(this.OnButtonGroupimClicked);
            this.button_info.Clicked += new System.EventHandler(this.OnButtonInfoClicked);
            this.Activate_group.Clicked += new System.EventHandler(this.OnActivateGroupClicked);
        }
    }
}
