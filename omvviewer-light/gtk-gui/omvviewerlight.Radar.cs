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
    
    
    public partial class Radar {
        
        private Gtk.VBox vbox1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView treeview_radar;
        
        private Gtk.VBox vbox2;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Button button_im;
        
        private Gtk.Button button2;
        
        private Gtk.Button button3;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Radar
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.Radar";
            // Container child omvviewerlight.Radar.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.treeview_radar = new Gtk.TreeView();
            this.treeview_radar.CanFocus = true;
            this.treeview_radar.Name = "treeview_radar";
            this.treeview_radar.HeadersClickable = true;
            this.GtkScrolledWindow.Add(this.treeview_radar);
            this.vbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
            w2.Position = 0;
            // Container child vbox1.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button_im = new Gtk.Button();
            this.button_im.CanFocus = true;
            this.button_im.Name = "button_im";
            this.button_im.UseUnderline = true;
            this.button_im.Label = Mono.Unix.Catalog.GetString("IM");
            this.hbox2.Add(this.button_im);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox2[this.button_im]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button2 = new Gtk.Button();
            this.button2.CanFocus = true;
            this.button2.Name = "button2";
            this.button2.UseUnderline = true;
            this.button2.Label = Mono.Unix.Catalog.GetString("button2");
            this.hbox2.Add(this.button2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.button2]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button3 = new Gtk.Button();
            this.button3.CanFocus = true;
            this.button3.Name = "button3";
            this.button3.UseUnderline = true;
            this.button3.Label = Mono.Unix.Catalog.GetString("button3");
            this.hbox2.Add(this.button3);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.button3]));
            w5.Position = 2;
            w5.Expand = false;
            w5.Fill = false;
            this.vbox2.Add(this.hbox2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            this.vbox1.Add(this.vbox2);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
            w7.Position = 1;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button_im.Clicked += new System.EventHandler(this.OnButtonImClicked);
        }
    }
}
