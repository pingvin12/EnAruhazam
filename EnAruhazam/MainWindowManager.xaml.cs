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


            string CmdString = "SELECT date, time, total FROM dbo.Traffic ORDER BY date ASC";
            //Forgalom lekérése a mai napra
            SqlCommand cmd = new SqlCommand(CmdString, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            sda.Fill(ds);


            CurrentTraffic.DataContext = ds.Tables[0].DefaultView;
            con.Close();


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

        private void changeWindowChild(Window window)
        {
            EM.Visibility = Visibility.Hidden;
            OM.Visibility = Visibility.Hidden;
            HR.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Visible;
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

        private void ProjectedTraffic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CurrentTraffic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string curSearch = SearchContext.Text;
            SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));
            try
            {
                string CmdString = "SELECT date, time, total FROM dbo.Traffic WHERE date = '" + curSearch + "' ORDER BY date ASC";
                //Forgalom lekérése keresés szerint
                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sda.Fill(ds);
                CurrentTraffic.DataContext = ds.Tables[0].DefaultView;
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            con.Close();
        }

        private void GetTodaysTraffic(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam"));


            string CmdString = "SELECT date, time, total FROM dbo.Traffic WHERE date = CAST( GETDATE() AS Date )  ORDER BY date ASC";
            //Forgalom lekérése a mai napra
            SqlCommand cmd = new SqlCommand(CmdString, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            sda.Fill(ds);


            CurrentTraffic.DataContext = ds.Tables[0].DefaultView;
            con.Close();

           
        }
    }




}
