// ObjectsLayout.cs created with MonoDevelop
// User: robin at 13:32 14/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using libsecondlife;

namespace omvviewerlight
{
	
	public partial class ObjectsLayout : Gtk.Bin
	{
	
		Gtk.ListStore store;	
        Dictionary<LLUUID, Primitive> PrimsWaiting = new Dictionary<LLUUID, Primitive>();
		Dictionary<uint,Primitive> objects= new Dictionary<uint,Primitive>(); 

		public ObjectsLayout()
		{
			this.Build();
			store= new Gtk.ListStore (typeof(string),typeof(string),typeof(LLUUID));
			treeview1.AppendColumn("Name",new Gtk.CellRendererText(),"text",0);
			treeview1.AppendColumn("Desc.",new Gtk.CellRendererText(),"text",1);
			treeview1.AppendColumn("ID",new Gtk.CellRendererText(),"text",2);
			treeview1.Model=store;

			MainClass.client.Objects.OnObjectProperties += new libsecondlife.ObjectManager.ObjectPropertiesCallback(Objects_OnObjectProperties);
		}

		bool myfunc(Gtk.TreeModel mod, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			LLUUID key=(LLUUID)store.GetValue(iter,2);			
			if(PrimsWaiting.ContainsKey(key))
			{
				store.SetValue(iter,0,PrimsWaiting[key].Properties.Name);
				store.SetValue(iter,1,PrimsWaiting[key].Properties.Description);
				store.SetValue(iter,2,PrimsWaiting[key].Properties.ObjectID.ToString());
			}
			return true;
		}

		protected virtual void OnButtonSearchClicked (object sender, System.EventArgs e)
		{
			int radius;
			int.TryParse(this.entry1.Text,out radius);
			
			// *** get current location ***
            LLVector3 location = MainClass.client.Self.SimPosition;

            // *** find all objects in radius ***
            List<Primitive> prims = MainClass.client.Network.CurrentSim.ObjectsPrimitives.FindAll(
                delegate(Primitive prim) {
                    LLVector3 pos = prim.Position;
                    return ((prim.ParentID == 0) && (pos != LLVector3.Zero) && (LLVector3.Dist(pos, location) < radius));
                }
            );
			
			RequestObjectProperties(prims, 250);
			
		}
		
        private void RequestObjectProperties(List<Primitive> objects, int msPerRequest)
        {
            // Create an array of the local IDs of all the prims we are requesting properties for
            uint[] localids = new uint[objects.Count];

            lock (PrimsWaiting) {
                PrimsWaiting.Clear();

                for (int i = 0; i < objects.Count; ++i) {
                    localids[i] = objects[i].LocalID;
                    PrimsWaiting.Add(objects[i].ID, objects[i]);
                }
            }

            MainClass.client.Objects.SelectObjects(MainClass.client.Network.CurrentSim, localids);

            //return AllPropertiesReceived.WaitOne(2000 + msPerRequest * objects.Count, false);
        }

		void Objects_OnObjectProperties(Simulator simulator, LLObject.ObjectProperties properties)
        {
            lock (PrimsWaiting) {
                Primitive prim;
                if (PrimsWaiting.TryGetValue(properties.ObjectID, out prim)) {
                    prim.Properties = properties;
					store.AppendValues(prim.Properties.Name,prim.Properties.Description,prim.Properties.ObjectID);
					Gtk.Application.Invoke(delegate {										
						store.Foreach(myfunc);
				});
				
				}
              //  PrimsWaiting.Remove(properties.ObjectID);

                //if (PrimsWaiting.Count == 0)
                   // AllPropertiesReceived.Set();
            }
        }

		protected virtual void OnTreeview1CursorChanged (object sender, System.EventArgs e)
		{
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview1.Selection.GetSelected(out mod,out iter))			
			{
				LLUUID id=(LLUUID)mod.GetValue(iter,2);
		
				Primitive prim;
				if(PrimsWaiting.TryGetValue(id,out prim))
				{
					this.label_name.Text=prim.Properties.Name;
					this.label_desc.Text=prim.Properties.Description;
					
					string name;
					if(MainClass.av_names.TryGetValue(prim.Properties.OwnerID,out name))
					   this.label_owner.Text=name;
					else
						this.label_owner.Text="Unknown";
				
					string group="Unknown";
					if(!MainClass.av_names.TryGetValue(prim.Properties.GroupID,out group))
						group="Unknown";	
					
					this.label_group.Text=group;
					
					switch(prim.Properties.SaleType)
					{
					case (byte)libsecondlife.SaleType.Not: 
						this.label_forsale.Text="Not for sale";
						break;
				
					case (byte)libsecondlife.SaleType.Contents: 
						this.label_forsale.Text="Contents for $L"+prim.Properties.SalePrice.ToString();
						break;

					case (byte)libsecondlife.SaleType.Copy: 
						this.label_forsale.Text="Copy for $L"+prim.Properties.SalePrice.ToString();	
						break;
					
					case (byte)libsecondlife.SaleType.Original: 
						this.label_forsale.Text="Original for $L"+prim.Properties.SalePrice.ToString();	
						break;	
					}
					
					if(prim.Properties.SaleType ==  (byte)libsecondlife.SaleType.Not)
					{
						this.button_buy.Sensitive=false;
					}
					else
					{
						this.button_buy.Sensitive=true;						
					}
					
					if((prim.Flags & libsecondlife.LLObject.ObjectFlags.Touch) == libsecondlife.LLObject.ObjectFlags.Touch)
					{
						this.button_touch.Sensitive=true;
					}
					else
					{
						this.button_touch.Sensitive=false;
					}
					
					if((prim.Flags & libsecondlife.LLObject.ObjectFlags.Money) == libsecondlife.LLObject.ObjectFlags.Money)
					{
						this.button_pay.Sensitive=true;
					}
					else
					{
						this.button_pay.Sensitive=false;
					}
				}
			
			}
		}

		protected virtual void OnButtonPayClicked (object sender, System.EventArgs e)
		{

			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview1.Selection.GetSelected(out mod,out iter))			
			{
				LLUUID id=(LLUUID)mod.GetValue(iter,2);
				Primitive prim;
				
				if(PrimsWaiting.TryGetValue(id,out prim))
				{
					PayWindow pay=new PayWindow(prim,0);
					pay.Modal=true;
					pay.Show();
				}
				
			}
		}

		
	}
}
