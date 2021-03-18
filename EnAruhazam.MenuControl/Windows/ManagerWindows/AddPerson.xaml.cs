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
    /// Window child for HR type window
    /// </summary>
    public partial class AddPerson : Window
    {
        public AddPerson()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Add logic
        /// </summary>
        private void AddPer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr()))

                {

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Workers(Id, Name, DateJoined, Phone, Email, Password, isActive) VALUES (@Id, @Name, @DateJoined, @Phone, @Email, @Password, 1)", con))
                    {
                        con.Open();
                        try
                        {
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@Id", int.Parse(Id.Text));
                            command.Parameters.AddWithValue("@Name", PersonName.Text);
                            command.Parameters.AddWithValue("@DateJoined", DateTime.Parse(JoinedDate.Text));
                            command.Parameters.AddWithValue("@Phone", int.Parse(Phone.Text));
                            command.Parameters.AddWithValue("@Email", Email.Text);
                            command.Parameters.AddWithValue("@Password", Password.Text);

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
