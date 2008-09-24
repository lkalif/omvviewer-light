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

// Main.cs created with MonoDevelop
// User: robin at 08:52 11/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using System.Collections.Generic;
using Gtk;
using OpenMetaverse;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Configuration.Assemblies;



namespace omvviewerlight
{
	class MainClass
	{
        [DllImport("Kernel32")]
            private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public static GridClient client;
		public static MainWindow win;

		public static AVNameCache name_cache;

		public static void Main (string[] args)
		{

            bool hiddenconsole = false;
			// Now boot the libsecondlife layer so it is global to our namespace
            System.IO.StreamWriter aStreamWriter;
             
            aStreamWriter = new System.IO.StreamWriter("log.txt");

            try
            {
                IntPtr hWnd = GetConsoleWindow();
                DisplayAppSettings();
               // ShowWindow(hWnd, 0);
                hiddenconsole = true;
           
            }
            catch(Exception e)
            {

            }


            try
            {
                client = new GridClient();
              
				name_cache=new AVNameCache();
                Application.Init();
                win = new MainWindow();
                win.Show();
                win.DeleteEvent += delete_event;

                Application.Run();
            }
            catch(Exception e)
            {
                if (hiddenconsole)
                {
                    IntPtr hWnd = GetConsoleWindow();
                    ShowWindow(hWnd, 1);
                }

                Console.Write("The application died in a big heap\n This is the debug i caught :-");
                Console.Write(e.Message);
                Console.Write(e.Source);
                Console.Write(e.StackTrace);
               
            }
			
		}

        static void delete_event(object obj, DeleteEventArgs args)
        {
           
            if(client.Network.Connected)
                client.Network.Logout();
      
        }


		public static string cleandistance(string dist,int dp)
		{			
			int pos=dist.IndexOf(".");
			dp++;
			
			if(pos==-1)
				return dist;
			
			if((pos+dp)>dist.Length)
				return dist;
			
			return dist.Substring(0,pos+dp);		
		}		
		
		public static string prettyvector(Vector3 vector,int dp)
		{
			Vector3d vec = new Vector3d(vector.X,vector.Y,vector.Z);
			return prettyvector(vec,dp);
		}
		
		public static string prettyvector(Vector3d vector,int dp)
		{
			string ret;
			
			string x,y,z;
			x=cleandistance(vector.X.ToString(),dp);
			y=cleandistance(vector.Y.ToString(),dp);
			z=cleandistance(vector.Z.ToString(),dp);
			
			ret="<"+x+","+y+","+z+">";
			
			return ret;
		}

        // Show how to use AppSettings.
        static void DisplayAppSettings()
        {

            // Get the AppSettings collection.
            NameValueCollection appSettings =
               ConfigurationManager.AppSettings;

            string[] keys = appSettings.AllKeys;

            Console.WriteLine();
            Console.WriteLine("Application appSettings:");

            // Loop to get key/value pairs.
            for (int i = 0; i < appSettings.Count; i++)

                Console.WriteLine("#{0} Name: {1} Value: {2}",
                  i, keys[i], appSettings[i]);

        }

        public static void WriteSetting(string key, string value)
        {
            System.Configuration.Configuration config =
           ConfigurationManager.OpenExeConfiguration(
           ConfigurationUserLevel.None);

           config.AppSettings.Settings.Remove(key);
           config.AppSettings.Settings.Add(key, value);
           config.Save(ConfigurationSaveMode.Modified); 

        }

        public static string ReadSetting(string key)
        {
            NameValueCollection appSettings =
             ConfigurationManager.AppSettings;

            if (appSettings.Get(key) == null)
                return "";

            return appSettings.Get(key);

        }



	}
}