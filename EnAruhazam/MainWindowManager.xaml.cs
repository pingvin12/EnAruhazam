﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using EnAruhazam.DataAccess;
using EnAruhazam.NotificationHandler;
using EnAruhazam.MenuControl;
using EnAruhazam.MailLogic;
using EnAruhazam.MenuControl.Windows.ManagerWindows.OptionWindows;
using EnAruhazam.MenuControl.Windows.ManagerWindows;

namespace EnAruhazam
{

    /// <summary>
    /// Interaction logic for MainWindowManager.xaml
    /// </summary>
    public partial class MainWindowManager : Window
    {
        
       
        /// <summary>
        /// Set a constructor so we can check who actually logged in.
        /// </summary>
        public MainWindowManager(string SignedInUser)
        {
            InitializeComponent();
            UserLoggedInAs.Content = "Bejelentkezve mint: " + SignedInUser;
            Userlgdebug.Content = SignedInUser;
            InitContent();
            
            LoadCurrent();
            
        }
        



        ///<summary>
        ///Init window content
        ///</summary>
        void InitContent()
        {
            LoadConfig.Load(debugw, this);
            string[] inb = Array.Empty<string>();
            MailLogicBase.LogIn(LoadConfig.email, LoadConfig.password);
            
            //Get Current Emails if config says so
            if (LoadConfig.isLoggedin == true) { 
            try
            {
            MailLogicBase.mdc.Server = LoadConfig.emailDomain;
            MailLogicBase.mdc.Port = LoadConfig.emailPort;
            
            MailLogicBase.GetMails(inb);
           foreach(var item in inb)
                    {
                        MTree.Items.Add(item);
                    }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            }
            GlobalTypes.OptionsButtons[0] = EmailOptions;
           

            // Options window
            GlobalTypes.OptionsMenu = new MenuTabLogic
                (
                    GlobalTypes.OptionsButtons, BackOptions, GlobalTypes.ChildOptionButtons, OptionsDisplay
                );

            /// <!-- Load Debug mode -->
            
            GlobalTypes.ChildOptionButtons[0] = UserOptions;

            GlobalTypes.mainParentButtons[0] = EM;
            GlobalTypes.mainParentButtons[1] = OM;
            GlobalTypes.mainParentButtons[2] = HR;
            GlobalTypes.mainChildButtons[0] = Persons;
            GlobalTypes.mainChildButtons[1] = Shifts;

            

            //would need to init more MainAdminWindowLogic for more tabs.
            GlobalTypes.mawl = new MenuTabLogic(

               GlobalTypes.mainParentButtons,
               Back,
               GlobalTypes.mainChildButtons,
               ContentDisplay
               );

            GlobalTypes.nh.DoNotification("Lejárt Termékek összege", $"Lejárt termékek összege eléri a  következő számot: {OrderManager.expiredProducts.Tables[0].Rows.Count}!", NotificationManager.NotifType.EXPIRED_PROD);
            GlobalTypes.nh.DoNotification("Ebben a hónapban kitakarított készülékek", $"Ebben a hónapban kitakarított készülékek száma: {EdatManager.notcleanedMachines.Tables[0].Rows.Count}!", NotificationManager.NotifType.MACHINE_NOT_CLEANED);

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
           SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr());


            
            //Get today's traffic
            DataSet currentstraffic = MSSQLHelper.NewConnection("SELECT date, time, total FROM dbo.Traffic ORDER BY date ASC");
            CurrentTraffic.DataContext = currentstraffic.Tables[0].DefaultView;
            con.Close();


        }
        /// <summary>
        /// If we are done with managing we can revert all our child values back to normal
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GlobalTypes.mawl.RevertWindowChild();
            

        }
        /// <summary>
        /// If we are done with managing we can revert all our child values back to normal
        /// </summary>
        private void Back_Click1(object sender, RoutedEventArgs e)
        {
            GlobalTypes.OptionsMenu.RevertWindowChild();


        }
        /// <summary>
        /// Instantiates a new peoplemanager window
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PeopleManager peopleManager = new PeopleManager();

            GlobalTypes.mawl.ChangeWindowChild(peopleManager);
        }
        /// <summary>
        /// Instantiates a new edatmanager window
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EdatManager edatManager = new EdatManager();

            GlobalTypes.mawl.ChangeWindowChild(edatManager);
        }
        /// <summary>
        /// Instantiates a new ordermanager window
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OrderManager orderManager = new OrderManager();
            GlobalTypes.mawl.ChangeWindowChild(orderManager);
            
        }

        /// <summary>
        /// Get traffic based on search value
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string curSearch = SearchContext.Text;
            SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr());
            try
            {

                
                DataSet searchtraffic = MSSQLHelper.NewConnection("SELECT date, time, total FROM dbo.Traffic WHERE date = '" + curSearch + "' ORDER BY date ASC");
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
            SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr());




            DataSet todaystraffic = MSSQLHelper.NewConnection("SELECT date, time, total FROM dbo.Traffic WHERE date = CAST( GETDATE() AS Date )  ORDER BY date ASC");

            CurrentTraffic.DataContext = todaystraffic.Tables[0].DefaultView;
            con.Close();

           
        }
        /// <summary>
        /// Instantiates a new shiftmanager window
        /// </summary>
        private void Shifts_Click(object sender, RoutedEventArgs e)
        {
            ShiftManager shiftManager = new ShiftManager();
            GlobalTypes.mawl.ChangeWindowChild(shiftManager);
        }
        /// <summary>
        /// Set window child to hr
        /// </summary>
        private void HR_Click(object sender, RoutedEventArgs e)
        {
            GlobalTypes.mawl.AddSubmenu();
        }
        
        /// <summary>
        /// Debug mode only : Instantiates test notification.
        /// </summary>
        private void TestNotification_Click(object sender, RoutedEventArgs e)
        {
            //error type
            var errortype = NotificationManager.NotifType.TEST;
            //delete notification
            GlobalTypes.nh.DoNotification("Teszt Értesítés fejléc", "Teszt értesítés szöveg", errortype);
        }

        private void EmailOptions_Click(object sender, RoutedEventArgs e)
        {
            EmailOptionsMenu emailOptionsMenu = new EmailOptionsMenu();
            GlobalTypes.OptionsMenu.ChangeWindowChild(emailOptionsMenu);
        }

        private void Write_Mail(object sender, RoutedEventArgs e)
        {
            SendEmail se = new SendEmail();
            se.Show();
        }
    }
}
