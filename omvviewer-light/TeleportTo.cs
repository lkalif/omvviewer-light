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

// TeleportTo.cs created with MonoDevelop
// User: robin at 16:23 12/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using OpenMetaverse;
using Gtk;


namespace omvviewerlight
{
	public partial class TeleportTo : Gtk.Bin
	{
		
		bool userclicked=false;
		bool target=false;
		bool localupdate=false;
        GridRegion targetregion;
        bool validregion = false;
		
		public TeleportTo()
		{
			this.Build();		
            MainClass.client.Network.OnCurrentSimChanged += new OpenMetaverse.NetworkManager.CurrentSimChangedCallback(onNewSim);
            MainClass.client.Objects.OnObjectUpdated += new ObjectManager.ObjectUpdatedCallback(Objects_OnObjectUpdated);    
			AutoPilot.onAutoPilotFinished += new AutoPilot.AutoPilotFinished(onAutoPilotFinished);
			this.button_autopilot.Label="Move To";	
			this.button_autopilot.Image=new Gtk.Image(Stetic.IconLoader.LoadIcon(this, "stock_draw-curved-connector-starts-with-arrow", Gtk.IconSize.Menu, 16));

			if(MainClass.client!=null)
			{
				if(MainClass.client.Network.LoginStatusCode==OpenMetaverse.LoginStatus.Success)
                {	
					MainClass.win.tp_target_widget=this; //MEMORY LEAK, needs to be killed if this widget is removed
				}
			}			
		}
		
		
		new public void Dispose()
		{
            MainClass.client.Network.OnCurrentSimChanged += new OpenMetaverse.NetworkManager.CurrentSimChangedCallback(onNewSim);
            MainClass.client.Objects.OnObjectUpdated += new ObjectManager.ObjectUpdatedCallback(Objects_OnObjectUpdated);    
			AutoPilot.onAutoPilotFinished -= new AutoPilot.AutoPilotFinished(onAutoPilotFinished);

			//Finalize();
			//System.GC.SuppressFinalize(this);
		}
		
		

        void Objects_OnObjectUpdated(Simulator simulator, ObjectUpdate update, ulong regionHandle, ushort timeDilation)
        {
            if (update.LocalID == MainClass.client.Self.LocalID)
            {
                Gtk.Application.Invoke(delegate
                {
					if(userclicked==false)
					{
					localupdate=true;
					this.spinbutton_x.Value = MainClass.client.Self.SimPosition.X;
                    this.spinbutton_y.Value = MainClass.client.Self.SimPosition.Y;
                    this.spinbutton_z.Value = MainClass.client.Self.SimPosition.Z;
					localupdate=false;
					}

					if(target=true)
					{
						if(Math.Abs(MainClass.client.Self.SimPosition.X-spinbutton_x.Value)<1)
							if(Math.Abs(MainClass.client.Self.SimPosition.Y-spinbutton_y.Value)<1)
						    {
							   target=false;
							   MainClass.client.Self.AutoPilotCancel();
						    }
						
					}
				});

            }
        }

        void onNewSim(Simulator lastsim)
        {
		
		   userclicked=false;
           validregion = false;
           Gtk.Application.Invoke(delegate
            {
				this.localupdate=true;
	            this.spinbutton_x.Value = MainClass.client.Self.SimPosition.X;
	            this.spinbutton_y.Value = MainClass.client.Self.SimPosition.Y;
	            this.spinbutton_z.Value = MainClass.client.Self.SimPosition.Z;
				this.localupdate=false;				
				this.entry_simname.Text=MainClass.client.Network.CurrentSim.Name;
				MainClass.win.tp_target_widget=this; //MEMORY LEAK, needs to be killed if this widget is removed
				MainClass.client.Self.AutoPilotCancel();
			});
           
		}

	    bool OnTimeout()
		{
			if(MainClass.client.Network.LoginStatusCode==OpenMetaverse.LoginStatus.Success)
			{
				this.label_current.Text="Current Location: "+MainClass.client.Network.CurrentSim.Name+" "+MainClass.client.Self.SimPosition;
				MainClass.client.Self.AutoPilotCancel();
			}
			
			return true;
		}
		
