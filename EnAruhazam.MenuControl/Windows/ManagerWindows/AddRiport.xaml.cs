using EnAruhazam.DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnAruhazam.MenuControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddRiport : Window
    {
        public AddRiport()
        {
            InitializeComponent();
            LoadCombo();
        }

        void LoadCombo()
        {
            DataSet df = MSSQLHelper.NewConnection("SELECT EquipmentName FROM dbo.Equipments");
            SelectableEquipments.Items.Clear();
            foreach (DataRow item in df.Tables[0].Rows)
            {
                SelectableEquipments.Items.Add(item["EquipmentName"]);
            }
            
        }

        private void AddRip_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

                {
                    DataSet ds = MSSQLHelper.NewConnection("SELECT MAX(Id) FROM dbo.Riports");
                    DataSet du = MSSQLHelper.NewConnection("SELECT Id FROM dbo.Equipments WHERE EquipmentName = " + "'"+SelectableEquipments.SelectedValue + "'");
                    if(SelectableEquipments.SelectedItem != null && RiportDate.SelectedDate != null && Description.Text != null) { 
                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Riports(Id, Riport_Date, EquipmentID, Description) VALUES ("+(int.Parse(ds.Tables[0].Rows[0][0].ToString())+1)+", @RiportDate, "+ (du.Tables[0].Rows[0][0].ToString()) + ", @Description)", con))
                    {
                        con.Open();
                        try
                        {
                            command.CommandType = CommandType.Text;
                            
                            command.Parameters.AddWithValue("@RiportDate", RiportDate.SelectedDate.Value);
                           
                            command.Parameters.AddWithValue("@Description", Description.Text);
                            

                            command.ExecuteNonQuery();
                            this.Hide();
                        }
                        catch (SqlException sqle)
                        {
                            MessageBox.Show(sqle.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }
                    }
                    else
                    {
                        MessageBox.Show("Kitöltési mezők egy része hiányos!");
                    }
                   
                    con.Close();

                   
                }
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("Hiba csatlakozásnál", sqle.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }
        }
    }
}
