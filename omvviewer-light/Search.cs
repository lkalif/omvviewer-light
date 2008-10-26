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

// Search.cs created with MonoDevelop
// User: robin at 09:19 13/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Gtk;

namespace omvviewerlight
{
	
	public partial class Search : Gtk.Bin
	{
		
		public Search()
		{
			this.Build();
			// Fuck stupid notebook tabs and monodeveop have to do it myself
			Searches s=new Searches();
            this.addtabwithicon("icn_voice-pvtfocus.tga","People",s);
			
			PlacesSearch ps=new PlacesSearch();
			this.addtabwithicon("icon_place.tga","Places",ps);
			
			EventsSearch es=new EventsSearch();
			this.addtabwithicon("icon_event.tga","Events",es);
			
		}
		
        public void kill()
		{
			Gtk.Notebook p;
			p=(Gtk.Notebook)this.Parent;
			p.RemovePage(p.PageNum(this));
		}
		
		Gtk.Label addtabwithicon(string filename,string label,Gtk.Widget contents)
	    {
			Gtk.Image image=new Gtk.Image(filename);
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
