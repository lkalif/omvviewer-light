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
    
    
    public partial class TeleportTo {
        
        private Gtk.VBox vbox2;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Label label_current;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.VBox vbox5;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Label label1;
        
        private Gtk.Entry entry_simname;
        
        private Gtk.HBox hbox4;
        
        private Gtk.Label label12;
        
        private Gtk.Label label13;
        
        private Gtk.Label label14;
        
        private Gtk.HBox hbox5;
        
        private Gtk.SpinButton spinbutton_x;
        
        private Gtk.SpinButton spinbutton_y;
        
        private Gtk.SpinButton spinbutton_z;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Button button_teleport;
        
        private Gtk.Button button_tphome;
        
        private Gtk.Label GtkLabel1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.TeleportTo
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.TeleportTo";
            // Container child omvviewerlight.TeleportTo.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.label_current = new Gtk.Label();
            this.label_current.Name = "label_current";
            this.label_current.LabelProp = Mono.Unix.Catalog.GetString("Current location: Hippotropollis 128,128,0");
            this.vbox3.Add(this.label_current);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox3[this.label_current]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            this.vbox2.Add(this.vbox3);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(12));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("SIm Name");
            this.hbox1.Add(this.label1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.label1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.entry_simname = new Gtk.Entry();
            this.entry_simname.CanFocus = true;
            this.entry_simname.Name = "entry_simname";
            this.entry_simname.IsEditable = true;
            this.entry_simname.InvisibleChar = '●';
            this.hbox1.Add(this.entry_simname);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox1[this.entry_simname]));
            w4.Position = 1;
            this.vbox5.Add(this.hbox1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox5[this.hbox1]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Homogeneous = true;
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.label12 = new Gtk.Label();
            this.label12.Name = "label12";
            this.label12.LabelProp = Mono.Unix.Catalog.GetString("X");
            this.hbox4.Add(this.label12);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox4[this.label12]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.label13 = new Gtk.Label();
            this.label13.Name = "label13";
            this.label13.LabelProp = Mono.Unix.Catalog.GetString("Y");
            this.hbox4.Add(this.label13);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox4[this.label13]));
            w7.Position = 1;
            w7.Expand = false;
            w7.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.label14 = new Gtk.Label();
            this.label14.Name = "label14";
            this.label14.LabelProp = Mono.Unix.Catalog.GetString("Z");
            this.hbox4.Add(this.label14);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.hbox4[this.label14]));
            w8.Position = 2;
            w8.Expand = false;
            w8.Fill = false;
            this.vbox5.Add(this.hbox4);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox5[this.hbox4]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.hbox5 = new Gtk.HBox();
            this.hbox5.Name = "hbox5";
            this.hbox5.Homogeneous = true;
            this.hbox5.Spacing = 6;
            // Container child hbox5.Gtk.Box+BoxChild
            this.spinbutton_x = new Gtk.SpinButton(0, 255, 1);
            this.spinbutton_x.CanFocus = true;
            this.spinbutton_x.Name = "spinbutton_x";
            this.spinbutton_x.Adjustment.PageIncrement = 10;
            this.spinbutton_x.ClimbRate = 1;
            this.spinbutton_x.Numeric = true;
            this.spinbutton_x.Value = 128;
            this.hbox5.Add(this.spinbutton_x);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.hbox5[this.spinbutton_x]));
            w10.Position = 0;
            w10.Expand = false;
            w10.Fill = false;
            // Container child hbox5.Gtk.Box+BoxChild
            this.spinbutton_y = new Gtk.SpinButton(0, 255, 1);
            this.spinbutton_y.CanFocus = true;
            this.spinbutton_y.Name = "spinbutton_y";
            this.spinbutton_y.Adjustment.PageIncrement = 10;
            this.spinbutton_y.ClimbRate = 1;
            this.spinbutton_y.Numeric = true;
            this.spinbutton_y.Value = 128;
            this.hbox5.Add(this.spinbutton_y);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox5[this.spinbutton_y]));
            w11.Position = 1;
            w11.Expand = false;
            w11.Fill = false;
            // Container child hbox5.Gtk.Box+BoxChild
            this.spinbutton_z = new Gtk.SpinButton(0, 255, 1);
            this.spinbutton_z.CanFocus = true;
            this.spinbutton_z.Name = "spinbutton_z";
            this.spinbutton_z.Adjustment.PageIncrement = 10;
            this.spinbutton_z.ClimbRate = 1;
            this.spinbutton_z.Numeric = true;
            this.spinbutton_z.Value = 50;
            this.hbox5.Add(this.spinbutton_z);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox5[this.spinbutton_z]));
            w12.Position = 2;
            w12.Expand = false;
            w12.Fill = false;
            this.vbox5.Add(this.hbox5);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox5[this.hbox5]));
            w13.Position = 2;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Homogeneous = true;
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button_teleport = new Gtk.Button();
            this.button_teleport.CanFocus = true;
            this.button_teleport.Name = "button_teleport";
            this.button_teleport.UseUnderline = true;
            this.button_teleport.Label = Mono.Unix.Catalog.GetString("Teleport");
            this.hbox2.Add(this.button_teleport);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox2[this.button_teleport]));
            w14.Position = 0;
            w14.Expand = false;
            w14.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.button_tphome = new Gtk.Button();
            this.button_tphome.CanFocus = true;
            this.button_tphome.Name = "button_tphome";
            this.button_tphome.UseUnderline = true;
            // Container child button_tphome.Gtk.Container+ContainerChild
            Gtk.Alignment w15 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w16 = new Gtk.HBox();
            w16.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w17 = new Gtk.Image();
            w17.Pixbuf = new Gdk.Pixbuf(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "./map_home.tga"));
            w16.Add(w17);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w19 = new Gtk.Label();
            w19.LabelProp = Mono.Unix.Catalog.GetString("Go Home");
            w19.UseUnderline = true;
            w16.Add(w19);
            w15.Add(w16);
            this.button_tphome.Add(w15);
            this.hbox2.Add(this.button_tphome);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.hbox2[this.button_tphome]));
            w23.Position = 1;
            w23.Expand = false;
            w23.Fill = false;
            this.vbox5.Add(this.hbox2);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
            w24.Position = 3;
            w24.Expand = false;
            w24.Fill = false;
            this.GtkAlignment.Add(this.vbox5);
            this.frame1.Add(this.GtkAlignment);
            this.GtkLabel1 = new Gtk.Label();
            this.GtkLabel1.Name = "GtkLabel1";
            this.GtkLabel1.LabelProp = Mono.Unix.Catalog.GetString("<b>Teleport target</b>");
            this.GtkLabel1.UseMarkup = true;
            this.frame1.LabelWidget = this.GtkLabel1;
            this.vbox2.Add(this.frame1);
            Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
            w27.Position = 1;
            w27.Expand = false;
            w27.Fill = false;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button_teleport.Activated += new System.EventHandler(this.OnButtonTeleportActivated);
            this.button_teleport.Clicked += new System.EventHandler(this.OnButtonTeleportClicked);
            this.button_tphome.Clicked += new System.EventHandler(this.OnButtonTphomeClicked);
        }
    }
}
