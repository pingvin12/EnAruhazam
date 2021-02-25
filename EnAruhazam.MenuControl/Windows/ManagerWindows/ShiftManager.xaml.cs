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
using EnAruhazam.DataAccess;
namespace EnAruhazam.MenuControl
{
    /// <summary>
    /// Interaction logic for ShiftManager.xaml
    /// </summary>
    public partial class ShiftManager : Window
    {
        public ShiftManager()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Loads all shifts
        /// </summary>
        private void LoadData()
        {

            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT dbo.Workers.Name,ShiftStart,ShiftEnd,WorkerPos FROM dbo.Shifts INNER JOIN dbo.Workers ON dbo.Shifts.WorkerId=dbo.Workers.Id WHERE WorkerPos = 'Árufeltölto' OR WorkerPos = 'Pénztáros'";
                DataSet loadData = MSSQLHelper.NewConnection("EnAruhazam", CmdString);

                ShiftDisplay.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT dbo.Workers.Name, ShiftStart,ShiftEnd,Description from dbo.Schedules INNER JOIN dbo.Workers ON dbo.Schedules.WorkerId=dbo.Workers.Id";
                DataSet loadData = MSSQLHelper.NewConnection("EnAruhazam", CmdString);

                applications.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }
        }
        /// <summary>
        /// Loads shifts based on specified date | Currently returns error
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))
            {
                string CmdString = "SELECT dbo.Workers.Name,ShiftStart,ShiftEnd,WorkerPos FROM dbo.Shifts INNER JOIN dbo.Workers ON dbo.Shifts.WorkerId=dbo.Workers.Id WHERE ShiftStart = '" + ShiftDate.SelectedDate.Value.ToString("YYYY-MM-DDTHH:MM:SS") + "'";
                DataSet loadData = MSSQLHelper.NewConnection("EnAruhazam", CmdString);

                ShiftDisplay.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();



            }
        }

        private void applications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
