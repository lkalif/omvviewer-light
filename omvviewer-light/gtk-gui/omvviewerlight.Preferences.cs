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
    
    
    public partial class Preferences {
        
        private Gtk.Notebook notebook1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.VBox vbox3;
        
        private Gtk.CheckButton checkbutton_showtimestamps;
        
        private Gtk.Label GtkLabel1;
        
        private Gtk.Frame frame2;
        
        private Gtk.Alignment GtkAlignment1;
        
        private Gtk.VBox vbox4;
        
        private Gtk.CheckButton checkbutton_hideminimise;
        
        private Gtk.RadioButton radiobutton1;
        
        private Gtk.RadioButton radiobutton2;
        
        private Gtk.Label GtkLabel5;
        
        private Gtk.Label label2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.VBox vbox5;
        
        private Gtk.Label label3;
        
        private Gtk.Label label4;
        
        private Gtk.Label label5;
        
        private Gtk.Label label6;
        
        private Gtk.Label label7;
        
        private Gtk.Label label8;
        
        private Gtk.Label label9;
        
        private Gtk.VBox vbox6;
        
        private Gtk.HScale hscale_cloud;
        
        private Gtk.HScale hscale_wind;
        
        private Gtk.HScale hscale_land;
        
        private Gtk.HScale hscale_texture;
        
        private Gtk.HScale hscale_asset;
        
        private Gtk.HScale hscale_resend;
        
        private Gtk.HScale hscale_task;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Button button_applythrottle;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Preferences
            this.Name = "omvviewerlight.Preferences";
            this.Title = Mono.Unix.Catalog.GetString("Preferences");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child omvviewerlight.Preferences.Gtk.Container+ContainerChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 1;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(12));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.checkbutton_showtimestamps = new Gtk.CheckButton();
            this.checkbutton_showtimestamps.CanFocus = true;
            this.checkbutton_showtimestamps.Name = "checkbutton_showtimestamps";
            this.checkbutton_showtimestamps.Label = Mono.Unix.Catalog.GetString("Show time stamps in chat and IMs");
            this.checkbutton_showtimestamps.DrawIndicator = true;
            this.checkbutton_showtimestamps.UseUnderline = true;
            this.vbox3.Add(this.checkbutton_showtimestamps);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox3[this.checkbutton_showtimestamps]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            this.GtkAlignment.Add(this.vbox3);
            this.frame1.Add(this.GtkAlignment);
            this.GtkLabel1 = new Gtk.Label();
            this.GtkLabel1.Name = "GtkLabel1";
            this.GtkLabel1.LabelProp = Mono.Unix.Catalog.GetString("<b>Chat and IMs</b>");
            this.GtkLabel1.UseMarkup = true;
            this.frame1.LabelWidget = this.GtkLabel1;
            this.vbox2.Add(this.frame1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.frame2 = new Gtk.Frame();
            this.frame2.Name = "frame2";
            this.frame2.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame2.Gtk.Container+ContainerChild
            this.GtkAlignment1 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment1.Name = "GtkAlignment1";
            this.GtkAlignment1.LeftPadding = ((uint)(12));
            // Container child GtkAlignment1.Gtk.Container+ContainerChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.checkbutton_hideminimise = new Gtk.CheckButton();
            this.checkbutton_hideminimise.CanFocus = true;
            this.checkbutton_hideminimise.Name = "checkbutton_hideminimise";
            this.checkbutton_hideminimise.Label = Mono.Unix.Catalog.GetString("Hide minimise confirm");
            this.checkbutton_hideminimise.DrawIndicator = true;
            this.checkbutton_hideminimise.UseUnderline = true;
            this.vbox4.Add(this.checkbutton_hideminimise);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox4[this.checkbutton_hideminimise]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.radiobutton1 = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("Default is to minimise"));
            this.radiobutton1.CanFocus = true;
            this.radiobutton1.Name = "radiobutton1";
            this.radiobutton1.DrawIndicator = true;
            this.radiobutton1.UseUnderline = true;
            this.radiobutton1.Group = new GLib.SList(System.IntPtr.Zero);
            this.vbox4.Add(this.radiobutton1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox4[this.radiobutton1]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.radiobutton2 = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("Default is to close"));
            this.radiobutton2.CanFocus = true;
            this.radiobutton2.Name = "radiobutton2";
            this.radiobutton2.DrawIndicator = true;
            this.radiobutton2.UseUnderline = true;
            this.radiobutton2.Group = this.radiobutton1.Group;
            this.vbox4.Add(this.radiobutton2);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox4[this.radiobutton2]));
            w7.Position = 2;
            w7.Expand = false;
            w7.Fill = false;
            this.GtkAlignment1.Add(this.vbox4);
            this.frame2.Add(this.GtkAlignment1);
            this.GtkLabel5 = new Gtk.Label();
            this.GtkLabel5.Name = "GtkLabel5";
            this.GtkLabel5.LabelProp = Mono.Unix.Catalog.GetString("<b>Minimise</b>");
            this.GtkLabel5.UseMarkup = true;
            this.frame2.LabelWidget = this.GtkLabel5;
            this.vbox2.Add(this.frame2);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame2]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            this.notebook1.Add(this.vbox2);
            // Notebook tab
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("page1");
            this.notebook1.SetTabLabel(this.vbox2, this.label2);
            this.label2.ShowAll();
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Homogeneous = true;
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Cloud");
            this.vbox5.Add(this.label3);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox5[this.label3]));
            w12.Position = 0;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Wind");
            this.vbox5.Add(this.label4);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox5[this.label4]));
            w13.Position = 1;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Land");
            this.vbox5.Add(this.label5);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox5[this.label5]));
            w14.Position = 2;
            w14.Expand = false;
            w14.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Texture");
            this.vbox5.Add(this.label6);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox5[this.label6]));
            w15.Position = 3;
            w15.Expand = false;
            w15.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("Asset");
            this.vbox5.Add(this.label7);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox5[this.label7]));
            w16.Position = 4;
            w16.Expand = false;
            w16.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Resend");
            this.vbox5.Add(this.label8);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox5[this.label8]));
            w17.Position = 5;
            w17.Expand = false;
            w17.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label9 = new Gtk.Label();
            this.label9.Name = "label9";
            this.label9.LabelProp = Mono.Unix.Catalog.GetString("Task");
            this.vbox5.Add(this.label9);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox5[this.label9]));
            w18.Position = 6;
            w18.Expand = false;
            w18.Fill = false;
            this.hbox1.Add(this.vbox5);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox5]));
            w19.Position = 0;
            w19.Expand = false;
            w19.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox6 = new Gtk.VBox();
            this.vbox6.Name = "vbox6";
            this.vbox6.Homogeneous = true;
            this.vbox6.Spacing = 6;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_cloud = new Gtk.HScale(null);
            this.hscale_cloud.CanFocus = true;
            this.hscale_cloud.Name = "hscale_cloud";
            this.hscale_cloud.Adjustment.Upper = 34000;
            this.hscale_cloud.Adjustment.PageIncrement = 1000;
            this.hscale_cloud.Adjustment.PageSize = 1000;
            this.hscale_cloud.DrawValue = true;
            this.hscale_cloud.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_cloud);
            Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_cloud]));
            w20.Position = 0;
            w20.Expand = false;
            w20.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_wind = new Gtk.HScale(null);
            this.hscale_wind.CanFocus = true;
            this.hscale_wind.Name = "hscale_wind";
            this.hscale_wind.Adjustment.Upper = 34000;
            this.hscale_wind.Adjustment.PageIncrement = 1000;
            this.hscale_wind.Adjustment.PageSize = 1000;
            this.hscale_wind.DrawValue = true;
            this.hscale_wind.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_wind);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_wind]));
            w21.Position = 1;
            w21.Expand = false;
            w21.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_land = new Gtk.HScale(null);
            this.hscale_land.CanFocus = true;
            this.hscale_land.Name = "hscale_land";
            this.hscale_land.Adjustment.Upper = 170000;
            this.hscale_land.Adjustment.PageIncrement = 1000;
            this.hscale_land.Adjustment.StepIncrement = 1000;
            this.hscale_land.DrawValue = true;
            this.hscale_land.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_land);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_land]));
            w22.Position = 2;
            w22.Expand = false;
            w22.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_texture = new Gtk.HScale(null);
            this.hscale_texture.CanFocus = true;
            this.hscale_texture.Name = "hscale_texture";
            this.hscale_texture.Adjustment.Lower = 4000;
            this.hscale_texture.Adjustment.Upper = 446000;
            this.hscale_texture.Adjustment.PageIncrement = 1000;
            this.hscale_texture.Adjustment.PageSize = 1000;
            this.hscale_texture.Adjustment.Value = 4000;
            this.hscale_texture.DrawValue = true;
            this.hscale_texture.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_texture);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_texture]));
            w23.Position = 3;
            w23.Expand = false;
            w23.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_asset = new Gtk.HScale(null);
            this.hscale_asset.CanFocus = true;
            this.hscale_asset.Name = "hscale_asset";
            this.hscale_asset.Adjustment.Lower = 10000;
            this.hscale_asset.Adjustment.Upper = 220000;
            this.hscale_asset.Adjustment.PageIncrement = 1000;
            this.hscale_asset.Adjustment.PageSize = 1000;
            this.hscale_asset.Adjustment.Value = 10000;
            this.hscale_asset.DrawValue = true;
            this.hscale_asset.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_asset);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_asset]));
            w24.Position = 4;
            w24.Expand = false;
            w24.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_resend = new Gtk.HScale(null);
            this.hscale_resend.CanFocus = true;
            this.hscale_resend.Name = "hscale_resend";
            this.hscale_resend.Adjustment.Lower = 10000;
            this.hscale_resend.Adjustment.Upper = 150000;
            this.hscale_resend.Adjustment.PageIncrement = 1000;
            this.hscale_resend.Adjustment.StepIncrement = 1000;
            this.hscale_resend.Adjustment.Value = 10000;
            this.hscale_resend.DrawValue = true;
            this.hscale_resend.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_resend);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_resend]));
            w25.Position = 5;
            w25.Expand = false;
            w25.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hscale_task = new Gtk.HScale(null);
            this.hscale_task.CanFocus = true;
            this.hscale_task.Name = "hscale_task";
            this.hscale_task.Adjustment.Lower = 4000;
            this.hscale_task.Adjustment.Upper = 446000;
            this.hscale_task.Adjustment.PageIncrement = 1000;
            this.hscale_task.Adjustment.PageSize = 1000;
            this.hscale_task.Adjustment.Value = 4000;
            this.hscale_task.DrawValue = true;
            this.hscale_task.ValuePos = ((Gtk.PositionType)(2));
            this.vbox6.Add(this.hscale_task);
            Gtk.Box.BoxChild w26 = ((Gtk.Box.BoxChild)(this.vbox6[this.hscale_task]));
            w26.Position = 6;
            w26.Expand = false;
            w26.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.button_applythrottle = new Gtk.Button();
            this.button_applythrottle.CanFocus = true;
            this.button_applythrottle.Name = "button_applythrottle";
            this.button_applythrottle.UseUnderline = true;
            this.button_applythrottle.Label = Mono.Unix.Catalog.GetString("Apply throttle settings");
            this.hbox3.Add(this.button_applythrottle);
            Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.hbox3[this.button_applythrottle]));
            w27.Position = 1;
            w27.Expand = false;
            w27.Fill = false;
            this.vbox6.Add(this.hbox3);
            Gtk.Box.BoxChild w28 = ((Gtk.Box.BoxChild)(this.vbox6[this.hbox3]));
            w28.Position = 7;
            w28.Expand = false;
            w28.Fill = false;
            this.hbox1.Add(this.vbox6);
            Gtk.Box.BoxChild w29 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox6]));
            w29.Position = 1;
            this.notebook1.Add(this.hbox1);
            Gtk.Notebook.NotebookChild w30 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.hbox1]));
            w30.Position = 1;
            this.Add(this.notebook1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 362;
            this.Show();
            this.checkbutton_showtimestamps.Clicked += new System.EventHandler(this.OnCheckbuttonShowtimestampsClicked);
            this.checkbutton_hideminimise.Clicked += new System.EventHandler(this.OnCheckbuttonHideminimiseClicked);
            this.radiobutton1.Activated += new System.EventHandler(this.OnRadiobutton1Activated);
            this.radiobutton2.Activated += new System.EventHandler(this.OnRadiobutton2Activated);
            this.button_applythrottle.Clicked += new System.EventHandler(this.OnButtonApplythrottleClicked);
        }
    }
}
