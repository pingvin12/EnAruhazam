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
        }

        private void AddRip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

                {

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Riports(Id, Riport_Date, EquipmentID, Description) VALUES (@Id, @RiportDate, @EquipmentId, @Description)", con))
                    {
                        con.Open();
                        try
                        {
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@Id", int.Parse(Id.Text));
                            command.Parameters.AddWithValue("@RiportDate", DateTime.Parse(RiportDate.Text));
                            command.Parameters.AddWithValue("@EquipmentId", EquipmentID.Text);
                            command.Parameters.AddWithValue("@Description", Description.Text);
                            

                            command.ExecuteNonQuery();
                            this.Hide();
                        }
                        catch (SqlException sqle)
                        {
                            MessageBox.Show(sqle.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

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
