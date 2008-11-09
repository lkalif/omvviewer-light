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

// PlacesSearch.cs created with MonoDevelop
// User: robin at 17:55 13/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using OpenMetaverse;

namespace omvviewerlight
{
	
	public partial class PlacesSearch : Gtk.Bin
	{
	
		UUID queryid;
		Gtk.ListStore store;
        int places_found;
		TryGetImage getter;
		
		public PlacesSearch()
		{
			this.Build();
			store= new Gtk.ListStore (typeof(string),typeof(string),typeof(string),typeof(string),typeof(Vector3),typeof(UUID));
			
		//	treeview1.AppendColumn("Name",new Gtk.CellRendererText(),"text",0);
		//	treeview1.AppendColumn("Sim",new Gtk.CellRendererText(),"text",1);		
		//	treeview1.AppendColumn("Trafic",new Gtk.CellRendererText(),"text",2);		
		//	treeview1.AppendColumn("Loc",new Gtk.CellRendererText(),"text",3);

            MyTreeViewColumn mycol;
            mycol = new MyTreeViewColumn("Name", new Gtk.CellRendererText(), "text", 0);
            mycol.setmodel(store);
            treeview1.AppendColumn(mycol);

            mycol = new MyTreeViewColumn("Sim", new Gtk.CellRendererText(), "text", 1);
            mycol.setmodel(store);
            treeview1.AppendColumn(mycol);

            mycol = new MyTreeViewColumn("Traffic", new Gtk.CellRendererText(), "text", 2);
            mycol.setmodel(store);
            treeview1.AppendColumn(mycol);
			store.SetSortFunc(2,numericsort);
			
            mycol = new MyTreeViewColumn("Location", new Gtk.CellRendererText(), "text", 3);
            mycol.setmodel(store);
            treeview1.AppendColumn(mycol);

            treeview1.HeadersClickable = true;
			treeview1.Model=store;
            store.SetSortColumnId(0, Gtk.SortType.Ascending);

			MainClass.client.Directory.OnPlacesReply += new OpenMetaverse.DirectoryManager.PlacesReplyCallback(onPlaces);
		
			
		}
		
		int numericsort(Gtk.TreeModel model, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			string nameA = (string)store.GetValue(a, 1);
            string nameB = (string)store.GetValue(b, 1);

            float Pa = (float)store.GetValue(a, 3);
            float Pb =(float)store.GetValue(b, 3);

			int tSortColumnId;
            Gtk.SortType order;
			
           		
            if (Pa == Pb)
            {
               return 0;
            }

						
            if (Pa > Pb)
               return -1;

            return 1;
		}
				
			void onPlaces(UUID query,List <OpenMetaverse.DirectoryManager.PlacesSearchData> matchedplaces)
			{
				if(query!=queryid)
					return;

			
			
                places_found += matchedplaces.Count;
				Gtk.Application.Invoke(delegate {

                    this.label_info.Text = "Search returned " + places_found.ToString() + " results";
	    

				foreach(OpenMetaverse.DirectoryManager.PlacesSearchData place in matchedplaces)
				{	
					Vector3 pos=new Vector3(((int)place.GlobalX)&0x0000FF,((int)place.GlobalY)&0x0000FF,place.GlobalZ);
					store.AppendValues(place.Name,place.SimName,place.Dwell.ToString(),MainClass.prettyvector(pos,2),pos,place.SnapshotID);
				}
			
			 });
			}
				
		protected virtual void OnButtonSearchClicked (object sender, System.EventArgs e)
		{
			store.Clear();
			this.label_info.Text="Searching..........";
            places_found = 0;
			
			OpenMetaverse.DirectoryManager.DirFindFlags flags;
			flags=OpenMetaverse.DirectoryManager.DirFindFlags.NameSort;
			
			if(this.checkbutton_mature.Active==false)
			flags|=OpenMetaverse.DirectoryManager.DirFindFlags.PgSimsOnly;
				
			OpenMetaverse.Parcel.ParcelCategory pcat;
			pcat=OpenMetaverse.Parcel.ParcelCategory.Any;
			queryid=UUID.Random();
			MainClass.client.Directory.StartPlacesSearch(flags,pcat,entry1.Text,"",MainClass.client.Self.ActiveGroup,queryid);
		}

		protected virtual void OnButtonTPClicked (object sender, System.EventArgs e)
		{
			
			Vector3 pos=new Vector3();
			string sim;
			
			//beter work out who we have selected
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
					
			if(treeview1.Selection.GetSelected(out mod,out iter))			
			{
				sim=(string)mod.GetValue(iter,1);
				pos=(Vector3)mod.GetValue(iter,4);
										
				TeleportProgress tp = new TeleportProgress();
				tp.Show();
				tp.teleport(sim,pos);
			}
		}

		protected virtual void OnTreeview1CursorChanged (object sender, System.EventArgs e)
		{
			
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(this.treeview1.Selection.GetSelected(out mod,out iter))			
			{
				UUID id=(UUID)mod.GetValue(iter,5);

				if(getter!=null)
					getter.abort();
							
				TryGetImage i = new TryGetImage(this.image_parcel,id,175,175);
				getter=i;
				
			}
		}
				
	}
}
