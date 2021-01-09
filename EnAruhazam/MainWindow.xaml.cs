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
using System.Data.SqlClient;
using System.Data;

namespace EnAruhazam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public partial class signedInUser
        {
            public string userName { get; set; }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));
            string query = "Select * From dbo.Managers Where Name = '" + name.Text.Trim() + "' AND Password = '" + pass.Password.Trim() + "'";
            DataSet getUser = MSSQLHelper.NewConnection("EnAruhazam", query);
            
            signedInUser user = new signedInUser();
            user.userName = name.Text;
            if(getUser.Tables[0].Rows.Count == 1)
            {
                MainWindowManager manager = new MainWindowManager(user.userName);

                
                manager.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Felhasználónév vagy jelszó helytelen!");
            }
        
        
        
        
        
        
        
        
        
        }

    }
}
