// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
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
        
        private Gtk.Notebook notebook1;
        
        private omvviewerlight.LocalRegion localregion1;
        
        private Gtk.Label label3;
        
        private omvviewerlight.Radar radar1;
        
        private Gtk.Label label4;
        
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
            // Container child hbox1.Gtk.Box+BoxChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 0;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.localregion1 = new omvviewerlight.LocalRegion();
            this.localregion1.Events = ((Gdk.EventMask)(256));
            this.localregion1.Name = "localregion1";
            this.notebook1.Add(this.localregion1);
            Gtk.Notebook.NotebookChild w4 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.localregion1]));
            w4.TabFill = false;
            // Notebook tab
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Region");
            this.notebook1.SetTabLabel(this.localregion1, this.label3);
            this.label3.ShowAll();
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.radar1 = new omvviewerlight.Radar();
            this.radar1.WidthRequest = 275;
            this.radar1.Events = ((Gdk.EventMask)(256));
            this.radar1.Name = "radar1";
            this.notebook1.Add(this.radar1);
            Gtk.Notebook.NotebookChild w5 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.radar1]));
            w5.Position = 1;
            // Notebook tab
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Radar");
            this.notebook1.SetTabLabel(this.radar1, this.label4);
            this.label4.ShowAll();
            this.hbox1.Add(this.notebook1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.notebook1]));
            w6.Position = 1;
            this.Add(this.hbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
