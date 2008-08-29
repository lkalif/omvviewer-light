/*
omvviewer-light a Text based client to metaverses such as Linden Labs Secondlife(tm)
    Copyright (C) 2008  Robin Cornelius <robin.cornelius@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

// Inventory.cs created with MonoDevelop
// User: robin at 20:08 19/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Threading;
using libsecondlife;
using System.Collections.Generic;
using Gdk;
using Gtk;

namespace omvviewerlight
{

	public partial class Inventory : Gtk.Bin
	{

        Dictionary<LLUUID, Gtk.TreeIter> assetmap = new Dictionary<LLUUID, Gtk.TreeIter>();
		String[] SearchFolders = { "" };
		//initialize our list to store the folder contents
        LLUUID inventoryItems;
		Gtk.TreeStore inventory = new Gtk.TreeStore (typeof(Gdk.Pixbuf),typeof (string), typeof (LLUUID),typeof(InventoryBase));		
		Gdk.Pixbuf folder_closed = new Gdk.Pixbuf("inv_folder_plain_closed.tga");
		Gdk.Pixbuf folder_open = new Gdk.Pixbuf("inv_folder_plain_open.tga");
		Gdk.Pixbuf item_landmark = new Gdk.Pixbuf("inv_item_landmark.tga");
		Gdk.Pixbuf item_animation = new Gdk.Pixbuf("inv_item_animation.tga");
		Gdk.Pixbuf item_clothing = new Gdk.Pixbuf("inv_item_clothing.tga");
        Gdk.Pixbuf item_object = new Gdk.Pixbuf("inv_item_object.tga");
        Gdk.Pixbuf item_gesture = new Gdk.Pixbuf("inv_item_gesture.tga");
        Gdk.Pixbuf item_notecard = new Gdk.Pixbuf("inv_item_notecard.tga");
        Gdk.Pixbuf item_script = new Gdk.Pixbuf("inv_item_script.tga");
        Gdk.Pixbuf item_snapshot = new Gdk.Pixbuf("inv_item_snapshot.tga");
        Gdk.Pixbuf item_sound = new Gdk.Pixbuf("inv_item_sound.tga");
        Gdk.Pixbuf item_callingcard = new Gdk.Pixbuf("inv_item_callingcard_offline.tga");

        Gdk.Pixbuf folder_texture = new Gdk.Pixbuf("inv_folder_texture.tga");
        Gdk.Pixbuf folder_sound = new Gdk.Pixbuf("inv_folder_sound.tga");
        Gdk.Pixbuf folder_animation = new Gdk.Pixbuf("inv_folder_animation.tga");
        Gdk.Pixbuf folder_gesture = new Gdk.Pixbuf("inv_folder_gesture.tga");
        Gdk.Pixbuf folder_snapshot = new Gdk.Pixbuf("inv_folder_snapshot.tga");
        Gdk.Pixbuf folder_trash = new Gdk.Pixbuf("inv_folder_trash.tga");
        Gdk.Pixbuf folder_notecard = new Gdk.Pixbuf("inv_folder_notecard.tga");
        Gdk.Pixbuf folder_script = new Gdk.Pixbuf("inv_folder_script.tga");
        Gdk.Pixbuf folder_lostandfound = new Gdk.Pixbuf("inv_folder_lostandfound.tga");
        Gdk.Pixbuf folder_landmark = new Gdk.Pixbuf("inv_folder_landmark.tga");
        Gdk.Pixbuf folder_bodypart = new Gdk.Pixbuf("inv_folder_bodypart.tga");
        Gdk.Pixbuf folder_callingcard = new Gdk.Pixbuf("inv_folder_callingcard.tga");
        Gdk.Pixbuf folder_clothing = new Gdk.Pixbuf("inv_folder_clothing.tga");

	
		
		
		public Inventory()
		{
			this.Build();		
			treeview_inv.AppendColumn("",new CellRendererPixbuf(),"pixbuf",0);
			treeview_inv.AppendColumn("Name",new  Gtk.CellRendererText(),"text",1);
			treeview_inv.Model=inventory;
			this.treeview_inv.RowExpanded += new Gtk.RowExpandedHandler(onRowExpanded);
			this.treeview_inv.RowCollapsed += new Gtk.RowCollapsedHandler(onRowCollapsed);
			MainClass.client.Network.OnLogin += new libsecondlife.NetworkManager.LoginCallback(onLogin);
            this.treeview_inv.ButtonPressEvent += new ButtonPressEventHandler(treeview_inv_ButtonPressEvent);

          MainClass.client.Inventory.OnObjectOffered += new InventoryManager.ObjectOfferedCallback(Inventory_OnObjectOffered);
  
          
			this.label_aquired.Text="";
			this.label_createdby.Text="";
			this.label_name.Text="";
			this.label_group.Text="";
			this.label_saleprice.Text="";
		}

        void menu_ware_ButtonPressEvent(object o, ButtonPressEventArgs args)
        {
            Gtk.TreeModel mod;
            Gtk.TreeIter iter;
            this.treeview_inv.Selection.GetSelected(out mod, out iter);
            InventoryBase item = (InventoryBase)mod.GetValue(iter, 3);

            if (item is InventoryFolder)
            {
                MainClass.client.Appearance.WearOutfit(item.UUID,true);
            }

           // MainClass.client.Appearance.Attach(

        }
		
		void ondeleteasset(object o, ButtonPressEventArgs args)
		{
			Gtk.TreeModel mod;
            Gtk.TreeIter iter;
            this.treeview_inv.Selection.GetSelected(out mod, out iter);
            InventoryBase item = (InventoryBase)mod.GetValue(iter, 3);
			
			if(item is InventoryItem)
			{			
				MessageDialog md = new MessageDialog(MainClass.win,DialogFlags.Modal,MessageType.Question,ButtonsType.YesNo,"Are you sure you wish to delete\n"+((InventoryItem)item).Name+"to ");
				ResponseType result=(ResponseType)md.Run();	
				if(result==ResponseType.Yes)
				{
					md.Destroy();
					MainClass.client.Inventory.RemoveItem(item.UUID);
					return;
				}
					md.Destroy();				
			}
		}
		
		void ongiveasset(object o, ButtonPressEventArgs args)
		{
			Gtk.TreeModel mod;
            Gtk.TreeIter iter;
            this.treeview_inv.Selection.GetSelected(out mod, out iter);
            InventoryBase item = (InventoryBase)mod.GetValue(iter, 3);
			NamePicker np = new NamePicker();
			
			if(item is InventoryItem)
				np.item_name=((InventoryItem)item).Name;
					
			np.asset=item.UUID;
			
			np.UserSel += new NamePicker.UserSelected(ongiveasset2);
			np.Show();
			
		}
		
		void ongiveasset2(LLUUID id,LLUUID asset,string item_name,string user_name)
		{
			MessageDialog md = new MessageDialog(MainClass.win,DialogFlags.Modal,MessageType.Question,ButtonsType.YesNo,"Are you sure you wish to give\n"+item_name+"to "+user_name);
			ResponseType result=(ResponseType)md.Run();	
			md.Destroy();
			
			if(result==ResponseType.Yes)
			{
				MainClass.client.Inventory.GiveItem(asset,item_name,AssetType.Landmark,id,false);
			}
		}
		
        void Inventory_OnTaskItemReceived(LLUUID itemID, LLUUID folderID, LLUUID creatorID, LLUUID assetID, InventoryType type)
        {

            Console.Write("\nOn Task Item Recieved\n");
        }

        void Inventory_OnTaskInventoryReply(LLUUID itemID, short serial, string assetFilename)
        {
            Console.Write("\nOn Task Inventory Reply\n");
        }

        void Inventory_OnFolderUpdated(LLUUID folderID)
        {
            
        }

        bool Inventory_OnObjectOffered(InstantMessage offerDetails, AssetType type, LLUUID objectID, bool fromTask)
        {
			
			AutoResetEvent ObjectOfferEvent = new AutoResetEvent(false);
			ResponseType object_offer_result=ResponseType.Yes;

            string msg = "";
			ResponseType result;
            if (!fromTask)
                msg = "The user "+offerDetails.FromAgentName + " has offered you\n" + offerDetails.Message + "\n Which is a " + type.ToString() + "\nPress Yes to accept or no to decline";
            else
                msg = "The object "+offerDetails.FromAgentName + " has offered you\n" + offerDetails.Message + "\n Which is a " + type.ToString() + "\nPress Yes to accept or no to decline";

			
			Application.Invoke(delegate {			
					ObjectOfferEvent.Reset();

					Gtk.MessageDialog md = new MessageDialog(MainClass.win, DialogFlags.Modal, MessageType.Other, ButtonsType.YesNo, false, msg);
				
					result = (ResponseType)md.Run();
					object_offer_result=result;
				    md.Destroy();
					ObjectOfferEvent.Set();
			});
			
			
		    ObjectOfferEvent.WaitOne(1000*3600,false);
	
           if (object_offer_result == ResponseType.Yes)
		   {
				return true;
		   }
		   else
		{
			    return false;
			}			
        }

        void Teleporttolandmark(object o, ButtonPressEventArgs args)
        {
            Gtk.TreeModel mod;
            Gtk.TreeIter iter;
            this.treeview_inv.Selection.GetSelected(out mod, out iter);
            TeleportProgress tp = new TeleportProgress();
            tp.Show();
            InventoryLandmark item = (InventoryLandmark)mod.GetValue(iter, 3);

            tp.teleportassetid(item.AssetUUID,item.Name);
			//MainClass.client.Self.Teleport(item.AssetUUID);
        }

      
        [GLib.ConnectBefore]
        void treeview_inv_ButtonPressEvent(object o, ButtonPressEventArgs args)
        {
            if (args.Event.Button == 3)//Fuck this should be a define
            {
                // Do the context sensitive stuff here
                // Detect type of asset selected and show an approprate menu
                // maybe
                Gtk.TreeModel mod;
			    Gtk.TreeIter iter;

               
                if (this.treeview_inv.Selection.GetSelected(out mod, out iter))
                {   
					if(mod.GetValue(iter,3)!=null)
                    {
                        Gtk.Menu menu = new Gtk.Menu();
    
                        InventoryBase item = (InventoryBase)mod.GetValue(iter, 3);

                        if(item is InventoryLandmark)
                        {
                            Gtk.MenuItem menu_tp_lm = new MenuItem("Teleport to Landmark");
                            menu_tp_lm.ButtonPressEvent += new ButtonPressEventHandler(Teleporttolandmark);
                            menu.Append(menu_tp_lm);
                        }
                       
                        if (item is InventoryFolder)
                        {
                            Gtk.MenuItem menu_wear_folder = new MenuItem("Wear folder contents");
                            Gtk.MenuItem menu_give_folder = new MenuItem("Give item to user");
                            Gtk.MenuItem menu_delete_folder = new MenuItem("Delete folder ");
                            
                            menu_delete_folder.ButtonPressEvent += new ButtonPressEventHandler(ondeleteasset);
                            menu_give_folder.ButtonPressEvent += new ButtonPressEventHandler(ongiveasset);
                            menu_wear_folder.ButtonPressEvent += new ButtonPressEventHandler(menu_ware_ButtonPressEvent);
                            
                            menu.Append(menu_wear_folder);
                            menu.Append(menu_give_folder);
                            menu.Append(menu_delete_folder);
                        }

                        if(item is InventoryItem)
                        {
                            Gtk.MenuItem menu_give_item = new MenuItem("Give item to user");
                            Gtk.MenuItem menu_attach_item = new MenuItem("Attach (default pos)");
                            Gtk.MenuItem menu_delete_item = new MenuItem("Delete folder ");

                            menu_give_item.ButtonPressEvent += new ButtonPressEventHandler(ongiveasset);
                            menu_delete_item.ButtonPressEvent += new ButtonPressEventHandler(ondeleteasset);
                            menu_attach_item.ButtonPressEvent += new ButtonPressEventHandler(menu_attach_item_ButtonPressEvent);

                            menu.Append(menu_give_item);
                            menu.Append(menu_attach_item);
                            menu.Append(menu_delete_item);
                        }

                        menu.Popup();
                        menu.ShowAll();
                    }
                }
            }
        }

        void menu_attach_item_ButtonPressEvent(object o, ButtonPressEventArgs args)
        {
            Gtk.TreeModel mod;
            Gtk.TreeIter iter;
            this.treeview_inv.Selection.GetSelected(out mod, out iter);
            InventoryBase item = (InventoryBase)mod.GetValue(iter, 3);
            MainClass.client.Appearance.Attach((InventoryItem)item, AttachmentPoint.Default);
        }

        void onLogin(LoginStatus status, string message)
		{
			if(LoginStatus.Success==status)
			{
				Gtk.Application.Invoke(delegate {
					inventory.Clear();
					Gtk.TreeIter iter = inventory.AppendValues(folder_closed,"Inventory", MainClass.client.Inventory.Store.RootFolder.UUID);
					inventory.AppendValues(iter,folder_closed, "Waiting...", MainClass.client.Inventory.Store.RootFolder.UUID,null);		
				});
			}
		}
				
		void onRowCollapsed(object o,Gtk.RowCollapsedArgs args)
		{
			LLUUID key=(LLUUID)this.inventory.GetValue(args.Iter,2);
			inventory.SetValue(args.Iter,0,folder_closed);
		}

		void onRowExpanded(object o,Gtk.RowExpandedArgs args)
		{
			LLUUID key=(LLUUID)this.inventory.GetValue(args.Iter,2);
			if(inventory.GetValue(args.Iter,0)==folder_closed)
                inventory.SetValue(args.Iter,0,folder_open);

            Gtk.TreePath path = args.Path;
            path.Down();
            Gtk.TreeIter childiter;
            Console.Write("Trying to get child iter\n");

            this.treeview_inv.QueueDraw();
            
			MainClass.client.Inventory.RequestFolderContents(key, MainClass.client.Self.AgentID, true, true, InventorySortOrder.ByDate);
			List<InventoryBase> myObjects  =MainClass.client.Inventory.FolderContents(key,MainClass.client.Self.AgentID,true,true,InventorySortOrder.ByDate,30000);
			
	     
			if (myObjects == null)
				return;

			foreach (InventoryBase item in myObjects)
			{

                if(assetmap.ContainsKey(item.UUID))
                    continue;

				Gdk.Pixbuf buf=getprettyicon(item);
				Gtk.TreeIter iter2 = inventory.AppendValues(args.Iter,buf, item.Name, item.UUID,item);
                assetmap.Add(item.UUID, iter2);

				if (item is InventoryFolder)
				{ 
					inventory.AppendValues(iter2, item_object,"Waiting...", LLUUID.Zero,null);	
				}
			}

            //And tidy that waiting
            if (inventory.GetIter(out childiter, path))
            {
                Console.Write("We got a childiter for that\n");
                Console.Write("Value is =" + (string)inventory.GetValue(childiter, 1) + "\n");
                if ("Waiting..." == (string)inventory.GetValue(childiter, 1))
                    inventory.Remove(ref childiter);
            }

		}

        Gdk.Pixbuf getprettyfoldericon(InventoryFolder item)
        {
            // Assume this is a InventoryFolder
            if (item.PreferredType == AssetType.Animation)
                return this.folder_animation;

            if (item.PreferredType == AssetType.Gesture)
                return this.folder_gesture;

            if (item.PreferredType == AssetType.Sound)
                return this.folder_sound;

            if (item.PreferredType == AssetType.Texture)
                return this.folder_texture;

            if (item.PreferredType == AssetType.SnapshotFolder)
                return this.folder_snapshot;

            if(item.PreferredType == AssetType.TrashFolder)
                return this.folder_trash;

            if (item.PreferredType == AssetType.Notecard)
                return this.folder_notecard;

            if (item.PreferredType == AssetType.LSLText || item.PreferredType == AssetType.LSLBytecode)
                return this.folder_script;

            if (item.PreferredType == AssetType.LostAndFoundFolder)
                return this.folder_lostandfound;

            if (item.PreferredType == AssetType.Landmark)
                return this.folder_landmark;

            if (item.PreferredType == AssetType.Bodypart)
                return this.folder_bodypart;

            if (item.PreferredType == AssetType.CallingCard)
                return this.folder_callingcard;

            if (item.PreferredType == AssetType.Clothing)
                return this.folder_clothing;

            return folder_closed;
        }

		Gdk.Pixbuf getprettyicon(InventoryBase item)
		{
            if (item is InventoryFolder)
                return getprettyfoldericon((InventoryFolder)item);
					
			if(item is libsecondlife.InventoryLandmark)
				return this.item_landmark;
			
			if(item is libsecondlife.InventoryAnimation)
				return this.item_animation;
			
			if(item is libsecondlife.InventoryWearable)
				return this.item_clothing;

            if (item is libsecondlife.InventoryGesture)
                return this.item_gesture;

            if (item is libsecondlife.InventoryNotecard)
                return this.item_notecard;

            if (item is libsecondlife.InventoryLSL)
                return this.item_script;

            if (item is libsecondlife.InventorySnapshot)
                return this.item_snapshot;

            if (item is libsecondlife.InventorySound)
                return this.item_sound;

            if (item is libsecondlife.InventoryCallingCard)
                return this.item_callingcard;
         
			return item_object;
		}

		protected virtual void OnTreeviewInvCursorChanged (object sender, System.EventArgs e)
		{
			
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(this.treeview_inv.Selection.GetSelected(out mod,out iter))			
			{
				 if(mod.GetValue(iter,3)!=null)
                 {
					InventoryBase item = (InventoryBase)mod.GetValue(iter, 3);
					this.label_name.Text=item.Name;
					
					if(item is InventoryItem)
					{
						this.label_createdby.Text=((InventoryItem)item).CreatorID.ToString();
						this.label_aquired.Text=((InventoryItem)item).CreationDate.ToString();
						this.checkbutton_copy.Active=libsecondlife.PermissionMask.Copy==(((InventoryItem)item).Permissions.OwnerMask&libsecondlife.PermissionMask.Copy);
						this.checkbutton_mod.Active=libsecondlife.PermissionMask.Modify==(((InventoryItem)item).Permissions.OwnerMask&libsecondlife.PermissionMask.Modify);
						this.checkbutton_trans.Active=libsecondlife.PermissionMask.Transfer==(((InventoryItem)item).Permissions.OwnerMask&libsecondlife.PermissionMask.Transfer);
					
						this.checkbutton_copynext.Active=libsecondlife.PermissionMask.Copy==(((InventoryItem)item).Permissions.NextOwnerMask&libsecondlife.PermissionMask.Copy);
						this.checkbutton_modnext.Active=libsecondlife.PermissionMask.Modify==(((InventoryItem)item).Permissions.NextOwnerMask&libsecondlife.PermissionMask.Modify);
						this.checkbutton_transnext.Active=libsecondlife.PermissionMask.Transfer==(((InventoryItem)item).Permissions.NextOwnerMask&libsecondlife.PermissionMask.Transfer);
					
						AsyncNameUpdate ud=new AsyncNameUpdate(((InventoryItem)item).CreatorID.ToString(),false);
						ud.onNameCallBack += delegate(string name,object[] values){this.label_createdby.Text=name;};

						AsyncNameUpdate ud2=new AsyncNameUpdate(((InventoryItem)item).GroupID,true);
						ud2.onNameCallBack += delegate(string name,object[] values){this.label_group.Text=name;};
		
						this.label_saleprice.Text=((InventoryItem)item).SalePrice.ToString();
						
			
					}
		
				 }
				
				
			}
		}
		
		
		
	}
}
