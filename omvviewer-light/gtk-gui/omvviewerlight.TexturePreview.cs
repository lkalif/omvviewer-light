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
    
    
    public partial class TexturePreview {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label_title;
        
        private Gtk.Image image;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.TexturePreview
            this.Name = "omvviewerlight.TexturePreview";
            this.Title = Mono.Unix.Catalog.GetString("TexturePreview");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child omvviewerlight.TexturePreview.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label_title = new Gtk.Label();
            this.label_title.Name = "label_title";
            this.vbox1.Add(this.label_title);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.label_title]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.image = new Gtk.Image();
            this.image.Name = "image";
            this.vbox1.Add(this.image);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.image]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 300;
            this.Show();
        }
    }
}
