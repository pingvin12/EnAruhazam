using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace EnAruhazam
{
    /// <summary>
    /// Interaction logic for PeopleManager.xaml
    /// </summary>
    public partial class PeopleManager : Window
    {
        public PeopleManager()
        {
            InitializeComponent();
            LoadData();

        }


        public void LoadData()
        {
            string sqlConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EnAruhazam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(sqlConnection))

            {

                CmdString = "SELECT Name,DateJoined,Email,Phone FROM dbo.Workers";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Worker");

                sda.Fill(dt);

                PeopleGrid.ItemsSource = dt.DefaultView;
            }
            }

        private void PeopleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
