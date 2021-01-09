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
        


    public MainWindowManager(string SignedInUser)
        {
            InitializeComponent();
            
            UserLoggedInAs.Content = "Bejelentkezve mint: " + SignedInUser;
            
            LoadCurrent();
            
        }



       

        //Az ablak bezárásakor meg kell győződnünk, hogy tényleg becsuktuk-e.
        protected override void OnClosed(EventArgs e)
        {

            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public void LoadCurrent()
        {
           SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));


            
            //Forgalom lekérése a mai napra
            DataSet currentstraffic = MSSQLHelper.NewConnection("EnAruhazam", "SELECT date, time, total FROM dbo.Traffic ORDER BY date ASC");
            CurrentTraffic.DataContext = currentstraffic.Tables[0].DefaultView;
            con.Close();


        }




        

        private void FullScreen_Checked(object sender, RoutedEventArgs e)
        {
            Options.setWindowToFullscreen(true, this);
        }
        private void FullScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.setWindowToFullscreen(false, this);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void changeWindowChild(Window window)
        {
            EM.Visibility = Visibility.Hidden;
            OM.Visibility = Visibility.Hidden;
            HR.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Visible;
            Persons.Visibility = Visibility.Hidden;
            Shifts.Visibility = Visibility.Hidden;
            ContentDisplay.Children.Clear();

            object content = window.Content;
            window.Content = null;
            window.Close();
            this.ContentDisplay.Children.Add(content as UIElement);
        }

        private void revertWindowChild()
        {
            EM.Visibility = Visibility.Visible;
            OM.Visibility = Visibility.Visible;
            HR.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Hidden;
            Shifts.Visibility = Visibility.Hidden;
            Persons.Visibility = Visibility.Hidden;
            ContentDisplay.Children.Clear();
        }

       private void toHR()
        {
            EM.Visibility = Visibility.Hidden;
            OM.Visibility = Visibility.Hidden;
            HR.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Visible;
            Shifts.Visibility = Visibility.Visible;
            Persons.Visibility = Visibility.Visible;
            ContentDisplay.Children.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            revertWindowChild();

        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            PeopleManager peopleManager = new PeopleManager();
            changeWindowChild(peopleManager);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EdatManager edatManager = new EdatManager();
            changeWindowChild(edatManager);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OrderManager orderManager = new OrderManager();
            changeWindowChild(orderManager);
        }

       
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string curSearch = SearchContext.Text;
            SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));
            try
            {

                //Forgalom lekérése keresés szerint
                DataSet searchtraffic = MSSQLHelper.NewConnection("EnAruhazam", "SELECT date, time, total FROM dbo.Traffic WHERE date = '" + curSearch + "' ORDER BY date ASC");
                CurrentTraffic.DataContext = searchtraffic.Tables[0].DefaultView;
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            con.Close();
        }

        private void GetTodaysTraffic(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));



            //Forgalom lekérése a mai napra

            DataSet todaystraffic = MSSQLHelper.NewConnection("EnAruhazam", "SELECT date, time, total FROM dbo.Traffic WHERE date = CAST( GETDATE() AS Date )  ORDER BY date ASC");

            CurrentTraffic.DataContext = todaystraffic.Tables[0].DefaultView;
            con.Close();

           
        }

        private void Shifts_Click(object sender, RoutedEventArgs e)
        {
            ShiftManager shiftManager = new ShiftManager();
            changeWindowChild(shiftManager);
        }

        private void HR_Click(object sender, RoutedEventArgs e)
        {
            toHR();
        }
    }




}
