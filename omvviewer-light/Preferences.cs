// Preferences.cs created with MonoDevelop
// User: robin at 21:00 14/11/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
namespace omvviewerlight
{
	
	public partial class Preferences : Gtk.Window
	{
		
		public Preferences() : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.checkbutton_showtimestamps.Active=MainClass.appsettings.timestamps;			
			this.checkbutton_hideminimise.Active=MainClass.appsettings.minimise;
			this.radiobutton1.Active=MainClass.appsettings.default_minimim;
			this.radiobutton2.Active=MainClass.appsettings.default_close;
			this.hscale_asset.Value=     MainClass.appsettings.ThrottleAsset;
			this.hscale_cloud.Value=    MainClass.appsettings.ThrottleCloud;
			this.hscale_land.Value=     MainClass.appsettings.ThrottleLand;
			this.hscale_resend.Value=    MainClass.appsettings.ThrottleResend;
			this.hscale_task.Value=      MainClass.appsettings.ThrottleTask;
			this.hscale_texture.Value=     MainClass.appsettings.ThrottleTexture;
			this.hscale_wind.Value=   MainClass.appsettings.ThrottleWind;
			
		}

				protected virtual void OnCheckbuttonShowtimestampsClicked (object sender, System.EventArgs e)
				{
			          MainClass.appsettings.timestamps=checkbutton_showtimestamps.Active;			
			         
		        }

				protected virtual void OnCheckbuttonHideminimiseClicked (object sender, System.EventArgs e)
				{
                     MainClass.appsettings.minimise=this.checkbutton_hideminimise.Active;
			        
		        }

				protected virtual void OnRadiobutton1Activated (object sender, System.EventArgs e)
				{
			          MainClass.appsettings.default_minimim=this.radiobutton1.Active;
			          MainClass.appsettings.default_close=this.radiobutton2.Active;
			         
		        }

				protected virtual void OnRadiobutton2Activated (object sender, System.EventArgs e)
				{
			          MainClass.appsettings.default_minimim=this.radiobutton1.Active;
			          MainClass.appsettings.default_close=this.radiobutton2.Active;
			         
		        }

				protected virtual void OnButtonApplythrottleClicked (object sender, System.EventArgs e)
				{

			       MainClass.appsettings.ThrottleAsset=(float)this.hscale_asset.Value;
			       MainClass.appsettings.ThrottleCloud=(float)this.hscale_cloud.Value;
			       MainClass.appsettings.ThrottleLand=(float)this.hscale_land.Value;
			       MainClass.appsettings.ThrottleResend=(float)this.hscale_resend.Value;
			       MainClass.appsettings.ThrottleTask=(float)this.hscale_task.Value;
			       MainClass.appsettings.ThrottleTexture=(float)this.hscale_texture.Value;
			       MainClass.appsettings.ThrottleWind=(float)this.hscale_wind.Value;
			       MainClass.appsettings.Save();
				
				}
	}
}
