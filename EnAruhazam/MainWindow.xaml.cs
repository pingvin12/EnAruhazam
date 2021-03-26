using System.Windows;
using EnAruhazam.DataAccess;
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
        public partial class SignedInUser
        {
            public string UserName { get; set; }
        }
        /// <summary>
        /// function to connect as a manager
        /// </summary>
        private void ConnectasManager()
        {
            string query = "Select FullName From dbo.Managers Where Name = '" + name.Text.Trim() + "' AND Password = '" + pass.Password.Trim() + "'";
            DataSet getUser = MSSQLHelper.NewConnection(query);

            SignedInUser user = new SignedInUser();
            
            if (getUser.Tables[0].Rows.Count == 1)
            {
                user.UserName = getUser.Tables[0].Rows[0][0].ToString();
                MainWindowManager manager = new MainWindowManager(user.UserName);


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
        private void ConnectasWorker()
        {
           string query = "Select Name From dbo.Workers Where Email = '" + name.Text.Trim() + "' AND Password = '" + pass.Password.Trim() + "' AND isActive=1";
            DataSet getUser = MSSQLHelper.NewConnection( query);

            SignedInUser user = new SignedInUser();
           
            if (getUser.Tables[0].Rows.Count == 1)
            {
                user.UserName = getUser.Tables[0].Rows[0][0].ToString();
                ManagerForWorkers wmanager = new ManagerForWorkers(user.UserName);


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
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsManager.IsChecked == true)
            {
                
                ConnectasManager();


            }
            else {

                ConnectasWorker();
            }

        }
        /// <summary>
        /// Managers use usernames while workers will use an email to login.
        /// </summary>
        private void IsManager_Checked(object sender, RoutedEventArgs e)
        {
            username.Content = "Felhasználónév:";
        }
        /// <summary>
        /// email format for workers
        /// </summary>
        private void IsManager_Unchecked(object sender, RoutedEventArgs e)
        {
            username.Content = "Email:";
        }
    }
}
