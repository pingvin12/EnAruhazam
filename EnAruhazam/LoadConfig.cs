using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace EnAruhazam
{
    public class LoadConfig
    {
        public bool debugmode = false;

        public Grid Debuggrid;
        public bool IsFullscreen = false;
        public int WindowWidth,WindowHeight;
        
        public void Load(Grid debuggrid, Window window)
        {

            var reader = XmlReader.Create("config.xml");
            reader.ReadToFollowing("Configuration");
            // Read keys from the config file 
            do
            {
                reader.ReadToFollowing("debug");
                reader.MoveToAttribute("value");
                debugmode = bool.Parse(reader.Value);

                reader.ReadToFollowing("fullscreen");
                reader.MoveToAttribute("value");
                IsFullscreen = bool.Parse(reader.Value);

                reader.ReadToFollowing("windowWidth");
                reader.MoveToAttribute("value");
                WindowWidth = int.Parse(reader.Value);
                reader.ReadToFollowing("windowHeight");
                reader.MoveToAttribute("value");
                WindowHeight = int.Parse(reader.Value);

            } while (reader.ReadToFollowing("Configuration"));

            this.Debuggrid = debuggrid;
            /// <summary> Decapracated </summary>
            // Read a particular key from the config file 
            ///debugmode = bool.Parse(ConfigurationManager.AppSettings.Get("debugmode"));
            ///IsFullscreen = bool.Parse(ConfigurationManager.AppSettings.Get("fullscreen"));
            ///
            ///WindowWidth = int.Parse(ConfigurationManager.AppSettings.Get("windowwidth"));
            ///WindowHeight = int.Parse(ConfigurationManager.AppSettings.Get("windowheight"));
            ///

            //Init settings

            SetDebug(debuggrid,window);
            //ResizeWindow(window);


            // Read all the keys from the config file
            /*NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
                Console.WriteLine("Setting: " + s + " Value: " + sAll.Get(s));

            */
        }


        public void ResizeWindow(Window window)
        {
            window.Width = WindowWidth;
            window.Height = WindowHeight;
        }

        public void SetDebug(Grid grid, Window window)
        {
         
            switch(debugmode)
            {
                case true:
                    grid.Visibility = Visibility.Visible;
                    window.Title = "EnAruhazam[DEBUG]";
                    break;
                case false:
                    grid.Visibility = Visibility.Hidden;
                    break;
            
            }
        }

        public void SetWindowToFullscreen( Window window)
        {
            switch (IsFullscreen)
            {
                case true:
                    window.WindowStyle = WindowStyle.None;
                    window.WindowState = WindowState.Maximized;
                    break;
                case false:
                    window.WindowStyle = WindowStyle.SingleBorderWindow;
                    window.WindowState = WindowState.Normal;
                    break;
            }

        }

    }
}
