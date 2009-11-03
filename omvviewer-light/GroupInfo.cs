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

// GroupInfo.cs created with MonoDevelop
// User: robin at 17:59 18/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using OpenMetaverse;
using Gtk;

namespace omvviewerlight
{
	public partial class GroupInfo : Gtk.Window
	{
		//Dictionary <UUID, GroupRole> grouproles;
		//List<KeyValuePair<UUID,UUID>> rolesmembers;
		Gtk.ListStore store_members;		
		Gtk.ListStore store_membersandroles_members;
		Gtk.ListStore assigned_roles;
        Gtk.ListStore notice_list;
        Gtk.TreeStore store_membersandroles_powers;
        Gtk.TreeStore store_roles_list;
        Gtk.TreeStore store_roles_abilities;
        Gtk.TreeStore store_roles_members;

        Gtk.TreeStore store_abilities;
        Gtk.TreeStore store_roles_with_ability;
        Gtk.TreeStore store_members_with_ability;
        
		Gtk.TreeStore store_groupland;
		
        UUID request_members;
        UUID request_titles;
        UUID request_roles;
        UUID request_roles_members;
		
        List <UUID> recieved_notices=new List<UUID>();		

		bool already_member=false;
        bool nobody_cares = false;

        bool name_poll = false;
		
		UUID groupkey;
	
		
        List<UUID> rcvd_names = new List<UUID>();

		Gdk.Pixbuf folder_open = MainClass.GetResource("inv_folder_plain_open.png");
		Gdk.Pixbuf tick = MainClass.GetResource("tick.png");
		Gdk.Pixbuf cross = MainClass.GetResource("cross.png");

        Dictionary<UUID, OpenMetaverse.GroupTitle> group_titles=new Dictionary<UUID, OpenMetaverse.GroupTitle>();


        Dictionary<UUID, GroupMember> group_members=new Dictionary<UUID,GroupMember>();
        List<KeyValuePair<UUID, UUID>> group_roles_members = new List<KeyValuePair<UUID, UUID>>();
        Dictionary<UUID, GroupRole> group_roles = new Dictionary<UUID, GroupRole>();
        Dictionary<UUID, OpenMetaverse.GroupTitle> titles = new Dictionary<UUID, GroupTitle>();

		public GroupInfo(UUID groupID,bool mine) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();

			groupkey=groupID;
			already_member=mine;

            this.label_name.Text = " Waiting ....";
            this.label_foundedby.Text = "Waiting ...";
			
			store_members = new Gtk.ListStore (typeof(string),typeof(string),typeof(string),typeof(UUID));			
			treeview_members.AppendColumn("Member name",new CellRendererText(),"text",0);
			treeview_members.AppendColumn("Title",new CellRendererText(),"text",1);
			treeview_members.AppendColumn("Last login",new CellRendererText(),"text",2);
			treeview_members.Model=store_members;
				
			//Tree view for Members & Roles, Members
			
			this.store_membersandroles_members=new Gtk.ListStore(typeof(string),typeof(string),typeof(string),typeof(UUID));
			this.treeview_members1.AppendColumn("Member name",new CellRendererText(),"text",0);
			this.treeview_members1.AppendColumn("Land",new CellRendererText(),"text",1);
			this.treeview_members1.AppendColumn("Title",new CellRendererText(),"text",2);
			this.treeview_members1.Model=store_membersandroles_members;		

			//Tree view for Roles
			assigned_roles = new Gtk.ListStore (typeof(bool),typeof(string),typeof(GroupPowers));					
			this.treeview_assigned_roles.AppendColumn("",new Gtk.CellRendererToggle(),"active",0);
			this.treeview_assigned_roles.AppendColumn("Role",new CellRendererText(),"text",1);
	        this.treeview_assigned_roles.Model=assigned_roles;
		
            //Tree view for group notices
            notice_list = new Gtk.ListStore(typeof(string), typeof(string), typeof(UUID),typeof(OpenMetaverse.GroupNoticesListEntry));
            this.treeview_notice_list.AppendColumn("From", new CellRendererText(), "text", 0);
            this.treeview_notice_list.AppendColumn("Subject", new CellRendererText(), "text", 1);
            this.treeview_notice_list.Model = notice_list;

            store_membersandroles_powers = new Gtk.TreeStore(typeof(Gdk.Pixbuf), typeof(string), typeof(GroupPowers));
			this.treeview_allowed_ability1.AppendColumn("",new CellRendererPixbuf(),"pixbuf",0);
            this.treeview_allowed_ability1.AppendColumn("Role", new CellRendererText(), "text", 1);
            this.treeview_allowed_ability1.Model = store_membersandroles_powers;

			this.store_roles_list = new Gtk.TreeStore(typeof(string),typeof(string),typeof(string),typeof(UUID));
			this.treeview_roles_list.AppendColumn("Role Name",new CellRendererText(), "text", 0);
			this.treeview_roles_list.AppendColumn("Title",new CellRendererText(), "text", 1);
			this.treeview_roles_list.AppendColumn("Members",new CellRendererText(), "text", 2);
			this.treeview_roles_list.Model=this.store_roles_list;

			this.store_roles_abilities = new Gtk.TreeStore(typeof(Gdk.Pixbuf), typeof(string), typeof(UUID));
			this.treeview_roles_abilities.AppendColumn("",new CellRendererPixbuf(),"pixbuf",0);
			//this.treeview_allowed_ability1.AppendColumn("", new Gtk.CellRendererToggle(), "active", 0);
            this.treeview_roles_abilities.AppendColumn("Allowed Abilities", new CellRendererText(), "text", 1);
            this.treeview_roles_abilities.Model = this.store_roles_abilities;
			
			this.store_roles_members = new Gtk.TreeStore(typeof(string));
			treeview_roles_assigned_members.AppendColumn("Assigned Members", new CellRendererText(), "text", 0);
			treeview_roles_assigned_members.Model=this.store_roles_members;
		
			this.store_abilities=new Gtk.TreeStore(typeof(Gdk.Pixbuf), typeof(string), typeof(GroupPowers));
			this.treeview_abilities.AppendColumn("",new CellRendererPixbuf(),"pixbuf",0);
			this.treeview_abilities.AppendColumn("Abilities", new CellRendererText(), "text", 1);
			this.treeview_abilities.Model=this.store_abilities;
			
