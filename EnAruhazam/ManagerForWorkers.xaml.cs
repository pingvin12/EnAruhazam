using EnAruhazam.DataAccess;
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




            DataSet schedule = MSSQLHelper.NewConnection("SELECT ShiftStart, ShiftEnd, WorkerPos FROM dbo.Shifts INNER JOIN dbo.Workers ON dbo.Shifts.WorkerId = dbo.Workers.Id WHERE dbo.Workers.Name = '"+user+"'  ");
            //valamiért nem tölti be....
            ScheduleGrid.DataContext = schedule.Tables[0].DefaultView;
            con.Close();
        }
    }
}
