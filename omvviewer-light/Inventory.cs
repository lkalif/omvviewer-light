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
		String[] SearchFolders = { "" };
		//initialize our list to store the folder contents
        LLUUID inventoryItems;
		Gtk.TreeStore inventory = new Gtk.TreeStore (typeof(Gdk.Pixbuf),typeof (string), typeof (LLUUID));		
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
				
		}
	
		void onLogin(LoginStatus status,string message)
		{
			if(LoginStatus.Success==status)
			{
				Gtk.Application.Invoke(delegate {
					inventory.Clear();
					Gtk.TreeIter iter = inventory.AppendValues(folder_closed,"Inventory", MainClass.client.Inventory.Store.RootFolder.UUID);
					inventory.AppendValues(iter,folder_closed, "Waiting...", MainClass.client.Inventory.Store.RootFolder.UUID);		
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
				Gdk.Pixbuf buf=getprettyicon(item);
				Gtk.TreeIter iter2 = inventory.AppendValues(args.Iter,buf, item.Name, item.UUID);

				if (item is InventoryFolder)
				{
					inventory.AppendValues(iter2, item_object,"Waiting...", item.UUID);	
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
	}
}