			this.store_members_with_ability=new Gtk.TreeStore(typeof(string));
			this.treeview_members_with_ability.AppendColumn("Members with ability",new CellRendererText(), "text", 0);
			this.treeview_members_with_ability.Model=this.store_members_with_ability;
			
			this.store_roles_with_ability=new Gtk.TreeStore(typeof(string));
			this.treeview_roles_with_ability.AppendColumn("Roles with ability",new CellRendererText(), "text", 0);
			this.treeview_roles_with_ability.Model=this.store_roles_with_ability;

			GroupPowers powers=new GroupPowers();
            powers = (GroupPowers)0xffffffff;
			this.showpowers(this.store_abilities,powers);
			this.treeview_abilities.ExpandAll();
			
			
            this.store_groupland=new Gtk.TreeStore(typeof(string),typeof(string),typeof(string));			
            this.treeview_groupland.AppendColumn("Parcel name",new CellRendererText(), "text", 0);
            this.treeview_groupland.AppendColumn("Region",new CellRendererText(), "text", 1);
            this.treeview_groupland.AppendColumn("Area",new CellRendererText(), "text", 2);
            			
            MainClass.client.Groups.GroupProfile += new EventHandler<GroupProfileEventArgs>(Groups_GroupProfile);
            MainClass.client.Groups.GroupMembersReply += new EventHandler<GroupMembersReplyEventArgs>(Groups_GroupMembersReply);
            MainClass.client.Groups.GroupTitlesReply += new EventHandler<GroupTitlesReplyEventArgs>(Groups_GroupTitlesReply);
            MainClass.client.Groups.GroupRoleDataReply += new EventHandler<GroupRolesDataReplyEventArgs>(Groups_GroupRoleDataReply);
            MainClass.client.Groups.GroupRoleMembersReply += new EventHandler<GroupRolesMembersReplyEventArgs>(Groups_GroupRoleMembersReply);
            MainClass.client.Groups.GroupNoticesListReply += new EventHandler<GroupNoticesListReplyEventArgs>(Groups_GroupNoticesListReply);
            MainClass.client.Groups.GroupAccountSummaryReply += new EventHandler<GroupAccountSummaryReplyEventArgs>(Groups_GroupAccountSummaryReply);
            MainClass.client.Self.IM += new EventHandler<InstantMessageEventArgs>(Self_IM);

            MainClass.client.Groups.RequestGroupProfile(groupID);

            rcvd_names.Clear();

            name_poll = true;
            GLib.Timeout.Add(500, updategroupmembers);
            request_members = MainClass.client.Groups.RequestGroupMembers(groupID);

			if(mine)
			{
				request_titles = MainClass.client.Groups.RequestGroupTitles(groupID);
	            request_roles = MainClass.client.Groups.RequestGroupRoles(groupID);  //this is indexed by group ID
	            request_roles_members = MainClass.client.Groups.RequestGroupRolesMembers(groupID);
               
	            request_roles = groupID; //CORRECT
	            request_roles_members = groupID;
	            request_titles = groupID;
	            //request_members = group.ID;
				
				MainClass.client.Groups.RequestGroupNoticesList(groupID);
               // MainClass.client.Groups.RequestGroupAccountSummary(groupID,7,1);
			}
			else
			{
				Gtk.Widget widg=this.notebook1.GetNthPage(1);
				widg.Visible=false;
				widg=this.notebook1.GetNthPage(2);
				widg.Visible=false;
				widg=this.notebook1.GetNthPage(3);
				widg.Visible=false;
				widg=this.notebook1.GetNthPage(4);
				widg.Visible=false;
			}
			
			this.button_join.Sensitive=false;
			this.button_invite.Sensitive=false;
			
            this.DeleteEvent += new DeleteEventHandler(OnDeleteEvent);
	
			this.notebook1.Page=0;
			this.notebook2.Page=0;
            this.label_char_count.Text="";
						
	}
		
        [GLib.ConnectBefore]
        void OnDeleteEvent(object o, DeleteEventArgs args)
		{
            /*
            MainClass.client.Groups.OnGroupProfile -= new OpenMetaverse.GroupManager.GroupProfileCallback(onGroupProfile);
            MainClass.client.Groups.OnGroupMembers -= new OpenMetaverse.GroupManager.GroupMembersCallback(onGroupMembers);
            MainClass.client.Groups.OnGroupTitles -= new OpenMetaverse.GroupManager.GroupTitlesCallback(onGroupTitles);
            MainClass.client.Groups.OnGroupRoles -= new OpenMetaverse.GroupManager.GroupRolesCallback(onGroupRoles);
            MainClass.client.Groups.OnGroupRolesMembers -= new OpenMetaverse.GroupManager.GroupRolesMembersCallback(onGroupRolesMembers);
			MainClass.client.Groups.OnGroupNoticesList -= new GroupManager.GroupNoticesListCallback(Groups_OnGroupNoticesList);
            MainClass.client.Groups.OnGroupAccountSummary -= new OpenMetaverse.GroupManager.GroupAccountSummaryCallback(onAccountSummary);			
           		
			MainClass.client.Self.OnInstantMessage -= new OpenMetaverse.AgentManager.InstantMessageCallback(onIM);			
            */

            MainClass.client.Groups.GroupProfile -= new EventHandler<GroupProfileEventArgs>(Groups_GroupProfile);
            MainClass.client.Groups.GroupMembersReply -= new EventHandler<GroupMembersReplyEventArgs>(Groups_GroupMembersReply);
            MainClass.client.Groups.GroupTitlesReply -= new EventHandler<GroupTitlesReplyEventArgs>(Groups_GroupTitlesReply);
            MainClass.client.Groups.GroupRoleDataReply -= new EventHandler<GroupRolesDataReplyEventArgs>(Groups_GroupRoleDataReply);
            MainClass.client.Groups.GroupRoleMembersReply -= new EventHandler<GroupRolesMembersReplyEventArgs>(Groups_GroupRoleMembersReply);
            MainClass.client.Groups.GroupNoticesListReply -= new EventHandler<GroupNoticesListReplyEventArgs>(Groups_GroupNoticesListReply);
            MainClass.client.Groups.GroupAccountSummaryReply -= new EventHandler<GroupAccountSummaryReplyEventArgs>(Groups_GroupAccountSummaryReply);
            MainClass.client.Self.IM += new EventHandler<InstantMessageEventArgs>(Self_IM);

            Logger.Log("GroupInfo view go bye bye",Helpers.LogLevel.Debug);
            //this.Destroy();	
			//Finalize();
			//System.GC.SuppressFinalize(this);
		}
			
