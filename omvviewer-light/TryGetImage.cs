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

// TryGetImage.cs created with MonoDevelop
// User: robin at 14:44 18/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Threading;
using OpenMetaverse;
using OpenMetaverse.Imaging;
using OpenMetaverse.Assets;
using Gdk;

namespace omvviewerlight
{
	public class TryGetImage
	{
		
		UUID target_asset;
		Gtk.Image target_image;
        int img_width;
        int img_height;
        AssetTexture this_asset;
		bool scale=false;
      
        public delegate void Decodecomplete();
        public event Decodecomplete OnDecodeComplete;

        public delegate void Update();
        public event Update OnUpdate;

        bool gotdata = false;

        public TryGetImage(Gtk.Image target, UUID asset, bool asynccallback)
		{
            TryGetImageWork(target, asset, true, 256, 256, asynccallback);
		}
		
		public TryGetImage(Gtk.Image target,UUID asset,int width,int height,bool asynccallback)
		{
            TryGetImageWork(target, asset, false, width, height, asynccallback);
		}

        public void TryGetImageWork(Gtk.Image target, UUID asset, bool auto, int width, int height, bool asynccallback)
		{
			if(target==null)
				return;

            Logger.Log("New try get image for " + asset.ToString(),Helpers.LogLevel.Debug);

            MainClass.onDeregister += new MainClass.deregister(MainClass_onDeregister);

              
			scale=auto;
			
			target_asset=asset;
			target_image=target;
            img_width = width;
            img_height = height;

            if (asynccallback)
                return;

            dowork();	
	    }

        void MainClass_onDeregister()
        {
            abort();
        }

        public void go()
        {
            dowork();
        }

        void dowork()
        {
            Gdk.Pixbuf buf = MainClass.GetResource("trying.png");

            if (scale)
                target_image.Pixbuf = buf;
            else
                target_image.Pixbuf = buf.ScaleSimple(img_width, img_height, Gdk.InterpType.Bilinear);

            MainClass.client.Assets.RequestImage(target_asset, OpenMetaverse.ImageType.Normal, 99999000.0f, 0, 0, statusupdate, false);	
      
        }
		
		public void abort()
	   {
            
           MainClass.onDeregister -= new MainClass.deregister(MainClass_onDeregister);

        }
			   
        
       void statusupdate(TextureRequestState state, AssetTexture assetTexture)
       {

           if (state == TextureRequestState.Finished && gotdata == false)
           {
               gotdata = true;
               onGotImage(assetTexture);
           }
       }
 
        void onProgress(UUID image, int recieved, int total)
		{
			if(target_asset!=image)
			    return;

            progress(target_image.Pixbuf,  (float)recieved/(float)total);
	}
		
		unsafe void progress(Gdk.Pixbuf bufdest,float progress)
		{
            if (bufdest == null)
                return;

			byte * pixels=(byte *)bufdest.Pixels;
		    int width=bufdest.Width;
			int height=bufdest.Height;
			int rowstride=bufdest.Rowstride;
			int channels=bufdest.NChannels;
			byte * p;		
			int y,x;
    
            if (progress > 1)
                progress = 1;			
	
            int widthx=(int)(width*progress);
	
			
			for(y=(height-20);y<(height-5);y++)
			{
				for(x=0;x<((float)widthx);x++)
				{
                    p=pixels+((y)*rowstride)+((x)* channels);
                    p[0]=255;
					p[1]=255;
					p[2]=255;
					p[3]=255;
                }	
		    }

            if (OnUpdate != null)
                OnUpdate();
            
            Gtk.Application.Invoke(delegate
            {
            
                try
                {
                    target_image.QueueDraw();
                }
                catch (Exception e)
                {
                    Logger.Log("Exception when updating progress :" + e.Message,Helpers.LogLevel.Debug);
                }
            });		
        }

        void decodethread()
        {

            if (this_asset.AssetID != target_asset)
                return;

            MainClass.onDeregister -= new MainClass.deregister(MainClass_onDeregister);

            Logger.Log("Downloaded asset " + this_asset.AssetID.ToString() + "\n",Helpers.LogLevel.Debug);
            byte[] tgaFile = null;
            ManagedImage imgData=null;

            try
            {
               
                OpenJPEG.DecodeToImage(this_asset.AssetData, out imgData);
                tgaFile = imgData.ExportTGA();
            }
            catch (Exception e)
            {
                Console.Write("\n*****************\n" + e.Message + "\n");
                return;
            }
           
			Gdk.Pixbuf buf;
	            
            //Sort out color space

            for (int pos = 0; pos < tgaFile.Length-3; pos = pos + 3)
            {
                byte B = tgaFile[pos];
                byte G = tgaFile[pos+1];
                byte R = tgaFile[pos + 2];

                tgaFile[pos] = R;
                tgaFile[pos+1] = G;
                tgaFile[pos+2] = B;
            }


			try
			{
			if(this.scale)
				buf = new Gdk.Pixbuf(tgaFile,Colorspace.Rgb,false,8,imgData.Width,imgData.Height,imgData.Width*3,null);
			else
                buf = new Gdk.Pixbuf(tgaFile, Colorspace.Rgb, false, 8, imgData.Width, imgData.Height, imgData.Width * 3, null).ScaleSimple(img_width, img_height, Gdk.InterpType.Bilinear); ;
			}
			catch(Exception e)
			{
				Logger.Log("ERROR: Exception duing Openjpeg decode :"+e.Message,Helpers.LogLevel.Error);
				return;
			}
			
            Logger.Log("Decoded :"+this.target_asset.ToString(),Helpers.LogLevel.Debug);
            
            Gtk.Application.Invoke(delegate
            {
                try
                {
                    if (target_image != null) // this has managed to get set to null
                    {
                        if (target_image.Pixbuf != null)
                        {
                            target_image.Pixbuf = buf;
                            Logger.Log("TryGetImage:: Image Done queuing for a redraw "+this.target_asset.ToString(),Helpers.LogLevel.Debug);
                            if(target_image!=null)
                                target_image.QueueDraw();

                            if (OnDecodeComplete!=null)
                            {
                                try
                                {
                                    OnDecodeComplete();
                                    OnDecodeComplete = null;
                                }
                                catch
                                {

                                }
                            }
						}
                    }
                }
                catch (Exception e)
                {
                    Console.Write("*** Image decode blew whist trying to write image into pixbuf ***\n");
                    Logger.Log(e.Message,Helpers.LogLevel.Debug);
                }

               
            });
        }
      
		void onGotImage(AssetTexture asset)
		{
            if (asset == null)
            {
                Logger.Log("Try get image got a null asset",Helpers.LogLevel.Debug);
                return;
		    }
			if(asset.AssetID==this.target_asset)
			{
	            this_asset = asset;
	            Thread decode = new Thread(new ThreadStart(this.decodethread));
	            Logger.Log("Begining a decode thread for asset "+asset.AssetID.ToString(),Helpers.LogLevel.Debug);
				decode.Start();
	        }
		}	
	}
}
