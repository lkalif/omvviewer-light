// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.VBox vbox6;
    
    private Gtk.MenuBar menubar1;
    
    private Gtk.Notebook notebook;
    
    private omvviewerlight.LoginControl logincontrol5;
    
    private Gtk.Label label5;
    
    private Gtk.HBox hbox5;
    
    private omvviewerlight.FriendsList friendslist1;
    
    private omvviewerlight.ChatConsole chatconsole1;
    
    private omvviewerlight.Radar radar1;
    
    private Gtk.Label label6;
    
    private Gtk.HBox hbox6;
    
    private omvviewerlight.TeleportTo teleportto1;
    
    private Gtk.Label label7;
    
    private Gtk.Statusbar statusbar1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        Gtk.UIManager w1 = new Gtk.UIManager();
        Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
        w1.InsertActionGroup(w2, 0);
        this.AddAccelGroup(w1.AccelGroup);
        this.WidthRequest = 800;
        this.HeightRequest = 600;
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox6 = new Gtk.VBox();
        this.vbox6.Name = "vbox6";
        this.vbox6.Spacing = 6;
        // Container child vbox6.Gtk.Box+BoxChild
        w1.AddUiFromString("<ui><menubar name='menubar1'/></ui>");
        this.menubar1 = ((Gtk.MenuBar)(w1.GetWidget("/menubar1")));
        this.menubar1.Name = "menubar1";
        this.vbox6.Add(this.menubar1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox6[this.menubar1]));
        w3.Position = 0;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox6.Gtk.Box+BoxChild
        this.notebook = new Gtk.Notebook();
        this.notebook.CanFocus = true;
        this.notebook.Name = "notebook";
        this.notebook.CurrentPage = 2;
        // Container child notebook.Gtk.Notebook+NotebookChild
        this.logincontrol5 = new omvviewerlight.LoginControl();
        this.logincontrol5.Events = ((Gdk.EventMask)(256));
        this.logincontrol5.Name = "logincontrol5";
        this.notebook.Add(this.logincontrol5);
        // Notebook tab
        this.label5 = new Gtk.Label();
        this.label5.Name = "label5";
        this.label5.LabelProp = Mono.Unix.Catalog.GetString("Login");
        this.notebook.SetTabLabel(this.logincontrol5, this.label5);
        this.label5.ShowAll();
        // Container child notebook.Gtk.Notebook+NotebookChild
        this.hbox5 = new Gtk.HBox();
        this.hbox5.Name = "hbox5";
        this.hbox5.Spacing = 6;
        // Container child hbox5.Gtk.Box+BoxChild
        this.friendslist1 = new omvviewerlight.FriendsList();
        this.friendslist1.Events = ((Gdk.EventMask)(256));
        this.friendslist1.Name = "friendslist1";
        this.hbox5.Add(this.friendslist1);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox5[this.friendslist1]));
        w5.Position = 0;
        w5.Expand = false;
        w5.Fill = false;
        // Container child hbox5.Gtk.Box+BoxChild
        this.chatconsole1 = new omvviewerlight.ChatConsole();
        this.chatconsole1.Events = ((Gdk.EventMask)(256));
        this.chatconsole1.Name = "chatconsole1";
        this.hbox5.Add(this.chatconsole1);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox5[this.chatconsole1]));
        w6.Position = 1;
        // Container child hbox5.Gtk.Box+BoxChild
        this.radar1 = new omvviewerlight.Radar();
        this.radar1.Events = ((Gdk.EventMask)(256));
        this.radar1.Name = "radar1";
        this.hbox5.Add(this.radar1);
        Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox5[this.radar1]));
        w7.Position = 2;
        w7.Expand = false;
        w7.Fill = false;
        this.notebook.Add(this.hbox5);
        Gtk.Notebook.NotebookChild w8 = ((Gtk.Notebook.NotebookChild)(this.notebook[this.hbox5]));
        w8.Position = 1;
        // Notebook tab
        this.label6 = new Gtk.Label();
        this.label6.Name = "label6";
        this.label6.LabelProp = Mono.Unix.Catalog.GetString("page2");
        this.notebook.SetTabLabel(this.hbox5, this.label6);
        this.label6.ShowAll();
        // Container child notebook.Gtk.Notebook+NotebookChild
        this.hbox6 = new Gtk.HBox();
        this.hbox6.Name = "hbox6";
        this.hbox6.Spacing = 6;
        // Container child hbox6.Gtk.Box+BoxChild
        this.teleportto1 = new omvviewerlight.TeleportTo();
        this.teleportto1.Events = ((Gdk.EventMask)(256));
        this.teleportto1.Name = "teleportto1";
        this.hbox6.Add(this.teleportto1);
        Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox6[this.teleportto1]));
        w9.Position = 1;
        w9.Expand = false;
        w9.Fill = false;
        this.notebook.Add(this.hbox6);
        Gtk.Notebook.NotebookChild w10 = ((Gtk.Notebook.NotebookChild)(this.notebook[this.hbox6]));
        w10.Position = 2;
        // Notebook tab
        this.label7 = new Gtk.Label();
        this.label7.Name = "label7";
        this.label7.LabelProp = Mono.Unix.Catalog.GetString("page3");
        this.notebook.SetTabLabel(this.hbox6, this.label7);
        this.label7.ShowAll();
        this.vbox6.Add(this.notebook);
        Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox6[this.notebook]));
        w11.Position = 1;
        // Container child vbox6.Gtk.Box+BoxChild
        this.statusbar1 = new Gtk.Statusbar();
        this.statusbar1.Name = "statusbar1";
        this.statusbar1.Spacing = 6;
        this.vbox6.Add(this.statusbar1);
        Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox6[this.statusbar1]));
        w12.Position = 3;
        w12.Expand = false;
        w12.Fill = false;
        this.Add(this.vbox6);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 812;
        this.DefaultHeight = 629;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
    }
}
