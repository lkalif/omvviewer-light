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
    
    
    public partial class GroupChatList {
        
        private Gtk.VBox vbox3;
        
        private Gtk.Label label1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView treeview_members;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget omvviewerlight.GroupChatList
            Stetic.BinContainer.Attach(this);
            this.WidthRequest = 150;
            this.Name = "omvviewerlight.GroupChatList";
            // Container child omvviewerlight.GroupChatList.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Group chat members");
            this.vbox3.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox3[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.treeview_members = new Gtk.TreeView();
            this.treeview_members.WidthRequest = 150;
            this.treeview_members.CanFocus = true;
            this.treeview_members.Name = "treeview_members";
            this.GtkScrolledWindow.Add(this.treeview_members);
            this.vbox3.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox3[this.GtkScrolledWindow]));
            w3.Position = 1;
            this.Add(this.vbox3);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
