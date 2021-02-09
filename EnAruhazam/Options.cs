using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnAruhazam
{
    class Options
    {

        /// <summary>
        /// Handles fullscreen mode
        /// </summary>
        public static void setWindowToFullscreen(bool fullscreen, Window window)
        {
            switch (fullscreen)
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
