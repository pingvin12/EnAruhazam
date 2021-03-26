using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using EnAruhazam.DataAccess;
namespace EnAruhazam.MenuControl
{
    /// <summary>
    /// Interaction logic for EdatManager.xaml
    /// </summary>
    public partial class EdatManager : Window
    {
        public EdatManager()
        {
            InitializeComponent();
            loadData();
        }
        //loads machines that were cleaned in this month
        public static DataSet notcleanedMachines
            = MSSQLHelper.NewConnection
            ("SELECT Riport_Date,dbo.Equipments.EquipmentName FROM dbo.Riports " +
                "INNER JOIN dbo.Equipments ON dbo.Riports.EquipmentID=dbo.Equipments.Id" +
                " WHERE Description = 'Kitakaritva' AND DATEPART(mm, Riport_date) < DATEPART(mm,  GETDATE())");

        /// <summary>
        /// load values from specified table
        /// </summary>
        private void loadData()
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

            {

                string CmdString = "SELECT EquipmentName FROM dbo.Equipments ORDER BY Id";
                DataSet loadData = MSSQLHelper.NewConnection( CmdString);

                Equipments.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }

            using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

            {

                string CmdString = "SELECT Riport_Date,dbo.Equipments.EquipmentName FROM dbo.Riports INNER JOIN dbo.Equipments ON dbo.Riports.EquipmentID=dbo.Equipments.Id ";
                DataSet loadData = MSSQLHelper.NewConnection(CmdString);

                Riports.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }

        }

        private void Riports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