		~GroupInfo()
        {
           Logger.Log("Group info cleaned up",Helpers.LogLevel.Debug);
        }

        void Groups_GroupAccountSummaryReply(object sender, GroupAccountSummaryReplyEventArgs e)
		{
            if (e.GroupID != this.groupkey)
                return;

				Gtk.Application.Invoke(delegate{
                this.label_group_balance.Text=e.Summary.Balance.ToString();
				this.label_grouptaxcurrent.Text=e.Summary.GroupTaxCurrent.ToString();
				this.label_grouptaxesitmate.Text=e.Summary.GroupTaxEstimate.ToString();
				this.label_landtaxcurrent.Text=e.Summary.LandTaxCurrent.ToString();
				this.label_landtaxestimate.Text=e.Summary.LandTaxEstimate.ToString();
                this.label_total_credits.Text=e.Summary.TotalCredits.ToString();
                this.label_total_debits.Text=e.Summary.TotalDebits.ToString();
		 
          });		
	    }
		
        void Groups_GroupNoticesListReply(object sender, GroupNoticesListReplyEventArgs e)
        {
			if (e.GroupID != this.groupkey)
			return;
			
            e.Notices.ForEach(delegate (GroupNoticesListEntry notice){
                this.recieved_notices.Add(notice.NoticeID);
				Gtk.Application.Invoke(delegate{
    				this.notice_list.AppendValues(notice.FromName, notice.Subject, notice.NoticeID,notice);            
                    Console.Write("Notice list entry: From: "+notice.FromName+"\nSubject: "+notice.Subject + "\n");
			    });
            });
       }

        void Groups_GroupRoleMembersReply(object sender, GroupRolesMembersReplyEventArgs e)
 		{
            if (e.GroupID != this.groupkey)
                return; 
            
            Console.Write("Group roles members recieved\n");

            group_roles_members = e.RolesMembers;

			Gtk.Application.Invoke(delegate{
			this.button_invite.Sensitive=checkaccess(MainClass.client.Self.AgentID,GroupPowers.Invite);
			this.button_send_notice.Sensitive=checkaccess(MainClass.client.Self.AgentID,GroupPowers.SendNotices);	
             });

			store_roles_list.Foreach(delegate(Gtk.TreeModel mod, Gtk.TreePath path, Gtk.TreeIter iter)
            {
                UUID id = (UUID)store_roles_list.GetValue(iter, 3);
                List<KeyValuePair<UUID,UUID>> roleslist=new List<KeyValuePair<UUID,UUID>>();
                if (id == UUID.Zero)
                {
                        int count = group_members.Count;
                        store_roles_list.SetValue(iter, 2, count.ToString());
                        return false;
                }
                //if (MainClass.client.Groups.GroupRolesMembersCaches.TryGetValue(this.groupkey,out roleslist))
                {
                    int x = 0;
                    foreach (KeyValuePair<UUID, UUID> kvp2 in group_roles_members)
                    {
                        if (kvp2.Key == id)
                            x++;
                    }
                    store_roles_list.SetValue(iter, 2, x.ToString());
                }

                return false;
            });

			//rolesmembers=rolesmember;
		}

        void Groups_GroupRoleDataReply(object sender, GroupRolesDataReplyEventArgs e)
		{

            if (e.GroupID != this.groupkey)
                return;

            this.group_roles = e.Roles;

 			// Maybe we should flag up that the roles have been recieved?
			Console.Write("Group roles recieved\n");
			//grouproles=roles;
			
			foreach(KeyValuePair <UUID,GroupRole> kvp in e.Roles)
			{
                //The count is not valid untill grouprolesmembers has returned *sigh*
                //TO DO MOVE ME THERE
                string count="";
                List<KeyValuePair<UUID,UUID>> roleslist=new List<KeyValuePair<UUID,UUID>>();
                if (kvp.Key == UUID.Zero)
                {
                    count = group_members.Count.ToString();
                }
                else
                {
                    //if (MainClass.client.Groups.GroupRolesMembersCaches.TryGetValue(this.groupkey, out roleslist))
                    {
                        int x = 0;
                        List<UUID> seen = new List<UUID>();
                        foreach (KeyValuePair<UUID, UUID> kvp2 in group_roles_members)
                        {

                            if (kvp2.Key == kvp.Value.ID && !seen.Contains(kvp2.Value))
                            {
                                x++;
                                seen.Add(kvp2.Value);
                            }
                        }
                        count = x.ToString();
                    }
                }

				this.store_roles_list.AppendValues(kvp.Value.Name,kvp.Value.Title,count,kvp.Value.ID);
			}

			Gtk.Application.Invoke(delegate{
			this.button_invite.Sensitive=checkaccess(MainClass.client.Self.AgentID,GroupPowers.Invite);
			});
		}
		
        [GLib.ConnectBefore]
        void GroupWindow_DeleteEvent(object o, DeleteEventArgs args)
        {
            nobody_cares = true;
            MainClass.client.Groups.GroupProfile -= new EventHandler<GroupProfileEventArgs>(Groups_GroupProfile);
            MainClass.client.Groups.GroupMembersReply -= new EventHandler<GroupMembersReplyEventArgs>(Groups_GroupMembersReply);
            MainClass.client.Groups.GroupTitlesReply -= new EventHandler<GroupTitlesReplyEventArgs>(Groups_GroupTitlesReply);
            MainClass.client.Groups.GroupRoleDataReply -= new EventHandler<GroupRolesDataReplyEventArgs>(Groups_GroupRoleDataReply);
            MainClass.client.Groups.GroupRoleMembersReply -= new EventHandler<GroupRolesMembersReplyEventArgs>(Groups_GroupRoleMembersReply);
            MainClass.client.Groups.GroupNoticesListReply -= new EventHandler<GroupNoticesListReplyEventArgs>(Groups_GroupNoticesListReply);
            MainClass.client.Groups.GroupAccountSummaryReply -= new EventHandler<GroupAccountSummaryReplyEventArgs>(Groups_GroupAccountSummaryReply);
            MainClass.client.Self.IM -= new EventHandler<InstantMessageEventArgs>(Self_IM);
	     
			
			this.DeleteEvent -= new DeleteEventHandler(GroupWindow_DeleteEvent);
        }		

