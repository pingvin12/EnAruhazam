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
    /// Login window
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// signed in username
        /// </summary>
        public partial class signedInUser
        {
            public string userName { get; set; }
        }
        /// <summary>
        /// function to connect as a manager
        /// </summary>
        private void connectasManager()
        {
            SqlConnection sqlConnection = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));
            string query = "Select FullName From dbo.Managers Where Name = '" + name.Text.Trim() + "' AND Password = '" + pass.Password.Trim() + "'";
            DataSet getUser = MSSQLHelper.NewConnection("EnAruhazam", query);

            signedInUser user = new signedInUser();
            
            if (getUser.Tables[0].Rows.Count == 1)
            {
                user.userName = getUser.Tables[0].Rows[0][0].ToString();
                MainWindowManager manager = new MainWindowManager(user.userName);


                manager.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Felhasználónév vagy jelszó helytelen!");
            }
        }
        /// <summary>
        /// function to connect as a worker
        /// </summary>
        private void connectasWorker()
        {
            SqlConnection sqlConnection = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));
            string query = "Select Name From dbo.Workers Where Email = '" + name.Text.Trim() + "' AND Password = '" + pass.Password.Trim() + "' AND isActive=1";
            DataSet getUser = MSSQLHelper.NewConnection("EnAruhazam", query);

            signedInUser user = new signedInUser();
           
            if (getUser.Tables[0].Rows.Count == 1)
            {
                user.userName = getUser.Tables[0].Rows[0][0].ToString();
                ManagerForWorkers wmanager = new ManagerForWorkers(user.userName);


                wmanager.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Felhasználónév vagy jelszó helytelen!");
            }
        }
        /// <summary>
        /// Check if the user is a manager or not
        /// </summary>
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (isManager.IsChecked == true)
            {
                
                connectasManager();


            }
            else {

                connectasWorker();
            }

        }
        /// <summary>
        /// Managers use usernames while workers will use an email to login.
        /// </summary>
        private void isManager_Checked(object sender, RoutedEventArgs e)
        {
            username.Content = "Felhasználónév:";
        }
        /// <summary>
        /// email format for workers
        /// </summary>
        private void isManager_Unchecked(object sender, RoutedEventArgs e)
        {
            username.Content = "Email:";
        }
    }
}
