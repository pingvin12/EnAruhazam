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
    /// Interaction logic for OrderManager.xaml
    /// </summary>
    public partial class OrderManager : Window
    {
        public OrderManager()
        {
            InitializeComponent();
            LoadProducts();
        }


        void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT ProductName, ExpirationDate, Row, Spot, Price FROM dbo.Product";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Product");

                sda.Fill(dt);

                ProductsGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Product WHERE Id = @Id", con))
                {

                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Id", ProductsGrid.SelectedIndex + 1);
                    con.Open();
                    command.ExecuteNonQuery();


                }
                LoadProducts();
                con.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