        void Groups_GroupTitlesReply(object sender, GroupTitlesReplyEventArgs e)
		{

            if (e.GroupID != this.groupkey)
                return;

            group_titles=e.Titles;

            if (titles.Count == 0)
                return;

            Console.Write("Group titles recieved\n");

			Gtk.Application.Invoke(delegate {	
		
			//combobox_active_title.Clear();
			int x=0;
			    foreach(KeyValuePair  <UUID,OpenMetaverse.GroupTitle> title in group_titles)
			    { 
					Logger.Log("Appending "+title.Value.Title,Helpers.LogLevel.Debug);
                    combobox_active_title.AppendText(title.Value.Title);
				}				
				trysetcurrenttitle();
			});
		}
		
		void trysetcurrenttitle()
		{
			Logger.Log("** TRY SET CURRENT TITLE",Helpers.LogLevel.Debug);
			
			GroupMember member;
			if(group_members.TryGetValue(MainClass.client.Self.AgentID,out member))
			{
			Logger.Log("** FOUND MEMBER",Helpers.LogLevel.Debug);

				combobox_active_title.Model.Foreach(
					delegate(TreeModel model, TreePath path, TreeIter iter)
				    {
						string title = (string)model.GetValue(iter,0);
								Logger.Log("** CHECKING TITLE "+title+" against "+member.Title,Helpers.LogLevel.Debug);

					    if (title==member.Title)
						{	
							combobox_active_title.SetActiveIter(iter);
							return true;
						
						}
						return false;
					});
				
				
			}
			else
			{
				Logger.Log("Defering title untill group member load",Helpers.LogLevel.Debug);	
			}
		}

        bool updategroupmembers()
        {
            Logger.Log("Update group members",Helpers.LogLevel.Debug);
            List<UUID> names = new List<UUID>();

            //???????????
           // if (!MainClass.client.Groups.GroupMembersCaches.ContainsKey(request_members))
             //   return name_poll;

         //   lock(MainClass.client.Groups.GroupMembersCaches)
            {
                foreach (KeyValuePair<UUID, GroupMember> member in group_members)
                {
                    if (!rcvd_names.Contains(member.Key))
                    {
                        rcvd_names.Add(member.Key);
                        names.Add(member.Key);

                        Gtk.TreeIter iter = store_members.AppendValues("Waiting...", member.Value.Title, member.Value.OnlineStatus, member.Value.ID);

                        AsyncNameUpdate ud = new AsyncNameUpdate(member.Value.ID, false);
                        ud.addparameters(iter);
                        ud.onNameCallBack += delegate(string namex, object[] values) { if (nobody_cares) { return; } Gtk.TreeIter iterx = (Gtk.TreeIter)values[0]; store_members.SetValue(iterx, 0, namex); };
                        ud.go();

                        Gtk.TreeIter iter2 = store_membersandroles_members.AppendValues("Waiting...", member.Value.Contribution.ToString(), member.Value.Title, member.Value.ID);
                        AsyncNameUpdate ud2 = new AsyncNameUpdate(member.Value.ID, false);
                        ud2.addparameters(iter2);
                        ud2.onNameCallBack += delegate(string namex, object[] values) { if (nobody_cares) { return; } Gtk.TreeIter iterx = (Gtk.TreeIter)values[0]; store_membersandroles_members.SetValue(iterx, 0, namex); };
                        ud2.go();


                    }
                }
            }

            MainClass.name_cache.reqnames(names);

          
            this.treeview_members.QueueDraw();
            this.treeview_members1.QueueDraw();
            

            return name_poll;
        }


        void Groups_GroupMembersReply(object sender, GroupMembersReplyEventArgs e)
		{

            if (e.GroupID != this.groupkey)
                return;

            group_members = e.Members;
			
			trysetcurrenttitle();

            Logger.Log("All group members recieved",Helpers.LogLevel.Debug);
            name_poll = false;

            store_roles_list.Foreach(delegate(Gtk.TreeModel mod, Gtk.TreePath path, Gtk.TreeIter iter)
            {
                UUID id = (UUID)store_roles_list.GetValue(iter, 3);
                List<KeyValuePair<UUID, UUID>> roleslist = new List<KeyValuePair<UUID, UUID>>();
                if (id == UUID.Zero)
                {
					//if(MainClass.client.Groups.GroupMembersCaches.ContainsKey(request_members))
					{
	                    int count = group_members.Count;
	                    store_roles_list.SetValue(iter, 2, count.ToString());
					}
                    return true;
                }
                return false;
            });

            return;

		}
   		
