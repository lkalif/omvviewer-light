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
    
    
    public partial class LoginControl {
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label1;
        
        private Gtk.Label label2;
        
        private Gtk.Label label3;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Entry entry_first;
        
        private Gtk.Entry entry_last;
        
        private Gtk.Entry entry_pass;
        
        private Gtk.Button button_login;
        
        private Gtk.VBox vbox5;
        
        private Gtk.CheckButton checkbutton_rememberpass;
        
        private Gtk.HBox hbox2;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Label label4;
        
        private Gtk.Label label5;
        
        private Gtk.VBox vbox6;
        
        private Gtk.ComboBox combobox_grid;
        
        private Gtk.Entry entry_loginuri;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.TextView textview_loginmsg;
        
        private Gtk.Label GtkLabel2;
        
        private Gtk.Frame frame2;
        
        private Gtk.Alignment GtkAlignment1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow1;
        
        private Gtk.TextView textview_log;
        
        private Gtk.Label GtkLabel3;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.LoginControl
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.LoginControl";
            // Container child omvviewerlight.LoginControl.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Homogeneous = true;
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("First name");
            this.vbox2.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Last Name");
            this.vbox2.Add(this.label2);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.label2]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Password");
            this.vbox2.Add(this.label3);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.label3]));
            w3.Position = 2;
            w3.Expand = false;
            w3.Fill = false;
            this.hbox1.Add(this.vbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.entry_first = new Gtk.Entry();
            this.entry_first.CanFocus = true;
            this.entry_first.Name = "entry_first";
            this.entry_first.IsEditable = true;
            this.entry_first.InvisibleChar = '●';
            this.vbox3.Add(this.entry_first);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox3[this.entry_first]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.entry_last = new Gtk.Entry();
            this.entry_last.CanFocus = true;
            this.entry_last.Name = "entry_last";
            this.entry_last.IsEditable = true;
            this.entry_last.InvisibleChar = '●';
            this.vbox3.Add(this.entry_last);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox3[this.entry_last]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.entry_pass = new Gtk.Entry();
            this.entry_pass.CanFocus = true;
            this.entry_pass.Name = "entry_pass";
            this.entry_pass.IsEditable = true;
            this.entry_pass.InvisibleChar = '●';
            this.vbox3.Add(this.entry_pass);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox3[this.entry_pass]));
            w7.Position = 2;
            w7.Expand = false;
            w7.Fill = false;
            this.hbox1.Add(this.vbox3);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox3]));
            w8.Position = 1;
            // Container child hbox1.Gtk.Box+BoxChild
            this.button_login = new Gtk.Button();
            this.button_login.WidthRequest = 100;
            this.button_login.HeightRequest = 50;
            this.button_login.CanFocus = true;
            this.button_login.Name = "button_login";
            this.button_login.UseUnderline = true;
            this.button_login.Label = Mono.Unix.Catalog.GetString("Login");
            this.hbox1.Add(this.button_login);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox1[this.button_login]));
            w9.Position = 2;
            w9.Expand = false;
            w9.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w10.Position = 0;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.checkbutton_rememberpass = new Gtk.CheckButton();
            this.checkbutton_rememberpass.CanFocus = true;
            this.checkbutton_rememberpass.Name = "checkbutton_rememberpass";
            this.checkbutton_rememberpass.Label = Mono.Unix.Catalog.GetString("Remember password");
            this.checkbutton_rememberpass.DrawIndicator = true;
            this.checkbutton_rememberpass.UseUnderline = true;
            this.vbox5.Add(this.checkbutton_rememberpass);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox5[this.checkbutton_rememberpass]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Homogeneous = true;
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Connect to grid ");
            this.vbox4.Add(this.label4);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox4[this.label4]));
            w12.Position = 0;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Login URI");
            this.vbox4.Add(this.label5);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox4[this.label5]));
            w13.Position = 1;
            w13.Expand = false;
            w13.Fill = false;
            this.hbox2.Add(this.vbox4);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox2[this.vbox4]));
            w14.Position = 0;
            w14.Expand = false;
            w14.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.vbox6 = new Gtk.VBox();
            this.vbox6.Name = "vbox6";
            this.vbox6.Spacing = 6;
            // Container child vbox6.Gtk.Box+BoxChild
            this.combobox_grid = Gtk.ComboBox.NewText();
            this.combobox_grid.AppendText(Mono.Unix.Catalog.GetString("Agni"));
            this.combobox_grid.AppendText(Mono.Unix.Catalog.GetString("Atidi"));
            this.combobox_grid.AppendText(Mono.Unix.Catalog.GetString("Local"));
            this.combobox_grid.AppendText(Mono.Unix.Catalog.GetString("Custom"));
            this.combobox_grid.Name = "combobox_grid";
            this.combobox_grid.Active = 0;
            this.vbox6.Add(this.combobox_grid);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox6[this.combobox_grid]));
            w15.Position = 0;
            w15.Expand = false;
            w15.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.entry_loginuri = new Gtk.Entry();
            this.entry_loginuri.CanFocus = true;
            this.entry_loginuri.Name = "entry_loginuri";
            this.entry_loginuri.IsEditable = true;
            this.entry_loginuri.InvisibleChar = '●';
            this.vbox6.Add(this.entry_loginuri);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox6[this.entry_loginuri]));
            w16.Position = 1;
            w16.Expand = false;
            w16.Fill = false;
            this.hbox2.Add(this.vbox6);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.hbox2[this.vbox6]));
            w17.Position = 1;
            w17.Expand = false;
            w17.Fill = false;
            this.vbox5.Add(this.hbox2);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
            w18.Position = 1;
            w18.Expand = false;
            w18.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(12));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.textview_loginmsg = new Gtk.TextView();
            this.textview_loginmsg.HeightRequest = 10;
            this.textview_loginmsg.CanFocus = true;
            this.textview_loginmsg.Name = "textview_loginmsg";
            this.textview_loginmsg.Editable = false;
            this.GtkAlignment.Add(this.textview_loginmsg);
            this.frame1.Add(this.GtkAlignment);
            this.GtkLabel2 = new Gtk.Label();
            this.GtkLabel2.Name = "GtkLabel2";
            this.GtkLabel2.LabelProp = Mono.Unix.Catalog.GetString("<b>Login message</b>");
            this.GtkLabel2.UseMarkup = true;
            this.frame1.LabelWidget = this.GtkLabel2;
            this.vbox5.Add(this.frame1);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox5[this.frame1]));
            w21.Position = 2;
            // Container child vbox5.Gtk.Box+BoxChild
            this.frame2 = new Gtk.Frame();
            this.frame2.Name = "frame2";
            this.frame2.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame2.Gtk.Container+ContainerChild
            this.GtkAlignment1 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment1.Name = "GtkAlignment1";
            this.GtkAlignment1.LeftPadding = ((uint)(12));
            // Container child GtkAlignment1.Gtk.Container+ContainerChild
            this.GtkScrolledWindow1 = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
            this.GtkScrolledWindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
            this.textview_log = new Gtk.TextView();
            this.textview_log.HeightRequest = 350;
            this.textview_log.CanFocus = true;
            this.textview_log.Name = "textview_log";
            this.textview_log.Editable = false;
            this.textview_log.WrapMode = ((Gtk.WrapMode)(2));
            this.GtkScrolledWindow1.Add(this.textview_log);
            this.GtkAlignment1.Add(this.GtkScrolledWindow1);
            this.frame2.Add(this.GtkAlignment1);
            this.GtkLabel3 = new Gtk.Label();
            this.GtkLabel3.Name = "GtkLabel3";
            this.GtkLabel3.LabelProp = Mono.Unix.Catalog.GetString("<b>Debug log</b>");
            this.GtkLabel3.UseMarkup = true;
            this.frame2.LabelWidget = this.GtkLabel3;
            this.vbox5.Add(this.frame2);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.vbox5[this.frame2]));
            w25.Position = 3;
            this.vbox1.Add(this.vbox5);
            Gtk.Box.BoxChild w26 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbox5]));
            w26.Position = 1;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button_login.Clicked += new System.EventHandler(this.OnButton1Clicked);
            this.checkbutton_rememberpass.Clicked += new System.EventHandler(this.OnCheckbuttonRememberpassClicked);
        }
    }
}
