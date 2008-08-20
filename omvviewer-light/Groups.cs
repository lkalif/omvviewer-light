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

// Groups.cs created with MonoDevelop
// User: robin at 16:20 16/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using libsecondlife;
using Gtk;

namespace omvviewerlight
{
	public partial class Groups : Gtk.Bin
	{
	
		Gtk.ListStore store;
		List<Group> groups_recieved=new List<Group>();
		
		public Groups()
		{
   
			this.Build();
			store= new Gtk.ListStore (typeof(string),typeof(Group));			
			treeview1.AppendColumn("Group",new CellRendererText(),"text",0);
			treeview1.Model=store;
	
			MainClass.client.Groups.OnCurrentGroups += new libsecondlife.GroupManager.CurrentGroupsCallback(onGroups);
			MainClass.client.Groups.RequestCurrentGroups();
		}
		
		void onGroups(Dictionary<LLUUID,Group> groups)
		{
			
			Gtk.Application.Invoke(delegate {
				
				foreach(KeyValuePair <LLUUID,Group> group in groups)
				{
					if(!this.groups_recieved.Contains(group.Value))
					{
						string name;
						name=group.Value.Name;
						if(MainClass.client.Self.ActiveGroup==group.Value.ID)
						{
							name="<b>"+name+"<b>";
						}
						store.AppendValues(group.Value.Name,group.Value);
						this.groups_recieved.Add(group.Value);
					}
				}
			});
		}

		protected virtual void OnButtonGroupimClicked (object sender, System.EventArgs e)
		{			
		    Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview1.Selection.GetSelected(out mod,out iter))			
			{
				Group group=(Group)mod.GetValue(iter,1);
				MainClass.win.startGroupIM(group.ID);
			}
		}

		protected virtual void OnButtonInfoClicked (object sender, System.EventArgs e)
		{
		    Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview1.Selection.GetSelected(out mod,out iter))			
			{
				Group group=(Group)mod.GetValue(iter,1);
				GroupInfo info=new GroupInfo(group);
				info.Show();
			}
		}
	}
}
