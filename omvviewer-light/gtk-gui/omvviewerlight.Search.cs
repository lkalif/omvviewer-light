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
    
    
    public partial class Search {
        
        private Gtk.Notebook notebook1;
        
        private omvviewerlight.Searches searches1;
        
        private Gtk.Label label2;
        
        private omvviewerlight.PlacesSearch placessearch1;
        
        private Gtk.Label label5;
        
        private Gtk.Label label4;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.Search
            Stetic.BinContainer.Attach(this);
            this.Name = "omvviewerlight.Search";
            // Container child omvviewerlight.Search.Gtk.Container+ContainerChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 1;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.searches1 = new omvviewerlight.Searches();
            this.searches1.Events = ((Gdk.EventMask)(256));
            this.searches1.Name = "searches1";
            this.notebook1.Add(this.searches1);
            // Notebook tab
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("People");
            this.notebook1.SetTabLabel(this.searches1, this.label2);
            this.label2.ShowAll();
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.placessearch1 = new omvviewerlight.PlacesSearch();
            this.placessearch1.Events = ((Gdk.EventMask)(256));
            this.placessearch1.Name = "placessearch1";
            this.notebook1.Add(this.placessearch1);
            Gtk.Notebook.NotebookChild w2 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.placessearch1]));
            w2.Position = 1;
            // Notebook tab
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Places");
            this.notebook1.SetTabLabel(this.placessearch1, this.label5);
            this.label5.ShowAll();
            // Notebook tab
            Gtk.Label w3 = new Gtk.Label();
            w3.Visible = true;
            this.notebook1.Add(w3);
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Events");
            this.notebook1.SetTabLabel(w3, this.label4);
            this.label4.ShowAll();
            this.Add(this.notebook1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
