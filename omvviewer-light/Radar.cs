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

// Radar.cs created with MonoDevelop
// User: robin at 21:37 11/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using System.IO;
using OpenMetaverse;
using OpenMetaverse.StructuredData;

namespace omvviewerlight
{

	[System.ComponentModel.ToolboxItem(true)]	
    public partial class Radar : Gtk.Bin
	{
		
		Gtk.ListStore store;	
		private Dictionary<UUID, bool> av_typing = new Dictionary<UUID, bool>();
        private Dictionary<UUID, Gtk.TreeIter> av_tree = new Dictionary<UUID, Gtk.TreeIter>();
	    private Dictionary<UUID,string> client_list = new Dictionary<UUID, string>();
		UUID lastsim = new UUID();
		const float DISTANCE_BUFFER = 3f;

		bool running=true;
		~Radar()
		{
			Logger.Log("Radar Cleaned up",Helpers.LogLevel.Debug);
		}		
		
		public Radar()
		{      
			store= new Gtk.ListStore (typeof(string),typeof(string),typeof(string),typeof(string),typeof(UUID));
			this.Build();
			Gtk.TreeViewColumn tvc;
			treeview_radar.AppendColumn("",new Gtk.CellRendererText(),"text",0);
			tvc=treeview_radar.AppendColumn("Name",new Gtk.CellRendererText(),"text",1);
			//tvc.Resizable=true;
			tvc.Sizing=Gtk.TreeViewColumnSizing.Autosize;
			
			treeview_radar.AppendColumn("Dist.",new Gtk.CellRendererText(),"text",2);

			treeview_radar.AppendColumn("Client.",new Gtk.CellRendererText(),"text",3);
	
			treeview_radar.Model=store;

            MainClass.onRegister += new MainClass.register(MainClass_onRegister);
            MainClass.onDeregister += new MainClass.deregister(MainClass_onDeregister);
            if(MainClass.client != null ) { MainClass_onRegister(); }

            
			AutoPilot.onAutoPilotFinished+=new AutoPilot.AutoPilotFinished(onAutoPilotFinished);

			
			StreamReader SR=File.OpenText("client_list.xml");
			OSDMap client_list_xml=(OSDMap)OpenMetaverse.StructuredData.OSDParser.Deserialize(SR.ReadToEnd());
			SR.Close();		
			
			int count=client_list_xml.Count;
			
			foreach(KeyValuePair<string, OSD> kvp in client_list_xml)
			{
			    try
                {
                    OSD client=kvp.Value;
                    OSDMap map = (OSDMap)client;
                    client_list[new UUID(kvp.Key)]=map["name"].AsString();
                }
                catch(Exception e)
                {

                }
            }
			
			
			this.store.SetSortFunc(2,sort_Vector3);	
            store.SetSortColumnId(2,Gtk.SortType.Ascending);
            Gtk.Timeout.Add(10000, kickrefresh);
		}

        void MainClass_onDeregister()
        {
            if (MainClass.client != null)
            {
            MainClass.client.Grid.CoarseLocationUpdate -= new EventHandler<CoarseLocationUpdateEventArgs>(Grid_CoarseLocationUpdate);
            MainClass.client.Self.ChatFromSimulator -= new EventHandler<ChatEventArgs>(Self_ChatFromSimulator);
            MainClass.client.Network.LoginProgress -= new EventHandler<LoginProgressEventArgs>(Network_LoginProgress);
            MainClass.client.Self.TeleportProgress -= new EventHandler<TeleportEventArgs>(Self_TeleportProgress);
            MainClass.client.Network.SimDisconnected -= new EventHandler<SimDisconnectedEventArgs>(Network_SimDisconnected);
            }
        }

        void MainClass_onRegister()
        {
            av_tree.Clear();
            av_typing.Clear();
            lastsim = UUID.Zero;

            MainClass.client.Grid.CoarseLocationUpdate += new EventHandler<CoarseLocationUpdateEventArgs>(Grid_CoarseLocationUpdate);
            MainClass.client.Self.ChatFromSimulator += new EventHandler<ChatEventArgs>(Self_ChatFromSimulator);
            MainClass.client.Network.LoginProgress += new EventHandler<LoginProgressEventArgs>(Network_LoginProgress);
            MainClass.client.Self.TeleportProgress += new EventHandler<TeleportEventArgs>(Self_TeleportProgress);
            MainClass.client.Network.SimDisconnected += new EventHandler<SimDisconnectedEventArgs>(Network_SimDisconnected);
        }

        
        
        
        void Network_SimDisconnected(object sender, SimDisconnectedEventArgs e)
        {
            lock (e.Simulator.ObjectsAvatars)  
            {
                e.Simulator.AvatarPositions.ForEach(delegate (KeyValuePair <UUID,Vector3> kvp)
                {
                    if (kvp.Value != null && kvp.Key != UUID.Zero)
                    {
                        lock (av_tree)
                        {
                            if (av_tree.ContainsKey(kvp.Key))
                            {
                                Gtk.TreeIter iter = av_tree[kvp.Key];
                                store.Remove(ref iter);
                                av_tree.Remove(kvp.Key);
                            }
                        }
                    }
                });
            }
        }


