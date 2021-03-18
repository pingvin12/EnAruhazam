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
    /// Interaction logic for OrderManager.xaml
    /// </summary>
    public partial class OrderManager : Window
    {
        public OrderManager()
        {
            InitializeComponent();
            LoadProducts();
        }

        /// <summary>
        /// Loads all base values from dbo.Product
        /// </summary>
        void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

            {

                string CmdString = "SELECT ProductName, ExpirationDate, Row, Spot, Price, Id FROM dbo.Product";

                DataSet loadProducts = MSSQLHelper.NewConnection(CmdString);

                ProductsGrid.ItemsSource = loadProducts.Tables[0].DefaultView;
            }
        }
        /// <summary>
        /// removes desired product from table
        /// </summary>
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

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
        /// <summary>
        /// Change window child if necessary
        /// </summary>
        private void changeWindowChild(Window window)
        {
            AddDisplay.Children.Clear();

            object content = window.Content;
            window.Content = null;
            window.Close();
            this.AddDisplay.Children.Add(content as UIElement);
        }

        /// <summary>
        /// Adds desired product, but if the children count is not equals zero then we refresh the page
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {


            if(AddDisplay.Children.Count == 0)
            {
                AddOrder ao = new AddOrder();
                changeWindowChild(ao);
                LoadProducts();
            }
            else
            {
                MessageBox.Show("Hozzáadás ablak már helyén van így frissítettük a táblázatot.");
                LoadProducts();
            }
        }
    }
}
