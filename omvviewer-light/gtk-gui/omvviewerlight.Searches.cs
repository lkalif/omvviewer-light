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
    
    
    public partial class Searches {
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Label label1;
        
        private Gtk.Entry entry1;
        
        private Gtk.Button button1;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Label label_info;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView treeview1;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Button button2;
        
        private Gtk.Button button_profile;
        
        private Gtk.Button button_pay;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Searches
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.Searches";
            // Container child omvviewerlight.Searches.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("FInd");
            this.hbox1.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.entry1 = new Gtk.Entry();
            this.entry1.CanFocus = true;
            this.entry1.Name = "entry1";
            this.entry1.IsEditable = true;
            this.entry1.InvisibleChar = '●';
            this.hbox1.Add(this.entry1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.entry1]));
            w2.Position = 1;
            // Container child hbox1.Gtk.Box+BoxChild
            this.button1 = new Gtk.Button();
            this.button1.CanFocus = true;
            this.button1.Name = "button1";
            this.button1.UseUnderline = true;
            this.button1.Label = Mono.Unix.Catalog.GetString("Search");
            this.hbox1.Add(this.button1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.button1]));
            w3.Position = 2;
            w3.Expand = false;
            w3.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.label_info = new Gtk.Label();
            this.label_info.Name = "label_info";
            this.label_info.LabelProp = Mono.Unix.Catalog.GetString("Type in a name and press search to begin");
            this.hbox2.Add(this.label_info);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.label_info]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            this.vbox1.Add(this.hbox2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.treeview1 = new Gtk.TreeView();
            this.treeview1.CanFocus = true;
            this.treeview1.Name = "treeview1";
            this.treeview1.HeadersClickable = true;
            this.GtkScrolledWindow.Add(this.treeview1);
            this.vbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
            w8.Position = 2;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.button2 = new Gtk.Button();
            this.button2.CanFocus = true;
            this.button2.Name = "button2";
            this.button2.UseUnderline = true;
            this.button2.Label = Mono.Unix.Catalog.GetString("IM");
            this.hbox3.Add(this.button2);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox3[this.button2]));
            w9.Position = 0;
            w9.Expand = false;
            w9.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.button_profile = new Gtk.Button();
            this.button_profile.CanFocus = true;
            this.button_profile.Name = "button_profile";
            this.button_profile.UseUnderline = true;
            this.button_profile.Label = Mono.Unix.Catalog.GetString("Profile");
            this.hbox3.Add(this.button_profile);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.hbox3[this.button_profile]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.button_pay = new Gtk.Button();
            this.button_pay.CanFocus = true;
            this.button_pay.Name = "button_pay";
            this.button_pay.UseUnderline = true;
            this.button_pay.Label = Mono.Unix.Catalog.GetString("Pay");
            this.hbox3.Add(this.button_pay);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox3[this.button_pay]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            this.vbox1.Add(this.hbox3);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
            w12.Position = 3;
            w12.Expand = false;
            w12.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.button1.Clicked += new System.EventHandler(this.OnButton1Clicked);
            this.button2.Clicked += new System.EventHandler(this.OnButton2Clicked);
            this.button_profile.Clicked += new System.EventHandler(this.OnButtonProfileClicked);
            this.button_pay.Clicked += new System.EventHandler(this.OnButtonPayClicked);
        }
    }
}