        void Groups_GroupProfile(object sender, GroupProfileEventArgs e)
		{
			
			if(e.Group.ID!=this.groupkey)
				return;
			
			Gtk.Application.Invoke(delegate {	
			
			this.entry_enrollmentfee.Text=e.Group.MembershipFee.ToString();
			
			if(e.Group.MembershipFee>0)
				this.checkbutton_mature.Active=true;
			
			    if(this.already_member==true)
				{
					foreach(AvatarGroup avgroup in MainClass.win.avatarGroups)
					{		
	 					if(avgroup.GroupID==this.groupkey)
						{
					        //this.checkbutton_group_notices.Active= avgroup.AcceptNotices;						
							//this.checkbutton_showinpofile.Active = avgroup.ListInProfile;
	                        break;							
						}
				}
			}
				
			this.checkbutton_openenrolement.Active=e.Group.OpenEnrollment;
			this.checkbutton_showinsearch.Active=e.Group.ShowInList;
			this.checkbutton_mature.Active=e.Group.MaturePublish;
			this.textview_group_charter.Buffer.Text=e.Group.Charter;

			if((e.Group.Powers & GroupPowers.SendNotices)==GroupPowers.SendNotices)
					this.button_send_notice.Sensitive=true;
				else
					this.button_send_notice.Sensitive=false;
		
				
			TryGetImage img=new TryGetImage(this.image_group_emblem,e.Group.InsigniaID,128,128,false);
			this.label_name.Text=e.Group.Name;
	
			AsyncNameUpdate ud=new AsyncNameUpdate(e.Group.FounderID,false);  
			ud.onNameCallBack += delegate(string namex,object[] values){this.label_foundedby.Text="Founded by "+namex;};
            ud.go();

			this.entry_enrollmentfee.Text=e.Group.MembershipFee.ToString();
			if(e.Group.MembershipFee>0)
				this.checkbutton_mature.Active=true;
			
			this.checkbutton_openenrolement.Active=e.Group.OpenEnrollment;
			this.checkbutton_showinsearch.Active=e.Group.ShowInList;
			this.checkbutton_mature.Active=e.Group.MaturePublish;
			this.textview_group_charter.Buffer.Text=e.Group.Charter;
				
			if(!this.already_member)
			{
				if(e.Group.OpenEnrollment==true)
					this.button_join.Sensitive=true;					
            }
				
				this.checkbutton_group_notices.Sensitive=this.already_member;
				this.checkbutton_showinpofile.Sensitive=this.already_member;

			});
		}
		
		bool myfunc_members(Gtk.TreeModel mod, Gtk.TreePath path, Gtk.TreeIter iter)
		{			
			string name=(string)store_members.GetValue(iter,0);
			UUID id =(UUID)store_members.GetValue(iter,3);
			string member_name;
			if(MainClass.name_cache.av_names.TryGetValue(id,out member_name))
			{
				store_members.SetValue(iter,0,member_name);
			}
				return false;
		}

		protected virtual void OnComboboxActiveTitleChanged (object sender, System.EventArgs e)
		{
            foreach (KeyValuePair <UUID,GroupTitle>title in group_titles)
            {
                if(title.Value.Title==this.combobox_active_title.ActiveText)
                    MainClass.client.Groups.ActivateTitle(this.groupkey,title.Key);
            }
		}

		protected virtual void OnCheckbuttonGroupNoticesClicked (object sender, System.EventArgs e)
		{
			MainClass.client.Groups.SetGroupAcceptNotices(this.groupkey,this.checkbutton_group_notices.Active,this.checkbutton_showinpofile.Active);
		}

		protected virtual void OnCheckbuttonShowinpofileClicked (object sender, System.EventArgs e)
		{
			MainClass.client.Groups.SetGroupAcceptNotices(this.groupkey,this.checkbutton_group_notices.Active,this.checkbutton_showinpofile.Active);
		}

		protected virtual void OnTreeviewMembers1CursorChanged (object sender, System.EventArgs e)
		{
			//This is the Members List on the Members role tab
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
            Dictionary <UUID, GroupRole> grouproles;
            Dictionary<UUID, GroupMember> groupmembers;
            List<KeyValuePair<UUID,UUID>> rolesmembers;
			
			if(this.treeview_members1.Selection.GetSelected(out mod,out iter))			
			{
				UUID id=(UUID)mod.GetValue(iter,3);
                GroupMember member;

                store_membersandroles_powers.Clear();

				Logger.Log("Tring to get group powers for id "+id.ToString(),Helpers.LogLevel.Debug);
				
                if (group_members.TryGetValue(id, out member))
                {
					Logger.Log("Got a power "+member.Powers.ToString(),Helpers.LogLevel.Debug);
					showpowers(store_membersandroles_powers,member.Powers);
					this.treeview_allowed_ability1.ExpandAll();
                }

    		    this.assigned_roles.Clear();
				
			    Console.Write("Got group roles from cache\n");
	
				foreach(KeyValuePair<UUID,GroupRole> kvp in group_roles)
				{
					bool ingroup=false;
					Console.Write("Appending value "+kvp.Value.Name+"\n");

					foreach(KeyValuePair<UUID,UUID> rolesmember in this.group_roles_members)
					{
						if((rolesmember.Value==id && kvp.Value.ID==rolesmember.Key) || kvp.Key==UUID.Zero)
							ingroup=true;
					}
					
					assigned_roles.AppendValues(ingroup,kvp.Value.Name,kvp.Value.ID);	
				}									
			}
		}

		protected virtual void OnTreeviewNoticeListCursorChanged (object sender, System.EventArgs e)
		{
			//This is the Members List on the Members role tab
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
				if(this.treeview_notice_list.Selection.GetSelected(out mod,out iter))			
			{
				UUID id=(UUID)mod.GetValue(iter,2);
                 
				GroupNoticesListEntry notice=(GroupNoticesListEntry)mod.GetValue(iter,3);
				MainClass.client.Groups.RequestGroupNotice(id);
                this.entry1.Text=notice.Subject;
				if(notice.HasAttachment)
				{
				this.entry_attachment.Text="Attachment :"+notice.AssetType.ToString();
				}
				else
                {
                this.entry_attachment.Text="";
                }               
			}
		
		}

        void Self_IM(object sender, InstantMessageEventArgs e)
        {
			
			if(e.IM.Dialog!=OpenMetaverse.InstantMessageDialog.GroupNoticeRequested)
				return;
		      
            textview_notice.Buffer.Text=e.IM.Message;
            
		}

