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
    
    
    public partial class TeleportProgress {
        
        private Gtk.VBox vbox3;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Label label2;
        
        private Gtk.Label label_sim;
        
        private Gtk.Label label_loc;
        
        private Gtk.Label label_info;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Image image356;
        
        private Gtk.ProgressBar progressbar1;
        
        private Gtk.HBox hbox4;
        
        private Gtk.Button button_close;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.TeleportProgress
            this.Name = "omvviewerlight.TeleportProgress";
            this.Title = Mono.Unix.Catalog.GetString("Teleport Progress");
            this.WindowPosition = ((Gtk.WindowPosition)(1));
            this.Modal = true;
            // Container child omvviewerlight.TeleportProgress.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Trying to teleport to -");
            this.hbox3.Add(this.label2);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox3[this.label2]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            w1.Padding = ((uint)(27));
            // Container child hbox3.Gtk.Box+BoxChild
            this.label_sim = new Gtk.Label();
            this.label_sim.Name = "label_sim";
            this.label_sim.LabelProp = Mono.Unix.Catalog.GetString("Sim");
            this.hbox3.Add(this.label_sim);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox3[this.label_sim]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.label_loc = new Gtk.Label();
            this.label_loc.Name = "label_loc";
            this.label_loc.LabelProp = Mono.Unix.Catalog.GetString("<0,0,0>");
            this.hbox3.Add(this.label_loc);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox3[this.label_loc]));
            w3.Position = 2;
            w3.Expand = false;
            w3.Fill = false;
            this.vbox3.Add(this.hbox3);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbox3]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            w4.Padding = ((uint)(8));
            // Container child vbox3.Gtk.Box+BoxChild
            this.label_info = new Gtk.Label();
            this.label_info.Name = "label_info";
            this.label_info.Xpad = 24;
            this.label_info.Xalign = 0F;
            this.vbox3.Add(this.label_info);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox3[this.label_info]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.image356 = new Gtk.Image();
            this.image356.Name = "image356";
            this.image356.Pixbuf = MainClass.GetResource("icon_place.png");
            this.hbox1.Add(this.image356);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.image356]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.progressbar1 = new Gtk.ProgressBar();
            this.progressbar1.Name = "progressbar1";
            this.progressbar1.Fraction = 0.00999999999999991;
            this.progressbar1.PulseStep = 1;
            this.hbox1.Add(this.progressbar1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox1[this.progressbar1]));
            w7.Position = 1;
            this.vbox3.Add(this.hbox1);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbox1]));
            w8.Position = 2;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Homogeneous = true;
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.button_close = new Gtk.Button();
            this.button_close.Sensitive = false;
            this.button_close.CanFocus = true;
            this.button_close.Name = "button_close";
            this.button_close.UseStock = true;
            this.button_close.UseUnderline = true;
            this.button_close.Label = "gtk-stop";
            this.hbox4.Add(this.button_close);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox4[this.button_close]));
            w9.Position = 0;
            w9.Expand = false;
            w9.Fill = false;
            this.vbox3.Add(this.hbox4);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
            w10.Position = 3;
            w10.Expand = false;
            w10.Fill = false;
            this.Add(this.vbox3);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 416;
            this.DefaultHeight = 149;
            this.Show();
            this.button_close.Clicked += new System.EventHandler(this.OnButtonCloseClicked);
        }
    }
}
