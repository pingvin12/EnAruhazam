using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnAruhazam
{
    /// <summary>
    /// Interaction logic for MainWindowManager.xaml
    /// </summary>
    public partial class MainWindowManager : Window
    {
        public MainWindowManager(string SignedInUser)
        {
            InitializeComponent();
            UserLoggedInAs.Content = "Bejelentkezve mint: " + SignedInUser;
            
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }



        private void SetToFullScreen(bool tofullscreen)
        {
            if (tofullscreen) {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
            }

        }

        private void FullScreen_Checked(object sender, RoutedEventArgs e)
        {
            SetToFullScreen(true);
        }
        private void FullScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            SetToFullScreen(false);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }




}