		protected virtual void OnButtonTeleportActivated (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnButtonTeleportClicked (object sender, System.EventArgs e)
		{
			userclicked=false;
			Vector3 pos;
			pos=new Vector3();
			pos.X=(float)this.spinbutton_x.Value;
			pos.Y=(float)this.spinbutton_y.Value;
			pos.Z=(float)this.spinbutton_z.Value;
			TeleportProgress tp = new TeleportProgress();
			tp.Show();
			tp.teleport(entry_simname.Text,pos);
		
		}

		protected virtual void OnButtonTphomeClicked (object sender, System.EventArgs e)
		{
			userclicked=false;
			TeleportProgress tp = new TeleportProgress();
			tp.Show();
			tp.teleporthome();
		}

		protected virtual void OnButtonAutopilotClicked (object sender, System.EventArgs e)
		{
		
			
			if(this.button_autopilot.Label=="Move To")
			{			
				Console.WriteLine("Autopilot on");
				userclicked=false;
				Vector3 pos;
				pos=new Vector3();
				pos.X=(float)this.spinbutton_x.Value;
				pos.Y=(float)this.spinbutton_y.Value;
				pos.Z=(float)this.spinbutton_z.Value;
                if (validregion)
                {
                    AutoPilot.set_target_pos(AutoPilot.localtoglobalpos(pos,targetregion.RegionHandle));
                }
                else
                {
                    AutoPilot.set_target_pos(AutoPilot.localtoglobalpos(pos, MainClass.client.Network.CurrentSim.Handle));
                }

                Console.WriteLine("Autopilot target global is " + AutoPilot.localtoglobalpos(pos, MainClass.client.Network.CurrentSim.Handle).ToString());
                Console.WriteLine("Agent is now local " + MainClass.client.Self.RelativePosition.ToString());
                Console.WriteLine("Agent is now global " + MainClass.client.Self.GlobalPosition.ToString());

				this.button_autopilot.Label="Stop";
				this.button_autopilot.Image=new Gtk.Image(Stetic.IconLoader.LoadIcon(this, "gtk-cancel", Gtk.IconSize.Menu, 16));
				
			}
			else
			{
				AutoPilot.stop();
				this.button_autopilot.Label="Move To";	
				this.button_autopilot.Image=new Gtk.Image(Stetic.IconLoader.LoadIcon(this, "stock_draw-curved-connector-starts-with-arrow", Gtk.IconSize.Menu, 16));
			}
		}
		
		public void settarget(Vector3 pos,GridRegion region)
		{
			Console.WriteLine("Set target from map");
			userclicked=true;
            this.entry_simname.Text = region.Name;
			this.spinbutton_x.Value=pos.X;
			this.spinbutton_y.Value=pos.Y;
			this.spinbutton_z.Value=pos.Z;
			target=true;
            targetregion = region;
            validregion = true;
		}


		void updatemap()
		{
			if(localupdate)
				return;
			
			userclicked=true;
			target=false;
			Vector3 pos=new Vector3();
			pos.X=(float)this.spinbutton_x.Value;
			pos.Y=(float)this.spinbutton_y.Value;
			pos.Z=(float)this.spinbutton_z.Value;
			if(MainClass.win.map_widget!=null)
				MainClass.win.map_widget.showtarget(pos);
		}

		protected virtual void OnSpinbuttonXValueChanged (object sender, System.EventArgs e)
		{
			updatemap();

		}

		protected virtual void OnSpinbuttonYValueChanged (object sender, System.EventArgs e)
		{
			updatemap();

		}

		protected virtual void OnSpinbuttonZValueChanged (object sender, System.EventArgs e)
		{
			updatemap();

		}
		
		void onAutoPilotFinished()
		{
			Gtk.Application.Invoke(delegate {
				this.button_autopilot.Label="Move To";	
				this.button_autopilot.Image=new Gtk.Image(Stetic.IconLoader.LoadIcon(this, "stock_draw-curved-connector-starts-with-arrow", Gtk.IconSize.Menu, 16));
		 });
		}
	}
}