        void Grid_CoarseLocationUpdate(object sender, CoarseLocationUpdateEventArgs e)
        {
            Gtk.Application.Invoke(delegate
            {
                lock(av_tree)
                {
                    foreach (UUID id in e.RemovedEntries)
                    {
                        if(av_tree.ContainsKey(id))
                        {
                            Gtk.TreeIter iter = av_tree[id];
                            store.Remove(ref iter);
                            av_tree.Remove(id);
                        }
                    }
                }

                calcdistance();
            });
        }

		new public void Dispose()
		{
            MainClass_onDeregister();
		}
		
        bool kickrefresh()
        {

            if (running == false)
				return false;

            if (MainClass.client == null)
                return true;
			
			if (MainClass.client.Network.CurrentSim == null)
                return true;

            if (MainClass.client.Network.CurrentSim.ObjectsAvatars == null)
                return true;


            MainClass.client.Network.Simulators.ForEach(delegate(Simulator sim)
            {
                sim.AvatarPositions.ForEach(delegate(KeyValuePair<UUID, Vector3> kvp)
                {
                    if (kvp.Key != MainClass.client.Self.AgentID)
                    {
                        if (!this.av_tree.ContainsKey(kvp.Key))
                        {
                            Gtk.TreeIter iter;
                            iter = store.AppendValues("", "Waiting...", "", "",kvp.Key);
                            av_tree.Add(kvp.Key, iter);

                            AsyncNameUpdate ud = new AsyncNameUpdate(kvp.Key, false);

                            ud.onNameCallBack += delegate(string name, object[] values)
                            {
                                // We need to check that this iter still exists
                                if (av_tree.ContainsKey(kvp.Key))
								{
                                    store.SetValue(iter, 1, name);
								}
                            };
                            ud.go();

                        }
                    }
                });
            });

            calcdistance();
			clientpoke();
            return true;

        }

		void clientpoke()
		{
			
			Gtk.TreeIter iter;
			MainClass.client.Network.Simulators.ForEach(delegate(Simulator sim)
            {
				sim.ObjectsAvatars.ForEach(delegate(Avatar av)
				{
				
					if(av_tree.TryGetValue(av.ID,out iter))
					{
                        if (av.Textures == null)
                        {
                            store.SetValue(iter, 3, "Out of range");
                        }
                        else
                        {
                            UUID id = av.Textures.GetFace(0).TextureID;
                            string client = "";
                            if (client_list.TryGetValue(id, out client))
                            {
                                store.SetValue(iter, 3, client);
                            }
                        }
					}
										
				});;
				
			});

		}
		
		int sort_Vector3(Gtk.TreeModel model,Gtk.TreeIter a,Gtk.TreeIter b)
		{
            
			string distAs=(string)store.GetValue(a,2);			
			string distBs=(string)store.GetValue(b,2);			
			float distA,distB;
			
			float.TryParse(distAs,out distA);
			float.TryParse(distBs,out distB);

            if (distAs == distBs)
                return 0;

            if (distAs == "NaN")
                return 1;

            if (distBs == "NaN")
                return -1;

			if(distA>distB)
				return 1;
			
			if(distA<distB)
				return -1;
			
			return 0;
		}


        void Self_TeleportProgress(object sender, TeleportEventArgs e)
	    {
			if(e.Status==OpenMetaverse.TeleportStatus.Finished)
			{

                if(MainClass.client.Network.CurrentSim.ID == lastsim)
                    return;

				Gtk.Application.Invoke(delegate
				{                   
                    store.Clear();
                    av_tree.Clear(); // Bleh possible fuck up here with sequencing
                });
				
                if (MainClass.client.Network.CurrentSim != null)
                 lastsim=MainClass.client.Network.CurrentSim.ID;
			}
	    }

	    void Network_LoginProgress(object sender, LoginProgressEventArgs e)
		{
			if(e.Status==LoginStatus.ConnectingToSim)
			{					
				Gtk.Application.Invoke(delegate
				{
					   Logger.Log("Clearing all radar lists",Helpers.LogLevel.Debug);
	                   store.Clear();
					   av_tree.Clear();
					   av_typing.Clear();
				});
			}		

            if (MainClass.client.Network.CurrentSim != null)
            lastsim = MainClass.client.Network.CurrentSim.ID;
		}

