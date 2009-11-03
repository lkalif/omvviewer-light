/*
omvviewerlight a Text based client to metaverses such as Linden Labs Secondlife(tm)
    Copyright (C) 2008,2009  Robin Cornelius <robin.cornelius@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

// Search.cs created with MonoDevelop
// User: robin at 09:19 13/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Gtk;
using OpenMetaverse;

namespace omvviewerlight
{
	
	[System.ComponentModel.ToolboxItem(true)]	
	public partial class Search : Gtk.Bin
	{
		
		Searches s;
		PlacesSearch ps;
		EventsSearch es;
		GroupSearch gs;
		
		public Search()
		{
			this.Build();
			// Fuck stupid notebook tabs and monodeveop have to do it myself
			s=new Searches();
            this.addtabwithicon("icn_voice-pvtfocus.png","People",s);
			
			ps=new PlacesSearch();
			this.addtabwithicon("icon_place.png","Places",ps);
			
			es=new EventsSearch();
			this.addtabwithicon("icon_event.png","Events",es);

			gs=new GroupSearch();
            this.addtabwithicon("icn_voice-groupfocus.png", "Groups", gs);
			
			
		}

		~Search()
		{
			Logger.Log("Search cleaned up",Helpers.LogLevel.Debug);
		}
		
        new public void Dispose()
		{
			Gtk.Notebook p;
			p=(Gtk.Notebook)this.Parent;
			p.RemovePage(p.PageNum(this));
			
			//TODO KILL CHILD SEARCHES FROM HERE?
			if(s!=null)
				s.Dispose();
			s=null;
			if(ps!=null)
				ps.Dispose();
			ps=null;
			if(es!=null)
				es.Dispose();
			es=null;
			if(gs!=null)
				gs.Dispose();
			gs=null;
		}
		
		Gtk.Label addtabwithicon(string filename,string label,Gtk.Widget contents)
	    {
			Gtk.Image image=new Gtk.Image(MainClass.GetResource(""+filename));
			image.SetSizeRequest(16,16);
			Gtk.Label lable=new Gtk.Label(label);
			Gtk.HBox box=new Gtk.HBox();
			box.PackStart(image);
			box.PackStart(lable);
			box.SetChildPacking(image,false,false,0,PackType.Start);
			box.ShowAll();
			notebook1.InsertPage(contents,box,-1);
		    notebook1.ShowAll();
	        return lable;		
		}
		
		
	}
}