		protected virtual void OnTreeviewRolesListCursorChanged (object sender, System.EventArgs e)
		{
				//This is the Members List on the Members role tab
					Gtk.TreeModel mod;
					Gtk.TreeIter iter;
					if(this.treeview_roles_list.Selection.GetSelected(out mod,out iter))			
					{
						UUID id=(UUID)mod.GetValue(iter,3);
						Dictionary <UUID, GroupRole> grouproles;

                       // if (!MainClass.client.Groups.GroupRolesCaches.TryGetValue(request_roles, out grouproles))
                         //   return;

						GroupRole role;
						group_roles.TryGetValue(id,out role);
						this.entry_roles_name.Text=role.Name;
			            this.entry_roles_title.Text=role.Title;
	                    this.textview_roles_description.Buffer.Text=role.Description;             
                        this.store_roles_abilities.Clear();
				        showpowers(this.store_roles_abilities,role.Powers);
			            this.treeview_roles_abilities.ExpandAll();   
			            
				        //now to fine members with this role
				        List<KeyValuePair<UUID,UUID>> rolesmembers;
                        //if (!MainClass.client.Groups.GroupRolesMembersCaches.TryGetValue(this.request_roles_members, out rolesmembers))
                        //    return;
				
				        this.store_roles_members.Clear();

                        List<UUID> seen = new List<UUID>();
                        if (role.ID == UUID.Zero)
                        {
                            foreach (KeyValuePair<UUID, GroupMember> member in this.group_members)
                            {
                                if(seen.Contains(member.Key))
                                    continue;

                                string name = "";
                                MainClass.name_cache.av_names.TryGetValue(member.Key, out name);
                                this.store_roles_members.AppendValues(name);
                                seen.Add(member.Key);

                            }
                            return;
                        }

					    foreach(KeyValuePair<UUID,UUID> rolesmember in this.group_roles_members)
					    {
					        // rolesmember.Value is the user UUID
					        // .key is the group role UUIS
						    if(rolesmember.Key==id)
					        {
                                if (seen.Contains(rolesmember.Value))
                                    continue;
						          string name="";
						          MainClass.name_cache.av_names.TryGetValue(rolesmember.Value,out name);
						          this.store_roles_members.AppendValues(name);
                                  seen.Add(rolesmember.Value);
					        }
					    }

				
				
			       }			

		}

