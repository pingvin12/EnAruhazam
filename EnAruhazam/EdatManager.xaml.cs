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
    /// Interaction logic for EdatManager.xaml
    /// </summary>
    public partial class EdatManager : Window
    {
        public EdatManager()
        {
            InitializeComponent();
            loadData();
        }


        /// <summary>
        /// load values from specified table
        /// </summary>
        private void loadData()
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT EquipmentName FROM dbo.Equipments ORDER BY Id";
                DataSet loadData = MSSQLHelper.NewConnection("EnAruhazam", CmdString);

                Equipments.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }

            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT Riport_Date,dbo.Equipments.EquipmentName FROM dbo.Riports INNER JOIN dbo.Equipments ON dbo.Riports.EquipmentID=dbo.Equipments.Id ";
                DataSet loadData = MSSQLHelper.NewConnection("EnAruhazam", CmdString);

                Riports.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }

        }

        private void Riports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
