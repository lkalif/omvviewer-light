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
    
    
    public partial class Location {
        
        private Gtk.HBox hbox1;
        
        private Gtk.VBox vbox4;
        
        private omvviewerlight.Map map1;
        
        private omvviewerlight.TeleportTo teleportto1;
        
        private Gtk.VBox vbox6;
        
        private omvviewerlight.LocalRegion localregion1;
        
        private omvviewerlight.Radar radar1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Location
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.Location";
            // Container child omvviewerlight.Location.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.map1 = new omvviewerlight.Map();
            this.map1.WidthRequest = 350;
            this.map1.HeightRequest = 350;
            this.map1.Events = ((Gdk.EventMask)(256));
            this.map1.Name = "map1";
            this.vbox4.Add(this.map1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox4[this.map1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.teleportto1 = new omvviewerlight.TeleportTo();
            this.teleportto1.HeightRequest = 160;
            this.teleportto1.Events = ((Gdk.EventMask)(256));
            this.teleportto1.Name = "teleportto1";
            this.vbox4.Add(this.teleportto1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox4[this.teleportto1]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            this.hbox1.Add(this.vbox4);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox4]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox6 = new Gtk.VBox();
            this.vbox6.Name = "vbox6";
            this.vbox6.Spacing = 6;
            // Container child vbox6.Gtk.Box+BoxChild
            this.localregion1 = new omvviewerlight.LocalRegion();
            this.localregion1.Events = ((Gdk.EventMask)(256));
            this.localregion1.Name = "localregion1";
            this.vbox6.Add(this.localregion1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox6[this.localregion1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.radar1 = new omvviewerlight.Radar();
            this.radar1.WidthRequest = 275;
            this.radar1.Events = ((Gdk.EventMask)(256));
            this.radar1.Name = "radar1";
            this.vbox6.Add(this.radar1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox6[this.radar1]));
            w5.Position = 1;
            this.hbox1.Add(this.vbox6);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox6]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            this.Add(this.hbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
