using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public static Button[] mainParentButtons = new Button[3];
        public static Button[] mainChildButtons = new Button[2];
        public MainAdminWindowLogic mawl = new MainAdminWindowLogic(null,null,null,null);
        /// <summary>
        /// Set a constructor so we can check who actually logged in.
        /// </summary>
        public MainWindowManager(string SignedInUser)
        {
            InitializeComponent();

            UserLoggedInAs.Content = "Bejelentkezve mint: " + SignedInUser;
            InitContent();
            LoadCurrent();
             


        }

       
      //Init window content
        void InitContent()
        {
            mainParentButtons[0] = EM;
            mainParentButtons[1] = OM;
            mainParentButtons[2] = HR;
            mainChildButtons[0] = Persons;
            mainChildButtons[1] = Shifts;

            mawl = new MainAdminWindowLogic(

            mainParentButtons,
            Back,
               mainChildButtons,
               ContentDisplay
               );
        }

       
       



        /// <summary>
        /// Checking if we closed the window
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {

            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Loading all traffic data
        /// </summary>
        public void LoadCurrent()
        {
           SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));


            
            //Forgalom lekérése a mai napra
            DataSet currentstraffic = MSSQLHelper.NewConnection("EnAruhazam", "SELECT date, time, total FROM dbo.Traffic ORDER BY date ASC");
            CurrentTraffic.DataContext = currentstraffic.Tables[0].DefaultView;

            DataSet allnotifs = MSSQLHelper.NewConnection("EnAruhazam", "SELECT TITLE, DESCRIPTION, DATE FROM dbo.Notifications");

            NotificationPanel.DataContext = allnotifs.Tables[0].DefaultView;

            con.Close();


        }





        /// <summary>
        /// Setting fullscreen options
        /// </summary>
        private void FullScreen_Checked(object sender, RoutedEventArgs e)
        {
            Options.setWindowToFullscreen(true, this);
        }
        /// <summary>
        /// Setting fullscreen options
        /// </summary>
        private void FullScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.setWindowToFullscreen(false, this);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
       
        /// <summary>
        /// If we are done with managing we can revert all our child values back to normal
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mawl.RevertWindowChild(mainParentButtons,mainChildButtons);
            

        }
        /// <summary>
        /// Instantiates a new peoplemanager window
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PeopleManager peopleManager = new PeopleManager();
            
            mawl.ChangeWindowChild(peopleManager);
        }
        /// <summary>
        /// Instantiates a new edatmanager window
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EdatManager edatManager = new EdatManager();
            
            mawl.ChangeWindowChild(edatManager);
        }
        /// <summary>
        /// Instantiates a new ordermanager window
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OrderManager orderManager = new OrderManager();
            mawl.ChangeWindowChild(orderManager);
            
        }

        /// <summary>
        /// Get traffic based on search value
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string curSearch = SearchContext.Text;
            SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));
            try
            {

                
                DataSet searchtraffic = MSSQLHelper.NewConnection("EnAruhazam", "SELECT date, time, total FROM dbo.Traffic WHERE date = '" + curSearch + "' ORDER BY date ASC");
                CurrentTraffic.DataContext = searchtraffic.Tables[0].DefaultView;
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            con.Close();
        }
        /// <summary>
        /// Get today's traffic
        /// </summary>
        private void GetTodaysTraffic(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));




            DataSet todaystraffic = MSSQLHelper.NewConnection("EnAruhazam", "SELECT date, time, total FROM dbo.Traffic WHERE date = CAST( GETDATE() AS Date )  ORDER BY date ASC");

            CurrentTraffic.DataContext = todaystraffic.Tables[0].DefaultView;
            con.Close();

           
        }
        /// <summary>
        /// Instantiates a new shiftmanager window
        /// </summary>
        private void Shifts_Click(object sender, RoutedEventArgs e)
        {
            ShiftManager shiftManager = new ShiftManager();
            //changeWindowChild(shiftManager);
            mawl.ChangeWindowChild(shiftManager);
        }
        /// <summary>
        /// Set window child to hr
        /// </summary>
        private void HR_Click(object sender, RoutedEventArgs e)
        {
            // toHR();
            mawl.AddSubmenu(null, null);
        }

        private void NotificationPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

  
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           //delete notification
        }
    }




}
