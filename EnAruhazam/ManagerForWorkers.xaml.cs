using EnAruhazam.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
namespace EnAruhazam
{
    /// <summary>
    /// Home page for workers
    /// </summary>
    public partial class ManagerForWorkers : Window
    { string user;
        public ManagerForWorkers(string SignedInUser)
        {
            InitializeComponent();
            user = SignedInUser;
            loggedin.Content = "Bejelentkezve mint: " + SignedInUser;
            GetSchedule();
        }

        void GetSchedule()
        {
            SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr());


            DataSet schedulereq = MSSQLHelper.NewConnection("SELECT ShiftStart, ShiftEnd, Description FROM dbo.Schedules INNER JOIN dbo.Workers ON dbo.Schedules.WorkerId = dbo.Workers.Id WHERE dbo.Workers.Name = '" + user + "'  ");

            ScheduleRequests.ItemsSource = schedulereq.Tables[0].DefaultView;

            DataSet schedule = MSSQLHelper.NewConnection("SELECT ShiftStart, ShiftEnd, WorkerPos FROM dbo.Shifts INNER JOIN dbo.Workers ON dbo.Shifts.WorkerId = dbo.Workers.Id WHERE dbo.Workers.Name = '"+user+"'  ");
            
            ScheduleGrid.ItemsSource = schedule.Tables[0].DefaultView;
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