        void showpowers(Gtk.TreeStore store,GroupPowers powers)
        {
					Gtk.TreeIter iterx;
					bool test;
                    iterx = store.AppendValues(folder_open, "Membership Managment", GroupPowers.None);
					test=(powers & GroupPowers.Invite) == GroupPowers.Invite;
					store.AppendValues(iterx,test?tick:cross,"Invite people to group",GroupPowers.Invite);
					test=(powers & GroupPowers.Eject) == GroupPowers.Eject;
					store.AppendValues(iterx,test?tick:cross,"Eject members",GroupPowers.Eject);
					test=(powers & GroupPowers.ChangeOptions) == GroupPowers.ChangeOptions; //?????????
					store.AppendValues(iterx,test?tick:cross,"Toggle Open Enrollment",GroupPowers.ChangeOptions);

                   
					iterx = store.AppendValues(folder_open, "Roles", GroupPowers.None);
					test=(powers & GroupPowers.CreateRole) == GroupPowers.CreateRole; //?????????
					store.AppendValues(iterx,test?tick:cross,"Toggle Open Enrollment",GroupPowers.CreateRole);
					test=(powers & GroupPowers.DeleteRole) == GroupPowers.DeleteRole; //?????????
					store.AppendValues(iterx,test?tick:cross,"Delete ROles",GroupPowers.DeleteRole);
					test=(powers & GroupPowers.RoleProperties) == GroupPowers.RoleProperties; //?????????
					store.AppendValues(iterx,test?tick:cross,"Change ROle names,titles",GroupPowers.RoleProperties);
					test=(powers & GroupPowers.AssignMemberLimited) == GroupPowers.AssignMemberLimited; //?????????
					store.AppendValues(iterx,test?tick:cross,"Assign Members to Assigners Role",GroupPowers.AssignMemberLimited);
					test=(powers & GroupPowers.AssignMember) == GroupPowers.AssignMember; //?????????
					store.AppendValues(iterx,test?tick:cross,"Assign Members to Any Role",GroupPowers.AssignMember);
					test=(powers & GroupPowers.RemoveMember) == GroupPowers.RemoveMember; //?????????
					store.AppendValues(iterx,test?tick:cross,"Remove Members from Roles",GroupPowers.RemoveMember);
					test=(powers & GroupPowers.ChangeIdentity) == GroupPowers.ChangeIdentity; //?????????
					store.AppendValues(iterx,test?tick:cross,"Assign and Remove Abilities",GroupPowers.ChangeIdentity);
                  
  
					iterx = store.AppendValues(folder_open, "Parcel Managment", GroupPowers.None);
					test=(powers & GroupPowers.LandDeed) == GroupPowers.LandDeed; //?????????
					store.AppendValues(iterx,test?tick:cross,"Deed land and buy land for group",GroupPowers.LandDeed);
					test=(powers & GroupPowers.LandRelease) == GroupPowers.LandRelease; //?????????
					store.AppendValues(iterx,test?tick:cross,"Abandon land",GroupPowers.LandRelease);
					test=(powers & GroupPowers.LandSetSale) == GroupPowers.LandSetSale; //?????????
					store.AppendValues(iterx,test?tick:cross,"Set land for sale info",GroupPowers.LandSetSale);					
					test=(powers & GroupPowers.LandDivideJoin) == GroupPowers.LandDivideJoin;
					store.AppendValues(iterx,test?tick:cross,"Join and Divide Parcels",GroupPowers.LandDivideJoin);
					                                              
                    iterx = store.AppendValues(folder_open, "Parcel Identy", GroupPowers.None);
					test=(powers & GroupPowers.FindPlaces) == GroupPowers.FindPlaces;
					store.AppendValues(iterx,test?tick:cross,"Toggle show in Find Places",GroupPowers.FindPlaces);
					test=(powers & GroupPowers.LandChangeIdentity) == GroupPowers.LandChangeIdentity;
					store.AppendValues(iterx,test?tick:cross,"Change parcel name and Description",GroupPowers.LandChangeIdentity);
					test=(powers & GroupPowers.SetLandingPoint) == GroupPowers.SetLandingPoint;
					store.AppendValues(iterx,test?tick:cross,"Set Landing point",GroupPowers.SetLandingPoint);				
						
					iterx = store.AppendValues(folder_open, "Parcel Settings", GroupPowers.None);
					test=(powers & GroupPowers.ChangeMedia) == GroupPowers.ChangeMedia;
					store.AppendValues(iterx,test?tick:cross,"Change music & media settings",GroupPowers.ChangeMedia);
    				test=(powers & GroupPowers.ChangeOptions) == GroupPowers.ChangeOptions;
					store.AppendValues(iterx,test?tick:cross,"Toggle various about->land options",GroupPowers.ChangeOptions);
                    
					iterx = store.AppendValues(folder_open, "Parcel Powers", GroupPowers.None);
    				test=(powers & GroupPowers.AllowEditLand) == GroupPowers.AllowEditLand;
					store.AppendValues(iterx,test?tick:cross,"Always allow Edit Terrain",GroupPowers.AllowEditLand);
    				test=(powers & GroupPowers.AllowFly) == GroupPowers.AllowFly;
					store.AppendValues(iterx,test?tick:cross,"Always allow fly",GroupPowers.AllowFly);
    				test=(powers & GroupPowers.AllowRez) == GroupPowers.AllowRez;
					store.AppendValues(iterx,test?tick:cross,"Always allow Create Objects",GroupPowers.AllowRez);
    				test=(powers & GroupPowers.AllowLandmark) == GroupPowers.AllowLandmark;
                    store.AppendValues(iterx, test?tick:cross, "Always allow Create Landmarks", GroupPowers.AllowLandmark);
    				test=(powers & GroupPowers.AllowSetHome) == GroupPowers.AllowSetHome;
					store.AppendValues(iterx,test?tick:cross,"Allow Set Home to Hete on group land",GroupPowers.AllowSetHome);
					
			        iterx = store.AppendValues(folder_open, "Parcel Access", GroupPowers.None);
    				test=(powers & GroupPowers.LandManageAllowed) == GroupPowers.LandManageAllowed;
					store.AppendValues(iterx,test?tick:cross,"Manage parcel Access lists",GroupPowers.LandManageAllowed);
    				test=(powers & GroupPowers.LandManageBanned) == GroupPowers.LandManageBanned;
					store.AppendValues(iterx,test?tick:cross,"Manage Ban lists",GroupPowers.LandManageBanned);
    				test=(powers & GroupPowers.LandEjectAndFreeze) == GroupPowers.LandEjectAndFreeze;
					store.AppendValues(iterx,test?tick:cross,"Eject and freeze Residents on parcel",GroupPowers.LandEjectAndFreeze);
					
                    iterx = store.AppendValues(folder_open, "Parcel Content", GroupPowers.None);
                    test=(powers & GroupPowers.ReturnGroupOwned) == GroupPowers.ReturnGroupOwned;
					store.AppendValues(iterx,test?tick:cross,"Return objects owner by group",GroupPowers.ReturnGroupSet);
                    test=(powers & GroupPowers.ReturnGroupSet) == GroupPowers.ReturnGroupSet;
					store.AppendValues(iterx,test?tick:cross,"Return objects set to group",GroupPowers.ReturnGroupSet);
                    test=(powers & GroupPowers.ReturnNonGroup) == GroupPowers.ReturnNonGroup;
					store.AppendValues(iterx,test?tick:cross,"Return non-group objects",GroupPowers.ReturnNonGroup);
                    test=(powers & GroupPowers.LandGardening) == GroupPowers.LandGardening;
			        store.AppendValues(iterx,test?tick:cross,"Landscaping using Linden Plants",GroupPowers.LandGardening);
					
                    iterx = store.AppendValues(folder_open, "Object Managment", GroupPowers.None);
                    test=(powers & GroupPowers.DeedObject) == GroupPowers.DeedObject;
					store.AppendValues(iterx,test?tick:cross,"Deed objects to group",GroupPowers.DeedObject);
			        test=(powers & GroupPowers.ObjectManipulate) == GroupPowers.ObjectManipulate;
					store.AppendValues(iterx,test?tick:cross,"Manipulate (move,copy,modify) group objetcs",GroupPowers.ObjectManipulate);
                    test=(powers & GroupPowers.ObjectSetForSale) == GroupPowers.ObjectSetForSale;
					store.AppendValues(iterx,test?tick:cross,"Set group objects for sale",GroupPowers.ObjectSetForSale);

                    iterx = store.AppendValues(folder_open, "Notices", GroupPowers.None);
					test=(powers & GroupPowers.SendNotices) == GroupPowers.SendNotices;
					store.AppendValues(iterx,test?tick:cross,"Send Notices",GroupPowers.SendNotices);
                    test=(powers & GroupPowers.ReceiveNotices) == GroupPowers.ReceiveNotices;
					store.AppendValues(iterx,test?tick:cross,"Receive Notices and view past Notices",GroupPowers.ReceiveNotices);

                    iterx = store.AppendValues(folder_open, "Proposals", GroupPowers.None);
                    test=(powers & GroupPowers.StartProposal) == GroupPowers.StartProposal;
					store.AppendValues(iterx,test?tick:cross,"Create Proposals",GroupPowers.StartProposal);
                    test=(powers & GroupPowers.VoteOnProposal) == GroupPowers.VoteOnProposal;
					store.AppendValues(iterx,test?tick:cross,"Vote on Proposals",GroupPowers.VoteOnProposal);

                    iterx = store.AppendValues(folder_open, "Chat", GroupPowers.None);
			        test=(powers & GroupPowers.JoinChat) == GroupPowers.JoinChat;
			        store.AppendValues(iterx,test?tick:cross,"Join Group Chat",GroupPowers.JoinChat);
			        test=(powers & GroupPowers.AllowVoiceChat) == GroupPowers.AllowVoiceChat;
					store.AppendValues(iterx,test?tick:cross,"Join Group Voice Chat",GroupPowers.AllowVoiceChat);
    
				this.treeview_allowed_ability1.ExpandAll();
				
				
				
			}
					
