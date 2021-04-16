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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace EnAruhazam.MenuControl.Windows.ManagerWindows.OptionWindows
{
    /// <summary>
    /// Interaction logic for EmailOptionsMenu.xaml
    /// </summary>
    public partial class EmailOptionsMenu : Window
    {
        public EmailOptionsMenu()
        {
            InitializeComponent();
            
            loadconf();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Email.IsReadOnly = false;
            Password.IsReadOnly = false;

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Email.IsReadOnly = true;
            Password.IsReadOnly = true;
        }

        ///<summary>
        ///Loads current email config
        ///</summary>
        void loadconf()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("config.xml");

           
            XmlNode emailEnabled = doc.SelectSingleNode("/Configuration/EmailEnabled");
            XmlNode email = doc.SelectSingleNode("/Configuration/Email");
            XmlNode password = doc.SelectSingleNode("/Configuration/Password");
            
            XmlAttribute isen = emailEnabled.Attributes["value"];
            XmlAttribute emaile = email.Attributes["value"];
            XmlAttribute pass = password.Attributes["value"];

            integration.IsChecked = Boolean.Parse(isen.Value);
          
            Email.Text = emaile.Value;
            Password.Text = pass.Value;
            
        }

        /// <summary>
        /// Saving desired email configuration
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("config.xml");

            
            XmlNode emailEnabled = doc.SelectSingleNode("/Configuration/EmailEnabled");
            XmlNode email = doc.SelectSingleNode("/Configuration/Email");
            XmlNode password = doc.SelectSingleNode("/Configuration/Password");
            
            XmlAttribute isen = emailEnabled.Attributes["value"];
            XmlAttribute emaile = email.Attributes["value"];
            XmlAttribute pass = password.Attributes["value"];
            isen.Value = integration.IsChecked.ToString();
       
            
            Email.Text = emaile.Value;
            Password.Text = pass.Value;

            doc.Save("config.xml");

        }
    }
}
