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
    
    
    public partial class Map {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label1;
        
        private Gtk.EventBox eventbox1;
        
        private Gtk.Image image;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Map
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.Map";
            // Container child omvviewerlight.Map.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.WidthRequest = 350;
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("label1");
            this.vbox1.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.eventbox1 = new Gtk.EventBox();
            this.eventbox1.WidthRequest = 256;
            this.eventbox1.HeightRequest = 256;
            this.eventbox1.Name = "eventbox1";
            this.eventbox1.BorderWidth = ((uint)(1));
            // Container child eventbox1.Gtk.Container+ContainerChild
            this.image = new Gtk.Image();
            this.image.WidthRequest = 256;
            this.image.HeightRequest = 256;
            this.image.ExtensionEvents = ((Gdk.ExtensionMode)(1));
            this.image.Name = "image";
            this.eventbox1.Add(this.image);
            this.vbox1.Add(this.eventbox1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.eventbox1]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.image.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.OnImageButtonPressEvent);
        }
    }
}
