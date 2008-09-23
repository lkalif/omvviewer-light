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

// LoginControl.cs created with MonoDevelop
// User: robin at 08:56 11/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Threading;
using OpenMetaverse;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace omvviewerlight
{	
	public partial class LoginControl : Gtk.Bin
	{
		Dictionary<string,string> gridlist = new Dictionary<string,string>();
		LoginParams login;
		
		bool trying;

        ~LoginControl()
        {
            //This is ugly but works. GC should be called when we need it as we want to do this
            //when the app is going down anyway
            oncleanuptime();
        }

		public LoginControl()
		{

			this.Build();
			MainClass.client.Network.OnConnected += new OpenMetaverse.NetworkManager.ConnectedCallback(onConnected);
			MainClass.client.Network.OnDisconnected += new OpenMetaverse.NetworkManager.DisconnectedCallback(onDisconnected);
			MainClass.client.Network.OnLogin += new OpenMetaverse.NetworkManager.LoginCallback(onLogin);
			MainClass.client.Network.OnEventQueueRunning += new OpenMetaverse.NetworkManager.EventQueueRunningCallback(onEventQueue);
                 
            OpenMetaverse.Logger.OnLogMessage += new OpenMetaverse.Logger.LogCallback(onLogMessage);
           
            this.entry_pass.Visibility=false;

            entry_first.Text = MainClass.ReadSetting("First");
            entry_last.Text = MainClass.ReadSetting("Last");
            entry_pass.Text = MainClass.ReadSetting("Pass");
            if (MainClass.ReadSetting("Remember pass") == "true")
                this.checkbutton_rememberpass.Active = true;
		    else
                this.checkbutton_rememberpass.Active = false;

            StreamReader s = File.OpenText("gridlist.txt");
			try
			{
				char[] splitter  = {' '};
				string[] arInfo = new string[2];

				while(!s.EndOfStream)
				{
					string line=s.ReadLine();
					arInfo=line.Split(splitter,2);
					gridlist.Add(arInfo[0],arInfo[1]);
					this.combobox_grid.AppendText(arInfo[0]);
				}
			}
			catch(Exception e)
			{
			}					
			
			int selected=0;
			int.TryParse(MainClass.ReadSetting("Selected Grid"),out selected);			
			combobox_grid.Active=selected;			
			
		}

        void oncleanuptime()
        {
            // This is a shit place to do this
            MainClass.WriteSetting("First", entry_first.Text);
            MainClass.WriteSetting("Last", entry_last.Text);
            if (this.checkbutton_rememberpass.Active)
            {
                MainClass.WriteSetting("pass", entry_pass.Text);
            }
            else
            {
                MainClass.WriteSetting("pass", "");
            }

            if (this.checkbutton_rememberpass.Active == true)
                MainClass.WriteSetting("Remember pass", "true");
            else
                MainClass.WriteSetting("Remember pass", "false");  

			    MainClass.WriteSetting("Selected Grid",combobox_grid.Active.ToString());
		
		}

 
		void onEventQueue(Simulator sim)
		{
			if(sim.ID==MainClass.client.Network.CurrentSim.ID)
			{
				this.trying=false;
                Gtk.Application.Invoke(delegate
                {
                    Thread loginRunner = new Thread(new ThreadStart(this.appearencethread));
                    loginRunner.Start();
                });
				
			}	
		}
		
		bool OnPulseProgress()
		{
			if(trying==true)
			{
				this.progressbar2.Pulse();
				progressbar2.QueueDraw();
			}			
			else
			{
				this.progressbar2.Fraction=1.0;
				return false;
			}	
			
			return true;
		}
		
		void onConnected(object sender)
		{
			Console.Write("Connected to simulator\n");
		}
		
		void onDisconnected(OpenMetaverse.NetworkManager.DisconnectType reason, string message)
		{
			Gtk.Application.Invoke(delegate {
				this.button_login.Label="Login";
				this.enablebuttons();
			});			
			
		}
		
		/// <summary>Called any time the login status changes, will eventually
        /// return LoginStatus.Success or LoginStatus.Failure</summary>
		void onLogin(LoginStatus login, string message)
		{
			Gtk.Application.Invoke(delegate {
				this.textview_loginmsg.Buffer.Text=message;	
				this.textview_loginmsg.QueueDraw();
			});
			
			if(LoginStatus.Failed==login)
				Gtk.Application.Invoke(delegate {
					this.button_login.Label="Login";
					this.trying=false;
					this.enablebuttons();
			    });			
	
			//This can take ages, should be threaded
			if(LoginStatus.Success==login)
			{
				Console.Write("Login status login\n");                          
				MainClass.client.Groups.RequestCurrentGroups();
				MainClass.client.Self.RetrieveInstantMessages();
                MainClass.client.Throttle.Cloud = 0;
                MainClass.client.Throttle.Wind = 0;
                MainClass.client.Throttle.Land = 0;
          
              }		
		}

		void onLogMessage(object obj, OpenMetaverse.Helpers.LogLevel level)
		{
			if(level >= OpenMetaverse.Helpers.LogLevel.Warning)
			{
				Gtk.Application.Invoke(delegate {
					this.textview_log.Buffer.InsertAtCursor(obj.ToString()+"\n");
					this.textview_log.ScrollMarkOnscreen(textview_log.Buffer.InsertMark);
					this.textview_log.QueueDraw();
				});			
			}				
			
		}
		
		void loginthread()
		{
			Console.Write("Login thread go\n");
			MainClass.client.Network.Login(login);
		}
		
		void appearencethread()
		{
            AutoResetEvent appearanceEvent = new AutoResetEvent(false);
            AppearanceManager.AppearanceUpdatedCallback callback =
                delegate(Primitive.TextureEntry te) { appearanceEvent.Set(); };
            MainClass.client.Appearance.OnAppearanceUpdated += callback;

			Console.Write("Appearence thread go\n");
			MainClass.client.Appearance.SetPreviousAppearance(false);
            if (!appearanceEvent.WaitOne(1000 * 120, false))
            {
                Gtk.Application.Invoke(delegate
                {
                    Gtk.MessageDialog md = new Gtk.MessageDialog(MainClass.win, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Close, "Failed to set previous appearance");
                    md.Run();
                    md.Destroy();
                });
            }
        }
		
		protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
		{
			if(button_login.Label=="Login")
			{
				this.disablebuttons();
				trying=true;
				GLib.Timeout.Add(100,OnPulseProgress);
				
				this.textview_loginmsg.Buffer.Text="Connecting to login server...";
				this.textview_loginmsg.QueueDraw();
				//LoginParams login;
			
				login=MainClass.client.Network.DefaultLoginParams(entry_first.Text,entry_last.Text,entry_pass.Text,"omvviewer","2.0");
                try
                {
                    StreamReader s = File.OpenText("MyMac.txt");
                    login.MAC = s.ReadLine();
                }
                catch(Exception ee)
                {
                }
				
				if(this.radiobutton1.Active)
					login.Start="home";
				if(this.radiobutton2.Active)
					login.Start="last";
				if(this.radiobutton3.Active)
					login.Start=this.entry_location.Text;
				
				this.textview_log.Buffer.Clear();
				button_login.Label="Logout";
				
				login.URI=entry_loginuri.Text;
					
			    /*
				if(this.combobox_grid.ActiveText=="Agni")
				      login.URI=entry_loginuri.Text="https://login.agni.lindenlab.com/cgi-bin/login.cgi";
				
				if(this.combobox_grid.ActiveText=="Aditi")
				      login.URI=entry_loginuri.Text="https://login.aditi.lindenlab.com/cgi-bin/login.cgi";
				                                                  			                                                  
				if(this.combobox_grid.ActiveText=="Local")
				      login.URI=entry_loginuri.Text="http://127.0.0.1:9000";
				
				if(this.combobox_grid.ActiveText=="Custom")
				      login.URI=entry_loginuri.Text=this.entry_loginuri.Text;
	              */
				
				
				Thread loginRunner= new Thread(new ThreadStart(this.loginthread));                               
				
				loginRunner.Start();

}
			else
			{
				trying=false;
				MainClass.client.Network.Logout();
			}
		}

		protected virtual void OnCheckbuttonRememberpassClicked (object sender, System.EventArgs e)
		{
		}

		void disablebuttons()
		{
			this.entry_first.Sensitive=false;
			this.entry_last.Sensitive=false;
			this.entry_loginuri.Sensitive=false;
			this.entry_pass.Sensitive=false;
			this.combobox_grid.Sensitive=false;
			this.checkbutton_rememberpass.Sensitive=false;
			this.radiobutton1.Sensitive=false;
			this.radiobutton2.Sensitive=false;
			this.radiobutton3.Sensitive=false;
			this.entry_location.Sensitive=false;			
		}
		
		void enablebuttons()
		{			
			this.entry_first.Sensitive=true;
			this.entry_last.Sensitive=true;
			this.entry_loginuri.Sensitive=true;
			this.entry_pass.Sensitive=true;
			this.combobox_grid.Sensitive=true;	
			this.checkbutton_rememberpass.Sensitive=true;
			this.radiobutton1.Sensitive=true;
			this.radiobutton2.Sensitive=true;
			this.radiobutton3.Sensitive=true;
			this.entry_location.Sensitive=true;
		}

		protected virtual void OnComboboxGridChanged (object sender, System.EventArgs e)
		{
			string grid=this.combobox_grid.ActiveText;
			string uri;
			
			if(gridlist.TryGetValue(grid,out uri))
		        this.entry_loginuri.Text=uri;
		}
	
	}
}
