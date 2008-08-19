// ProfileVIew.cs created with MonoDevelop
// User: robin at 15:15 15/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using System.IO;
using libsecondlife;
using libsecondlife;

namespace omvviewerlight
{

	public partial class ProfileVIew : Gtk.Window
	{
		
		LLUUID profile_pic;
		LLUUID firstlife_pic;
		LLUUID partner_key;
		LLUUID resident;
		
		List <LLUUID>picks_waiting;
		
		public ProfileVIew(LLUUID key) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
	
			picks_waiting=new List<LLUUID>();
			resident=key;
			
			MainClass.client.Avatars.OnAvatarProperties += new libsecondlife.AvatarManager.AvatarPropertiesCallback(onAvatarProperties);
			MainClass.client.Avatars.RequestAvatarProperties(key);
			MainClass.client.Avatars.OnAvatarNames += new libsecondlife.AvatarManager.AvatarNamesCallback(on_avnames);
			MainClass.client.Avatars.OnAvatarPicks += new libsecondlife.AvatarManager.AvatarPicksCallback(onPicks);
			MainClass.client.Avatars.OnPickInfo += new libsecondlife.AvatarManager.PickInfoCallback(onPickInfo);
			MainClass.client.Avatars.RequestAvatarPicks(key);
			
			this.label_born.Text="";
			this.label_identified.Text="";
			this.label_name.Text="";
		    this.label_partner.Text="";
			this.label_pay.Text="";
			this.label_status.Text="";	
			Gdk.Pixbuf buf=new Gdk.Pixbuf("trying.tga");
			this.image3.Pixbuf=buf.ScaleSimple(128,128,Gdk.InterpType.Bilinear);
			
			this.image7.Pixbuf=buf.ScaleSimple(128,128,Gdk.InterpType.Bilinear);
			
		}
	
		void onPickInfo(LLUUID pick,ProfilePick info)
		{				
			if(!this.picks_waiting.Contains(pick))
				return;
			
			picks_waiting.Remove(pick);
			   
			Gtk.Application.Invoke(delegate {	
			
				aPick tpick= new aPick(info.SnapshotID,info.Name,info.Desc,info.Name,info.SimName,info.PosGlobal);
				Gtk.Label lable=new Gtk.Label(info.Name.Substring(0,info.Name.Length>10?10:info.Name.Length));
				this.ShowAll();
				
				this.notebook_picks.InsertPage(tpick,lable,-1);
				this.notebook_picks.ShowAll();
			});
		}
		
		void onPicks(LLUUID avatar, Dictionary<LLUUID,string> picks)
	    {
			if(avatar!=	resident)
				return;
		
			Gtk.Application.Invoke(delegate {	
				foreach(KeyValuePair<LLUUID,string> pick in picks)
				{	
					//this.notebook_picks.InsertPage(
					this.picks_waiting.Add(pick.Key);
					MainClass.client.Avatars.RequestPickInfo(resident,pick.Key);
				}
			});
		}
			                                                   
		void on_avnames(Dictionary<LLUUID, string> names)
			{
			//what the hell, lets cache them to the program store if we find them
			//Possible to do, move this type of stuff more global
			Console.Write("Got new names \n");
			
			foreach(KeyValuePair<LLUUID,string> name in names)
			{
				if(!MainClass.av_names.ContainsKey(name.Key))
					MainClass.av_names.Add(name.Key,name.Value);		
			
				Console.Write("Names = "+name.Value+"\n");
			}

			Gtk.Application.Invoke(delegate {	
				if(MainClass.av_names.ContainsKey(resident))
				{
					this.label_name.Text=MainClass.av_names[resident];
				}
				else
				{
					this.label_name.Text="Waiting....";
				}
				this.QueueDraw();
			});
			
		
			Gtk.Application.Invoke(delegate {	
				if(MainClass.av_names.ContainsKey(partner_key))
				{
					this.label_partner.Text=MainClass.av_names[partner_key];
				}
				else
				{
					this.label_partner.Text="Waiting....";
				}
				this.QueueDraw();
			});
				
		}		
		
		void onAvatarProperties(LLUUID id,libsecondlife.Avatar.AvatarProperties props)
		{
			if(id!=	resident)
				return;

			Gtk.Application.Invoke(delegate {
				
			this.label_born.Text=props.BornOn;

			partner_key=props.Partner;
			
			if(props.Online)
				this.label_status.Text="Online";
			else
				this.label_status.Text="Offline";
			
			if(props.Transacted)
				this.label_pay.Text="Pay info on file";
			else
				this.label_pay.Text="No";
			
			if(props.Identified)
				this.label_identified.Text="Yes";
			else
				this.label_identified.Text="No";
			
			this.textview2.Buffer.Text=props.AboutText;
				
			this.textview3.Buffer.Text=props.FirstLifeText;
				
			profile_pic=props.ProfileImage;
			firstlife_pic=props.FirstLifeImage;

			TryGetImage getter= new TryGetImage(this.image7,profile_pic);
			TryGetImage getter2= new TryGetImage(this.image3,firstlife_pic);
							
			if(MainClass.av_names.ContainsKey(id))
			{
				this.label_name.Text=MainClass.av_names[id];
			}
			else
			{
				MainClass.client.Avatars.RequestAvatarName(id);
				this.label_name.Text="Waiting....";
			}
						
			if(props.Partner!=LLUUID.Zero)
			{	
				if(MainClass.av_names.ContainsKey(partner_key))
				{
					this.label_partner.Text=MainClass.av_names[partner_key];
				}
				else
				{
					MainClass.client.Avatars.RequestAvatarName(partner_key);
					this.label_partner.Text="Waiting....";
				}
			}														
		});
		}	
	}
}
