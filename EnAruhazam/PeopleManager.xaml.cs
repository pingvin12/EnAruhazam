﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
           

            

            using (SqlConnection con = new SqlConnection(MSSQLHelper.ConVal("EnAruhazam")))

            {

                string CmdString = "SELECT Name,DateJoined,Email,Phone,Id FROM dbo.Workers";

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

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Biztos vagy benne?", "Törlés", System.Windows.MessageBoxButton.YesNo);
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
                    System.Windows.MessageBox.Show(err.Message);
            }
            }
        }
    }
}
