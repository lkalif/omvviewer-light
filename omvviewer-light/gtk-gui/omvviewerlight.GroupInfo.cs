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
    
    
    public partial class GroupInfo {
        
        private Gtk.Notebook notebook1;
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label_name;
        
        private Gtk.Label label_foundedby;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Image image_group_emblem;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TextView textview_group_charter;
        
        private Gtk.ScrolledWindow GtkScrolledWindow1;
        
        private Gtk.TreeView treeview_members;
        
        private Gtk.HBox hbox2;
        
        private Gtk.VBox vbox3;
        
        private Gtk.CheckButton checkbutton_showinsearch;
        
        private Gtk.CheckButton checkbutton_openenrolement;
        
        private Gtk.HBox hbox3;
        
        private Gtk.CheckButton checkbutton_enrolmentfee;
        
        private Gtk.Entry entry_enrollmentfee;
        
        private Gtk.ComboBox combobox_mature;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label_active_title;
        
        private Gtk.ComboBox combobox_active_title;
        
        private Gtk.CheckButton checkbutton_group_notices;
        
        private Gtk.CheckButton checkbutton_showinpofile;
        
        private Gtk.Label label1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.GroupInfo
            this.Name = "omvviewerlight.GroupInfo";
            this.Title = Mono.Unix.Catalog.GetString("GroupInfo");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child omvviewerlight.GroupInfo.Gtk.Container+ContainerChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 0;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_name = new Gtk.Label();
            this.label_name.Name = "label_name";
            this.label_name.LabelProp = Mono.Unix.Catalog.GetString("label2");
            this.vbox1.Add(this.label_name);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_name]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_foundedby = new Gtk.Label();
            this.label_foundedby.Name = "label_foundedby";
            this.label_foundedby.LabelProp = Mono.Unix.Catalog.GetString("label3");
            this.vbox1.Add(this.label_foundedby);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_foundedby]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.image_group_emblem = new Gtk.Image();
            this.image_group_emblem.WidthRequest = 128;
            this.image_group_emblem.HeightRequest = 128;
            this.image_group_emblem.Name = "image_group_emblem";
            this.hbox1.Add(this.image_group_emblem);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.image_group_emblem]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.textview_group_charter = new Gtk.TextView();
            this.textview_group_charter.CanFocus = true;
            this.textview_group_charter.Name = "textview_group_charter";
            this.textview_group_charter.Editable = false;
            this.textview_group_charter.WrapMode = ((Gtk.WrapMode)(2));
            this.GtkScrolledWindow.Add(this.textview_group_charter);
            this.hbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
            w5.Position = 1;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w6.Position = 2;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow1 = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
            this.GtkScrolledWindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
            this.treeview_members = new Gtk.TreeView();
            this.treeview_members.CanFocus = true;
            this.treeview_members.Name = "treeview_members";
            this.treeview_members.HeadersClickable = true;
            this.GtkScrolledWindow1.Add(this.treeview_members);
            this.vbox1.Add(this.GtkScrolledWindow1);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow1]));
            w8.Position = 3;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.checkbutton_showinsearch = new Gtk.CheckButton();
            this.checkbutton_showinsearch.CanFocus = true;
            this.checkbutton_showinsearch.Name = "checkbutton_showinsearch";
            this.checkbutton_showinsearch.Label = Mono.Unix.Catalog.GetString("Show in search");
            this.checkbutton_showinsearch.DrawIndicator = true;
            this.checkbutton_showinsearch.UseUnderline = true;
            this.vbox3.Add(this.checkbutton_showinsearch);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox3[this.checkbutton_showinsearch]));
            w9.Position = 0;
            w9.Expand = false;
            w9.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.checkbutton_openenrolement = new Gtk.CheckButton();
            this.checkbutton_openenrolement.CanFocus = true;
            this.checkbutton_openenrolement.Name = "checkbutton_openenrolement";
            this.checkbutton_openenrolement.Label = Mono.Unix.Catalog.GetString("Open enrolement");
            this.checkbutton_openenrolement.DrawIndicator = true;
            this.checkbutton_openenrolement.UseUnderline = true;
            this.vbox3.Add(this.checkbutton_openenrolement);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox3[this.checkbutton_openenrolement]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.checkbutton_enrolmentfee = new Gtk.CheckButton();
            this.checkbutton_enrolmentfee.CanFocus = true;
            this.checkbutton_enrolmentfee.Name = "checkbutton_enrolmentfee";
            this.checkbutton_enrolmentfee.Label = Mono.Unix.Catalog.GetString("Enrollment fee");
            this.checkbutton_enrolmentfee.DrawIndicator = true;
            this.checkbutton_enrolmentfee.UseUnderline = true;
            this.hbox3.Add(this.checkbutton_enrolmentfee);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox3[this.checkbutton_enrolmentfee]));
            w11.Position = 0;
            // Container child hbox3.Gtk.Box+BoxChild
            this.entry_enrollmentfee = new Gtk.Entry();
            this.entry_enrollmentfee.CanFocus = true;
            this.entry_enrollmentfee.Name = "entry_enrollmentfee";
            this.entry_enrollmentfee.IsEditable = true;
            this.entry_enrollmentfee.MaxLength = 5;
            this.entry_enrollmentfee.InvisibleChar = '●';
            this.hbox3.Add(this.entry_enrollmentfee);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox3[this.entry_enrollmentfee]));
            w12.Position = 1;
            this.vbox3.Add(this.hbox3);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbox3]));
            w13.Position = 2;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.combobox_mature = Gtk.ComboBox.NewText();
            this.combobox_mature.Name = "combobox_mature";
            this.vbox3.Add(this.combobox_mature);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox3[this.combobox_mature]));
            w14.Position = 3;
            w14.Expand = false;
            w14.Fill = false;
            this.hbox2.Add(this.vbox3);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.hbox2[this.vbox3]));
            w15.Position = 0;
            w15.Expand = false;
            w15.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label_active_title = new Gtk.Label();
            this.label_active_title.Name = "label_active_title";
            this.label_active_title.LabelProp = Mono.Unix.Catalog.GetString("My active title");
            this.vbox2.Add(this.label_active_title);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox2[this.label_active_title]));
            w16.Position = 0;
            w16.Expand = false;
            w16.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.combobox_active_title = Gtk.ComboBox.NewText();
            this.combobox_active_title.Name = "combobox_active_title";
            this.vbox2.Add(this.combobox_active_title);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox2[this.combobox_active_title]));
            w17.Position = 1;
            w17.Expand = false;
            w17.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.checkbutton_group_notices = new Gtk.CheckButton();
            this.checkbutton_group_notices.CanFocus = true;
            this.checkbutton_group_notices.Name = "checkbutton_group_notices";
            this.checkbutton_group_notices.Label = Mono.Unix.Catalog.GetString("Recieve notices");
            this.checkbutton_group_notices.DrawIndicator = true;
            this.checkbutton_group_notices.UseUnderline = true;
            this.vbox2.Add(this.checkbutton_group_notices);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox2[this.checkbutton_group_notices]));
            w18.Position = 2;
            w18.Expand = false;
            w18.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.checkbutton_showinpofile = new Gtk.CheckButton();
            this.checkbutton_showinpofile.CanFocus = true;
            this.checkbutton_showinpofile.Name = "checkbutton_showinpofile";
            this.checkbutton_showinpofile.Label = Mono.Unix.Catalog.GetString("Show in profile");
            this.checkbutton_showinpofile.DrawIndicator = true;
            this.checkbutton_showinpofile.UseUnderline = true;
            this.vbox2.Add(this.checkbutton_showinpofile);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.vbox2[this.checkbutton_showinpofile]));
            w19.Position = 3;
            w19.Expand = false;
            w19.Fill = false;
            this.hbox2.Add(this.vbox2);
            Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.hbox2[this.vbox2]));
            w20.Position = 1;
            w20.Expand = false;
            w20.Fill = false;
            this.vbox1.Add(this.hbox2);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
            w21.Position = 4;
            w21.Expand = false;
            w21.Fill = false;
            this.notebook1.Add(this.vbox1);
            // Notebook tab
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("General");
            this.notebook1.SetTabLabel(this.vbox1, this.label1);
            this.label1.ShowAll();
            this.Add(this.notebook1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 423;
            this.DefaultHeight = 440;
            this.Show();
        }
    }
}
