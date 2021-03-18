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
    /// AddOrder window child for EdatManager
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Add logic for orders\products
        /// </summary>
        private void AddOrd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

                {

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Product(Id, ProductName, ExpirationDate, Row, Spot, Price) VALUES (@Id, @ProductName, @ExpirationDate, @Row, @Spot, @Price)", con))
                    {
                        con.Open();
                        try
                        {
                            command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Id", int.Parse(Id.Text));
                        command.Parameters.AddWithValue("@ProductName", ProductName.Text);
                        command.Parameters.AddWithValue("@ExpirationDate", DateTime.Parse(ExpirationDate.Text));
                        command.Parameters.AddWithValue("@Row", int.Parse(Row.Text));
                        command.Parameters.AddWithValue("@Spot", int.Parse(Spot.Text));
                        command.Parameters.AddWithValue("@Price", int.Parse(Price.Text));
                       
                        command.ExecuteNonQuery();
                        }
                        catch (SqlException sqle)
                        {
                            MessageBox.Show(sqle.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                           
                        }

                    }

                    con.Close();
                }
            }catch(SqlException sqle)
            {
                MessageBox.Show("Hiba csatlakozásnál", sqle.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }
        }
    }
}