        void calcdistance()
        {
           Gtk.Application.Invoke(delegate
		   {
              // if (this.av_tree.ContainsKey(id))
               {
                   if (MainClass.client == null)
                       return;

                   double dist;

                   Vector3d self_pos;
                   if (MainClass.client.Network.CurrentSim == null)
                       return;  //opensim protection
          
                   self_pos = MainClass.client.Self.GlobalPosition;					
				   uint regionX,regionY;
					
                   MainClass.client.Network.Simulators.ForEach(delegate(Simulator sim)
                   {
                       //foreach (Simulator sim in MainClass.client.Network.Simulators)


                       sim.AvatarPositions.ForEach(delegate(KeyValuePair<UUID, Vector3> kvp)
                       {

                           if (kvp.Key != MainClass.client.Self.AgentID)
                           {
                               Utils.LongToUInts(sim.Handle, out regionX, out regionY);

                               try
                               {
                                   Vector3 target_pos = kvp.Value;

                                   target_pos.X = target_pos.X + regionX;
                                   target_pos.Y = target_pos.Y + regionY;
                                   dist = Vector3d.Distance(new Vector3d(target_pos), self_pos);

                                   if (av_tree.ContainsKey(kvp.Key))
                                   {
                                       store.SetValue(av_tree[kvp.Key], 2, dist.ToString("F" + 1, System.Globalization.CultureInfo.InvariantCulture));
                                   }
                               }
                               catch
                               {
                                   Logger.Log("Exceptioned on store setvalue for radar",Helpers.LogLevel.Debug);
                               }
                           }

                       });

                   });

               }
           });
        }

        void Self_ChatFromSimulator(object sender, ChatEventArgs e)
        {
            
			Gtk.Application.Invoke(delegate
			{

                lock(av_tree)
                {
                    if (e.Type == ChatType.StartTyping)
                    {
                        foreach (KeyValuePair<UUID, Gtk.TreeIter> kvp in av_tree)
                        {
                            if (kvp.Key == e.SourceID)
                            {
                                store.SetValue(kvp.Value, 0, "*");
                                return;
                            }
                        }
                    }

                    if (e.Type == ChatType.StopTyping)
                    {
                        foreach (KeyValuePair<UUID, Gtk.TreeIter> kvp in av_tree)
                        {
                            if (kvp.Key == e.SourceID)
                            {
                                store.SetValue(kvp.Value, 0, " ");
                                return;
                            }
                        } 
                    }
                }
			});
             
		}

		protected virtual void OnButtonImClicked (object sender, System.EventArgs e)
		{
			//beter work out who we have selected
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;			
			
			if(this.treeview_radar.Selection.GetSelected(out mod,out iter))			
			{
                UUID id=(UUID)mod.GetValue(iter,4);
                Avatar avatar = AutoPilot.findavatarinsims(id);
				if(avatar!=null)
				{
					MainClass.win.startIM(avatar.ID);
				}
			}		
		}

		protected virtual void OnButtonPayClicked (object sender, System.EventArgs e)
		{

			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview_radar.Selection.GetSelected(out mod,out iter))			
			{
                UUID id=(UUID)mod.GetValue(iter,4);
                Avatar avatar = AutoPilot.findavatarinsims(id);
				if(avatar!=null)
				{
					PayWindow pay=new PayWindow(avatar.ID,0);
					pay.Show();
				}	
			}		
		}

		protected virtual void OnButtonProfileClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview_radar.Selection.GetSelected(out mod,out iter))			
			{
                UUID id = (UUID)mod.GetValue(iter, 4);
                Avatar avatar = AutoPilot.findavatarinsims(id);
                if (avatar != null)
				{
					ProfileVIew p = new ProfileVIew(avatar.ID);
					p.Show();
				}						
			}		
		}

		protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
		{
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(this.button1.Label=="STOP")
			{
				AutoPilot.stop();
				return;
			}
			
			if(treeview_radar.Selection.GetSelected(out mod,out iter))			
			{
				UUID id=(UUID)mod.GetValue(iter,4);		
				AutoPilot.set_target_avatar(id,true);
				this.button1.Label="STOP";
			}
		}

		protected virtual void OnButtonLookatClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
			if(treeview_radar.Selection.GetSelected(out mod,out iter))			
			{
				UUID id=(UUID)mod.GetValue(iter,4);
                Avatar avatar = AutoPilot.findavatarinsims(id);
				if(avatar!=null)
				{
					Vector3 pos;
					
					if(avatar.ParentID==0)
					{
						pos=avatar.Position;
						MainClass.client.Self.Movement.TurnToward(pos);					
					}					
					else
					{
						if(!MainClass.client.Network.CurrentSim.ObjectsPrimitives.ContainsKey(avatar.ParentID))
						{
							Logger.Log("AV is seated and i can't find the parent prim in dictionay",Helpers.LogLevel.Debug);
						}
						else
						{
							Primitive parent = MainClass.client.Network.CurrentSim.ObjectsPrimitives[avatar.ParentID];
							pos = Vector3.Transform(avatar.Position, Matrix4.CreateFromQuaternion(parent.Rotation)) + parent.Position;
							MainClass.client.Self.Movement.TurnToward(pos);						
						}					
					}					
				}		
			}
		}

		void onAutoPilotFinished()
		{
			this.button1.Label="Follow";
		}
	}
}
