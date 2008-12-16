/*
omvviewerlight a Text based client to metaverses such as Linden Labs Secondlife(tm)
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

// ChatConsole.cs created with MonoDevelop
// User: robin at 16:20 11/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using OpenMetaverse;
using Gtk;

namespace omvviewerlight
{
	public partial class ChatConsole : Gtk.Bin
	{
	    Gdk.Color col_red = new Gdk.Color(255,0,0);
	    Gdk.Color col_blue = new Gdk.Color(0,0,255);
	    Gdk.Color col_green = new Gdk.Color(0,255,0);
        Gdk.Color col_yellow = new Gdk.Color(0, 255, 255);
		Gtk.TextTag bold;
		Gtk.TextTag avchat;
        Gtk.TextTag selfavchat;
		Gtk.TextTag objectchat;
        Gtk.TextTag objectIMchat;
        Gtk.TextTag systemchat;
		Gtk.TextTag ownerobjectchat;
        Gtk.TextTag onoffline;

        Gtk.TextTag typing_tag;
		TextMark preTyping;
		TextMark postTyping;
		
		bool istyping=false;
		bool istypingsent=false;
		
		public Gtk.Label tabLabel;
		public UUID im_key=OpenMetaverse.UUID.Zero;
		public UUID im_session_id=OpenMetaverse.UUID.Zero;
		
		
		public ChatConsole()
		{
			dosetup();
            this.im_session_id = UUID.Zero;
            this.im_key = UUID.Zero;
            MainClass.client.Network.OnLogin += new OpenMetaverse.NetworkManager.LoginCallback(onLogin);		
			MainClass.client.Self.OnChat += new OpenMetaverse.AgentManager.ChatCallback(onChat);
            MainClass.client.Self.OnInstantMessage += new OpenMetaverse.AgentManager.InstantMessageCallback(onIM);
            MainClass.client.Friends.OnFriendOffline += new FriendsManager.FriendOfflineEvent(Friends_OnFriendOffline);
            MainClass.client.Friends.OnFriendOnline += new FriendsManager.FriendOnlineEvent(Friends_OnFriendOnline);
		}

        void Friends_OnFriendOnline(FriendInfo friend)
        {
            if (im_key == UUID.Zero && im_session_id == UUID.Zero)
            {
                //this is the main chat winddow, notify for all friends here
               
				AsyncNameUpdate ud=new AsyncNameUpdate(friend.UUID,false);  
  				ud.onNameCallBack += delegate(string namex,object[] values){ displaychat(namex + " is online", "", onoffline, onoffline);	};
                ud.go();
				   
            }
            else if (im_key != UUID.Zero && im_key==friend.UUID)
            {
                Gtk.Application.Invoke(delegate
                {
                    displaychat(friend.Name + "is online", "", onoffline, onoffline);
                });
            }
        }

        void Friends_OnFriendOffline(FriendInfo friend)
        {
            if (im_key == UUID.Zero && im_session_id == UUID.Zero)
            {
                //this is the main chat winddow, notify for all friends here
                Gtk.Application.Invoke(delegate
                {
                    displaychat(friend.Name + " is offline", "", onoffline, onoffline);
                });
            }
            else if (im_key != UUID.Zero && im_key == friend.UUID)
            {
                Gtk.Application.Invoke(delegate
                {
                    displaychat(friend.Name + " is offline", "", onoffline, onoffline);
                });
            }
        }

      		
        void onLogin(LoginStatus status, string message)
        {
            if (LoginStatus.Success == status)
            {
                Gtk.Application.Invoke(delegate
                {
                    this.textview_chat.Buffer.Clear();
                });
            }
        }

		public ChatConsole(InstantMessage im)
		{
            lock (MainClass.win.im_queue)
            {
                dosetup();
                if (im.GroupIM)
                {
                    this.im_session_id = im.IMSessionID;
                    im_key = UUID.Zero;
                    MainClass.client.Self.OnGroupChatJoin += new AgentManager.GroupChatJoinedCallback(onGroupChatJoin);
                    MainClass.client.Self.RequestJoinGroupChat(im.IMSessionID);
                    onIM(im, null);
                }
                else
                {
                    im_key = im.FromAgentID;
                    foreach (InstantMessage qim in MainClass.win.im_queue)
                    {
                        if (qim.FromAgentID == im_key)
                            onIM(qim, null);
                    }

                    MainClass.win.im_queue.RemoveAll(TestRemove);
                    //fetch any IM's in the queue

                    MainClass.win.im_windows.Add(im.FromAgentID, this);
                    if (MainClass.win.im_registering.Contains(im.FromAgentID))
                        MainClass.win.im_registering.Remove(im.FromAgentID);
                }

                MainClass.client.Self.OnInstantMessage += new OpenMetaverse.AgentManager.InstantMessageCallback(onIM);


                // Pass the message on to the chat system as the event will not have been triggered as its
                // only just registered.
            }
		}

        bool TestRemove(InstantMessage x)
        {
            if(x.FromAgentID==im_key)
                return true;

            return false;
        }
		
		public void onSwitchPage(object o, SwitchPageArgs args)
		{
			//If we switch to *this* page then remove a possible red tab lable
			int thispage=MainClass.win.getnotebook().PageNum(this);

            if (thispage == -1)
            {
                if(this.Parent!=null)
                    thispage = MainClass.win.getnotebook().PageNum(this.Parent);
            }

            if (thispage == -1)
                thispage = 1; //FUCKING PARENT CHAT WINDOW STUFF

      	    if(thispage==args.PageNum)
			{
          
			    Gdk.Color col = new Gdk.Color(0,0,0);
				Gtk.StateType type = new Gtk.StateType();
				type|=Gtk.StateType.Active;
			    if(this.tabLabel!=null)
				    this.tabLabel.ModifyFg(type,col);				
			}
		}

        void onGroupChatJoin(UUID groupChatSessionID, string sessionName, UUID tmpSessionID, bool success)
		{
			if(groupChatSessionID!=this.im_session_id)
				return;
			
			string buffer="Joined group chat\n";
			TextIter iter;
	
			Gtk.Application.Invoke(delegate {						
				iter=textview_chat.Buffer.EndIter;
				textview_chat.Buffer.InsertWithTags(ref iter,buffer,bold);						
				textview_chat.ScrollMarkOnscreen(textview_chat.Buffer.InsertMark);
			});
		}	
		
		public void redtab()
		{
			Gtk.Application.Invoke(delegate {	
				Gdk.Color col = new Gdk.Color(255,0,0);
				Gtk.StateType type = new Gtk.StateType();			
				type|=Gtk.StateType.Active;	
					
				int activepage=MainClass.win.getnotebook().CurrentPage;
				int thispage=MainClass.win.getnotebook().PageNum(this);
			//	Console.Write(activepage.ToString()+" : "+thispage.ToString()+"\n");

               // Console.Write("Red tab test " + activepage.ToString() + ":" + thispage.ToString() + "\n");

                if (thispage == -1)
                {
                    if(this.Parent!=null)
                        thispage = MainClass.win.getnotebook().PageNum(this.Parent);

                  //  Console.Write("Tried to get parent we are now on :"+thispage.ToString()+"\n");
                }

                if (thispage == -1 && this.tabLabel != null)
                {
                    //I'm guessing that we are the chat window and the fucking parent operators are still not working
                     if(activepage!=1)
                     {
                      //  Console.Write("Assuming chat so going to red that one\n");
                         this.tabLabel.ModifyFg(type, col);
                     }
                }
                  
				if(thispage!=-1)
				{
                   // Console.Write("Got an index\n");

                    if(activepage!=thispage)
                        if(this.tabLabel!=null)
					        this.tabLabel.ModifyFg(type,col);					
					return;
				}	
			});
		}
		
		public ChatConsole(UUID target)
		{
			dosetup();
			MainClass.client.Self.OnInstantMessage += new OpenMetaverse.AgentManager.InstantMessageCallback(onIM);			
			im_key=target;
		}

		public ChatConsole(UUID target,bool igroup)
		{
			dosetup();
			MainClass.client.Self.OnInstantMessage += new OpenMetaverse.AgentManager.InstantMessageCallback(onIM);
			im_key=UUID.Zero;			
			MainClass.client.Self.RequestJoinGroupChat(target);
			im_session_id=target;
		}
		
		
		void dosetup()
		{
			this.Build();
			bold=new Gtk.TextTag("bold");
			avchat=new Gtk.TextTag("avchat");
            selfavchat = new Gtk.TextTag("selfavchat");
			objectchat=new Gtk.TextTag("objectchat");
			systemchat=new Gtk.TextTag("systemchat");
			ownerobjectchat=new Gtk.TextTag("ownerobjectchat");
            objectIMchat = new Gtk.TextTag("objectIMchat");
            typing_tag = new Gtk.TextTag("typing");
            onoffline = new Gtk.TextTag("onoffline");
            
         
			bold.Weight=Pango.Weight.Bold;
            bold.FontDesc = Pango.FontDescription.FromString("Arial Bold");

            selfavchat.Weight = Pango.Weight.Bold;
            selfavchat.ForegroundGdk = col_red;
		
			objectchat.ForegroundGdk=col_green;
			
			ownerobjectchat.ForegroundGdk=col_blue;
			
			systemchat.Weight=Pango.Weight.Ultrabold;
			systemchat.ForegroundGdk=col_red;

            typing_tag.ForegroundGdk = col_blue;

            onoffline.Weight = Pango.Weight.Bold;
            onoffline.ForegroundGdk = col_yellow;

			
			textview_chat.Buffer.TagTable.Add(bold);
			textview_chat.Buffer.TagTable.Add(avchat);
			textview_chat.Buffer.TagTable.Add(systemchat);
			textview_chat.Buffer.TagTable.Add(objectchat);
			textview_chat.Buffer.TagTable.Add(ownerobjectchat);
            textview_chat.Buffer.TagTable.Add(typing_tag);
            textview_chat.Buffer.TagTable.Add(onoffline);

			//Console.Write("**** CHAT CONSOLE SETUP ****\n");

		}


		public void clickclosed(object obj, EventArgs args)
		{
		    int pageno=1;
			Gtk.Notebook nb;
			nb =(Gtk.Notebook)this.Parent;
			pageno=nb.PageNum((Gtk.Widget)this);

            if(MainClass.win.im_windows.ContainsKey(this.im_key))
                MainClass.win.im_windows.Remove(this.im_key);

		    if(im_key!=OpenMetaverse.UUID.Zero)
				if(MainClass.win.active_ims.Contains(im_key))
					MainClass.win.active_ims.Remove(im_key);	
			
			if(im_session_id!=OpenMetaverse.UUID.Zero)
				if(MainClass.win.active_ims.Contains(im_session_id))
					MainClass.client.Self.RequestLeaveGroupChat(im_session_id);		
			
			nb.RemovePage(pageno);
			
	        MainClass.client.Network.OnLogin -= new OpenMetaverse.NetworkManager.LoginCallback(onLogin);		
			MainClass.client.Self.OnChat -= new OpenMetaverse.AgentManager.ChatCallback(onChat);
            MainClass.client.Self.OnInstantMessage -= new OpenMetaverse.AgentManager.InstantMessageCallback(onIM);
            MainClass.client.Friends.OnFriendOffline -= new FriendsManager.FriendOfflineEvent(Friends_OnFriendOffline);
            MainClass.client.Friends.OnFriendOnline -= new FriendsManager.FriendOnlineEvent(Friends_OnFriendOnline);
		
			MainClass.win.getnotebook().SwitchPage -=  new SwitchPageHandler(onSwitchPage);
			
			this.Destroy();	
			//Finalize();
			//System.GC.SuppressFinalize(this);
		}
		
		
		void onIM(InstantMessage im, Simulator sim)
		{
			//Not group IM ignore messages not destine for im_key
			
			if(im.GroupIM==true)
			{
				if(im.IMSessionID!=this.im_session_id)
					return;
			}
			else
			{
				if(im.FromAgentID!=this.im_key && im.IMSessionID!=this.im_session_id)
					return;
			}

			// Is this a typing message
			
			if(im.Dialog == InstantMessageDialog.StartTyping)
			{
				if(istyping==false)
				{
	                 Gtk.Application.Invoke(delegate
	                 {
	                     displaychat("is typing...", im.FromAgentName, typing_tag, typing_tag);
	                 });
				}
				return;
			}

			if(im.Dialog == InstantMessageDialog.StopTyping)
			{
				if(istyping==false)
				{
	                 Gtk.Application.Invoke(delegate
	                 {
						if(this.istyping==true)
						{
							TextIter start=this.textview_chat.Buffer.GetIterAtMark(this.preTyping);
							TextIter end=this.textview_chat.Buffer.GetIterAtMark(this.postTyping);
							textview_chat.Buffer.SelectRange(start,end);
							textview_chat.Buffer.DeleteSelection(false,false);			
							istyping=false;
						}	                
					});
				}
				return;
			}
				
			//Reject some IMs that we handle else where
			
			if(im.Dialog==OpenMetaverse.InstantMessageDialog.InventoryOffered)
				return;
			
			if(im.Dialog==OpenMetaverse.InstantMessageDialog.TaskInventoryOffered)
				return;
			
			if(im.Dialog==OpenMetaverse.InstantMessageDialog.InventoryAccepted)
				return;
				
			if(im.Dialog==OpenMetaverse.InstantMessageDialog.InventoryAccepted)
				return;
				
            Console.Write("IM FROM " + im.FromAgentID + " : " + im.FromAgentName + " : " + im.IMSessionID + "\n");

            redtab();
            windownotify();

            // Is this from an object?
            //null session ID

            if (im.IMSessionID == UUID.Zero)
            {
                //Its an object message, display in chat not IM
                if ((this.im_key == UUID.Zero) && (this.im_session_id ==UUID.Zero))
                {
                    // We are the chat console not an IM tab
                    Gtk.Application.Invoke(delegate
                    {
                        displaychat(im.Message, im.FromAgentName, objectIMchat, objectIMchat); 
                    });
 
                    return;


                }


            }
           

            Gtk.Application.Invoke(delegate
            {
                displaychat(im.Message, im.FromAgentName, avchat, bold); 
			});	
	
			}
			                                       
		void onChat(string message, ChatAudibleLevel audible, ChatType type, ChatSourceType sourcetype,string fromName, UUID id, UUID ownerid, Vector3 position)
		{

			if(type==ChatType.StartTyping || type==ChatType.StopTyping || type==ChatType.Debug ||type==ChatType.OwnerSay)
				return;

			if(message=="")
				return; //WTF???? why do i get empty messages which are not the above types


            redtab();
            windownotify();

			if(type==ChatType.Whisper)
				fromName=fromName+" whispers";
			if(type==ChatType.Shout)
				fromName=fromName+" shouts";
	
			if(sourcetype==ChatSourceType.Agent)
			{
				Gtk.Application.Invoke(delegate {						
                    displaychat(message, fromName, avchat, bold);	
				});
				return;
			}

			if(type==ChatType.OwnerSay)
			{
				Gtk.Application.Invoke(delegate {
                    displaychat(message, fromName, ownerobjectchat, ownerobjectchat);
				});
				return;		
			}
			
			if(sourcetype==ChatSourceType.Object)
			{
				Gtk.Application.Invoke(delegate {
                    displaychat(message, fromName, objectchat, objectchat);
					});
				return;
			}

			if(sourcetype==ChatSourceType.System)
			{
				Gtk.Application.Invoke(delegate {
                    fromName = "Secondlife ";
                    displaychat(message, fromName, systemchat, systemchat);		
				});
				return;
			}
			
		}

		protected virtual void OnEntryChatActivated (object sender, System.EventArgs e)
		{

            if (this.entry_chat.Text == "")
                return;
			
			if(im_key!=OpenMetaverse.UUID.Zero)
			{
				MainClass.client.Self.InstantMessage(im_key,entry_chat.Text);
				this.displaychat(entry_chat.Text,MainClass.client.Self.Name,avchat,bold);
				this.entry_chat.Text="";
				istypingsent=false;
				return;
			}
			
			if(this.im_session_id!=OpenMetaverse.UUID.Zero)
			{				
				MainClass.client.Self.InstantMessageGroup(im_session_id,entry_chat.Text);
				this.entry_chat.Text="";
				istypingsent=false;
				return;
			}
			
			ChatType type=OpenMetaverse.ChatType.Normal;
			if(this.combobox_say_type.ActiveText=="Say")
				type=OpenMetaverse.ChatType.Normal;
			if(this.combobox_say_type.ActiveText=="Shout")
				type=OpenMetaverse.ChatType.Shout;
			if(this.combobox_say_type.ActiveText=="Whisper")
				type=OpenMetaverse.ChatType.Whisper;
			
			int channel=0;
            string outtext = this.entry_chat.Text;
			
			if(this.entry_chat.Text.StartsWith("/"))
			{
                char[] nums = new char[] {'0','1','2','3','4','5','6','7','8','9'};
                string newtext=entry_chat.Text.Substring(1);
                newtext=newtext.TrimStart(nums);
                int diff;
                diff = entry_chat.Text.Length - newtext.Length;


                if (diff > 1)
                {
                    outtext = newtext;
                    string substr = this.entry_chat.Text.Substring(1, diff-1);
 
                    try
                    {
                        channel = int.Parse(substr);
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.ToString());
                        channel = 0;
                    }
                }
            }

            MainClass.client.Self.Chat(outtext, channel, type);
			
			this.entry_chat.Text="";
			
			istypingsent=false;
		}

      
        void windownotify()
        {
            Gtk.Application.Invoke(delegate
            {
                if (!MainClass.win.Visible)
                {
                    MainClass.win.trayIcon.Blinking = true;
                    MainClass.win.UrgencyHint = true;
                    MainClass.win.trayIcon.Blinking = true;

                }
				if(!(MainClass.win.Focus is Gtk.Widget))
				{
					MainClass.win.UrgencyHint = true;
				}
				});
        }

        void displaychat(string message, string name, TextTag message_tag, TextTag name_tag)
        {
            string buffer;
            TextIter iter;
			bool removedtyping=false;
            bool emote = false;
			
			if(message=="is typing...")
			{
				this.textview_chat.Buffer.DeleteMark("Typing start");
				this.textview_chat.Buffer.DeleteMark("Typing end");
				this.preTyping=textview_chat.Buffer.CreateMark("Typing start",textview_chat.Buffer.EndIter,true);
				istyping=true;
			}
			else
			{
				if(istyping==true)
				{
					TextIter start=this.textview_chat.Buffer.GetIterAtMark(this.preTyping);
					TextIter end=this.textview_chat.Buffer.GetIterAtMark(this.postTyping);
					textview_chat.Buffer.SelectRange(start,end);
					textview_chat.Buffer.DeleteSelection(false,false);
					istyping=false;
				}
			}
				
            if (message.Length > 3)
                if (message.Substring(0, 3) == "/me")
                    emote=true;
			
			if(MainClass.appsettings.timestamps)
			{
				iter = textview_chat.Buffer.EndIter;				
				DateTime CurrTime = DateTime.Now;
                string time = string.Format("[{0:D2}:{1:D2}] ", CurrTime.Hour, CurrTime.Minute);
				textview_chat.Buffer.Insert(ref iter,time);
            }
            if (emote == false)
            {
				iter = textview_chat.Buffer.EndIter;
                buffer = name+" ";
                textview_chat.Buffer.InsertWithTags(ref iter, buffer, name_tag);
                iter = textview_chat.Buffer.EndIter;
                buffer = message + "\n";
                textview_chat.Buffer.InsertWithTags(ref iter, buffer, message_tag);
                TextMark mark = textview_chat.Buffer.CreateMark("xyz", textview_chat.Buffer.EndIter, true);
                textview_chat.ScrollMarkOnscreen(mark);
                textview_chat.Buffer.DeleteMark("xyz");
            }
            else
            {
                if (message.Length < 3)
                    return;

                message = message.Substring(3, message.Length-3);
                iter = textview_chat.Buffer.EndIter;
                buffer = name+message + "\n";
                textview_chat.Buffer.InsertWithTags(ref iter, buffer, message_tag);
                TextMark mark = textview_chat.Buffer.CreateMark("xyz", textview_chat.Buffer.EndIter, true);
                textview_chat.ScrollMarkOnscreen(mark);
                textview_chat.Buffer.DeleteMark("xyz");

            }
			
			if(message=="is typing...")
			{
				this.postTyping=textview_chat.Buffer.CreateMark("Typing end",textview_chat.Buffer.EndIter,true);				
			}
			
			if(removedtyping==true)
			{
				this.istyping=false; //set this false or recuse to hell
				displaychat("is typing...", name, this.typing_tag, this.typing_tag);				
			}

        }

        protected virtual void OnEntryChatChanged (object sender, System.EventArgs e)
		{
			if(im_key!=OpenMetaverse.UUID.Zero)
				{
					if(istypingsent==false)
					{	
					  //  Console.Write("\nSending typing message\n");
                        byte[] binaryBucket;
                        binaryBucket = new byte[0];
		    			MainClass.client.Self.InstantMessage(MainClass.client.Self.Name,im_key,"typing",im_session_id,InstantMessageDialog.StartTyping,InstantMessageOnline.Online,Vector3.Zero, UUID.Zero,binaryBucket);
				    	istypingsent=true;
					    GLib.Timeout.Add(10000,StopTyping);
				    }

            }			
	}
		
	bool StopTyping()
	 {
			
					  //  Console.Write("\nSending typing message\n");
                        byte[] binaryBucket;
                        binaryBucket = new byte[0];
		    			MainClass.client.Self.InstantMessage(MainClass.client.Self.Name,im_key,"",im_session_id,InstantMessageDialog.StopTyping,InstantMessageOnline.Online,Vector3.Zero, UUID.Zero,binaryBucket);
			istypingsent=false;
		     return false;	
			
		 
      }
							
	}
}