		protected virtual void OnTreeviewAbilitiesCursorChanged (object sender, System.EventArgs e)
		{
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			if(this.treeview_abilities.Selection.GetSelected(out mod,out iter))
            {
                GroupPowers powers = (GroupPowers)mod.GetValue(iter, 2);

                //power should be singular
                List<KeyValuePair<UUID, UUID>> rolesmembers;

            //    if (!MainClass.client.Groups.GroupRolesMembersCaches.TryGetValue(request_roles_members, out rolesmembers))
            //        return;

                this.store_members_with_ability.Clear();
                this.store_roles_with_ability.Clear();

                if (powers == GroupPowers.None)
                    return;

                Dictionary<UUID, GroupRole> grouproles;
              //  MainClass.client.Groups.GroupRolesCaches.TryGetValue(request_roles, out grouproles);


                List<UUID> seen = new List<UUID>();

                foreach (KeyValuePair<UUID, UUID> rolesmember in this.group_roles_members)
                {
                    // rolesmember.Value is the user UUID
                    // .key is the group role UUIS
                    UUID user = rolesmember.Value;
                    UUID rolekey = rolesmember.Key;
                    GroupRole role;
                    if (!group_roles.TryGetValue(rolekey, out role))
                        continue;
                    if ((role.Powers & powers) == powers)
                    {
                        string name = "";

                        if (!MainClass.name_cache.av_names.TryGetValue(user, out name))
                            continue;

                        if (seen.Contains(rolesmember.Value))
                            continue;

                        this.store_members_with_ability.AppendValues(name);
                        seen.Add(rolesmember.Value);
                    }
                }

                {
                    GroupRole role;
                    if (group_roles.TryGetValue(UUID.Zero, out role))
                    {
                        if ((role.Powers & powers) == powers)
                        {
                            foreach (KeyValuePair<UUID, GroupMember> member in this.group_members)
                            {
                                if (seen.Contains(member.Key))
                                    continue;

                                string name = "";
                                if (seen.Contains(member.Key))
                                    continue;

                                if (!MainClass.name_cache.av_names.TryGetValue(member.Key, out name))
                                    continue;
                                this.store_members_with_ability.AppendValues(name);
                                seen.Add(member.Key);

                            }
                        }
                    }
                }





                foreach (KeyValuePair<UUID, GroupRole> role in group_roles)
                {

                    if ((role.Value.Powers & powers) == powers)
                    {

                        this.store_roles_with_ability.AppendValues(role.Value.Name);
                    }


                }
            }
        }

		protected virtual void OnButtonJoinClicked (object sender, System.EventArgs e)
		{
           int cost=0;
		   int.TryParse(this.entry_enrollmentfee.Text,out cost);
		   if(cost>0)
           {
              Gtk.MessageDialog md= new Gtk.MessageDialog(MainClass.win,DialogFlags.Modal,MessageType.Question,ButtonsType.YesNo,false,"Are you sure you wish to join the group\n"+this.label_name.Text+"\n it will COST YOU L$"+cost.ToString());
			  Gtk.ResponseType res=(ResponseType)md.Run();
			  md.Destroy();
			  if(res==Gtk.ResponseType.Yes)
		         MainClass.client.Groups.RequestJoinGroup(this.groupkey); 
		      }
			  else
		         MainClass.client.Groups.RequestJoinGroup(this.groupkey); 	
		}

		protected virtual void OnButtonInviteClicked (object sender, System.EventArgs e)
		{
			NamePicker np=new NamePicker(); 
			List <UUID> roles=new List <UUID>();
            roles.Add(UUID.Zero);
			np.UserSel += delegate (UUID id,UUID asset,string item_name,string user_name,List <InventoryBase> items){MainClass.client.Groups.Invite(this.groupkey,roles,id);};
            np.Show();       			  	
		}
	
		protected virtual void OnButtonLeaveClicked (object sender, System.EventArgs e)
		{
            Gtk.MessageDialog md= new Gtk.MessageDialog(MainClass.win,DialogFlags.Modal,MessageType.Question,ButtonsType.YesNo,false,"Are you sure you wish to leave the group\n"+this.label_name.Text);
			Gtk.ResponseType res=(ResponseType)md.Run();
			md.Destroy();
			if(res==Gtk.ResponseType.Yes)
            {
			    MainClass.client.Groups.LeaveGroup(this.groupkey);	
            }				
			
	    }
		
		bool checkaccess(UUID agent,OpenMetaverse.GroupPowers power)
			{
            //Does this agent have the request power			
		    Dictionary <UUID, GroupRole> grouproles;
            List<KeyValuePair<UUID,UUID>> rolesmembers;
	
		     GroupRole role;
             // rolesmember.Value is the user UUID
	         // .key is the group role UUID			
					   if(group_roles.TryGetValue(UUID.Zero,out role))
						{
					        if((role.Powers & power) == power)
					        return true;
                        }
			
			
			foreach(KeyValuePair <UUID,UUID> rolesmember in this.group_roles_members)
				{
				if(rolesmember.Value==agent)
					{

					   if(group_roles.TryGetValue(rolesmember.Key,out role))
						{
					        if((role.Powers & power) == power)
					        return true;
                        }
                }	
			
            } 			
					
          return false;
        }

		protected virtual void OnButtonSendNoticeClicked (object sender, System.EventArgs e)
		{
			if(this.button_send_notice.Label=="Create new notice")
				{
			 this.button_send_notice.Label="Send notice";
					this.textview_notice.Editable=true;
                this.entry_attachment.Editable=true;	
                this.entry_attachment.Text="";
                this.textview_notice.Buffer.Clear();
		    }
			else
				{
				this.button_send_notice.Label="Create new notice";
			   GroupNotice notice=new GroupNotice();
                 string msg= this.textview_notice.Buffer.Text;
				notice.Message=msg.Replace("\n","\r\n");
				notice.OwnerID=MainClass.client.Self.AgentID;
                notice.Subject=this.entry_attachment.Text;
				notice.AttachmentID=UUID.Zero;  
                MainClass.client.Groups.SendGroupNotice(this.groupkey,notice);
                this.textview_notice.Editable=false;
                this.entry_attachment.Editable=false;	
		       
      }
		
		}

			protected virtual void OnButtonAttachmentClicked (object sender, System.EventArgs e)
		    {
			Gtk.TreeModel mod;
			Gtk.TreeIter iter;
			
            if(this.treeview_notice_list.Selection.GetSelected(out mod,out iter))			
			{
                    
					GroupNoticesListEntry notice=(GroupNoticesListEntry)mod.GetValue(iter,3);
					if(notice.AssetType==AssetType.Notecard)
					{
                   //NotecardReader nr=new NotecardReader(notice.
                  
                   
			}            

            }
		}
	}
}
