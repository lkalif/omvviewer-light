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
    
    
    public partial class aPick {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Image image2;
        
        private Gtk.Label label_sim;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TextView textview1;
        
        private Gtk.Label label_info;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Button button_teleport;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.aPick
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.aPick";
            // Container child omvviewerlight.aPick.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.image2 = new Gtk.Image();
            this.image2.WidthRequest = 128;
            this.image2.HeightRequest = 128;
            this.image2.Name = "image2";
            this.vbox1.Add(this.image2);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.image2]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_sim = new Gtk.Label();
            this.label_sim.Name = "label_sim";
            this.label_sim.LabelProp = Mono.Unix.Catalog.GetString("label1");
            this.vbox1.Add(this.label_sim);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_sim]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.textview1 = new Gtk.TextView();
            this.textview1.WidthRequest = 175;
            this.textview1.CanFocus = true;
            this.textview1.Name = "textview1";
            this.textview1.WrapMode = ((Gtk.WrapMode)(2));
            this.GtkScrolledWindow.Add(this.textview1);
            this.vbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
            w4.Position = 2;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_info = new Gtk.Label();
            this.label_info.Name = "label_info";
            this.label_info.LabelProp = Mono.Unix.Catalog.GetString("label2");
            this.vbox1.Add(this.label_info);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_info]));
            w5.Position = 3;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.button_teleport = new Gtk.Button();
            this.button_teleport.CanFocus = true;
            this.button_teleport.Name = "button_teleport";
            this.button_teleport.UseUnderline = true;
            this.button_teleport.Label = Mono.Unix.Catalog.GetString("Teleport");
            this.hbox1.Add(this.button_teleport);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.button_teleport]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w7.Position = 4;
            w7.Expand = false;
            w7.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button_teleport.Clicked += new System.EventHandler(this.OnButtonTeleportClicked);
        }
    }
}