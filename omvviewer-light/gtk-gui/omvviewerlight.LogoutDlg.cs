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
    
    
    public partial class LogoutDlg {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label1;
        
        private Gtk.ProgressBar progressbar1;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.LogoutDlg
            this.Name = "omvviewerlight.LogoutDlg";
            this.Title = Mono.Unix.Catalog.GetString("Loging out");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.HasSeparator = false;
            // Internal child omvviewerlight.LogoutDlg.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Ypad = 8;
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Please wait, the system is attemping\nto log you out now, this may take a\nfew seconds.\n\nTo abort waiting, press Cancel at any\ntime");
            this.vbox2.Add(this.label1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.label1]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.progressbar1 = new Gtk.ProgressBar();
            this.progressbar1.Name = "progressbar1";
            this.vbox2.Add(this.progressbar1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.progressbar1]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Internal child omvviewerlight.LogoutDlg.ActionArea
            Gtk.HButtonBox w5 = this.ActionArea;
            w5.Name = "dialog1_ActionArea";
            w5.Spacing = 6;
            w5.BorderWidth = ((uint)(5));
            w5.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonOk, -6);
            Gtk.ButtonBox.ButtonBoxChild w6 = ((Gtk.ButtonBox.ButtonBoxChild)(w5[this.buttonOk]));
            w6.Expand = false;
            w6.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 205;
            this.Show();
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
