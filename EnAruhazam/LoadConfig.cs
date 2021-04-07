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
    public static class LoadConfig
    {
        public static bool debugmode = false;
        public static Grid Debuggrid;
        public static bool IsFullscreen = false;
        public static int WindowWidth;
        public static int WindowHeight;
        public static bool isLoggedin;
        public static string email;
        public static string password;

        public static void Load(Grid debuggrid, Window window)
        {
            bool isLoggedin = false;
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
                reader.ReadToFollowing("EmailEnabled");
                reader.MoveToAttribute("value");
                isLoggedin = bool.Parse(reader.Value);
                reader.ReadToFollowing("Email");
                reader.MoveToAttribute("value");
                email = reader.Value;
                reader.ReadToFollowing("Password");
                reader.MoveToAttribute("value");
                password = reader.Value;

            } while (reader.ReadToFollowing("Configuration"));

            Debuggrid = debuggrid;
            /// <summary> Decapracated </summary>
            /// Read a particular key from the config file 
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


    
        public static void ResizeWindow(Window window)
        {
            window.Width = WindowWidth;
            window.Height = WindowHeight;
        }

        public static void SetDebug(Grid grid, Window window)
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

        public static void SetWindowToFullscreen( Window window)
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
