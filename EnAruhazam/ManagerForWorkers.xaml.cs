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
    /// Interaction logic for ManagerForWorkers.xaml
    /// </summary>
    public partial class ManagerForWorkers : Window
    {
        public ManagerForWorkers(string SignedInUser)
        {
            InitializeComponent();

            loggedin.Content = "Bejelentkezve mint: " + SignedInUser;
        }
    }
}
