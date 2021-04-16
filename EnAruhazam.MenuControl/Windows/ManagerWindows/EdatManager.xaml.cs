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
            LoadData();
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
        private void LoadData()
        {

            using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

            {

                string CmdString = "SELECT Riport_Date,dbo.Equipments.EquipmentName, Description FROM dbo.Riports INNER JOIN dbo.Equipments ON dbo.Riports.EquipmentID=dbo.Equipments.Id ";
                DataSet loadData = MSSQLHelper.NewConnection(CmdString);

                Riports.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }

        }

        /// <summary>
        /// Add window
        /// </summary>
        private void ChangeWindowChild(Window window)
        {
            AddDisplay.Children.Clear();

            object content = window.Content;
            window.Content = null;
            window.Close();
            this.AddDisplay.Children.Add(content as UIElement);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (AddDisplay.Children.Count == 0)
            {
                AddRiport ar = new AddRiport();
                ChangeWindowChild(ar);
                LoadData();
            }
            else
            {
                AddDisplay.Children.Clear();
            }
     
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
