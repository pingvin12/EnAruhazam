using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;


namespace EnAruhazam
{
    /// <summary>
    /// Admin HR manager for managing HR things
    /// </summary>
    public partial class PeopleManager : Window
    {

        public PeopleManager()
        {
            InitializeComponent();
            LoadData();

        }

        /// <summary>
        /// Load worker details on init
        /// </summary>
        private void LoadData()
        {
           
            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT Name,DateJoined,Email,Phone,Id FROM dbo.Workers";
                DataSet loadData = MSSQLHelper.NewConnection("EnAruhazam", CmdString);

                PeopleGrid.ItemsSource = loadData.Tables[0].DefaultView;
                con.Close();
            }
        }


        /// <summary>
        /// Add worker if necessary, if children equals null then refresh the data.
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (PeopleAddDisplay.Children.Count == 0)
            {
                AddPerson ao = new AddPerson();
                changeWindowChild(ao);
                LoadData();
            }
            else
            {
                MessageBox.Show("Hozzáadás ablak már helyén van így frissítettük a táblázatot.");
                LoadData();
            }
        }

        /// <summary>
        /// Add window
        /// </summary>
        private void changeWindowChild(Window window)
        {
            PeopleAddDisplay.Children.Clear();

            object content = window.Content;
            window.Content = null;
            window.Close();
            this.PeopleAddDisplay.Children.Add(content as UIElement);
        }

        /// <summary>
        /// Remove workers
        /// </summary>
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Biztos vagy benne?", "Törlés", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) { 

                try
            {
                    using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))
                       
                {
                        
                        using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Workers WHERE Id = @Id", con))
                    {
                            
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@Id", PeopleGrid.SelectedIndex+1);
                            con.Open();
                            command.ExecuteNonQuery();
                           

                        }
                        LoadData();
                    con.Close();
                }
            }
            catch(SqlException err)
            {
                    MessageBox.Show(err.Message);
            }
            }
        }
    }
}
