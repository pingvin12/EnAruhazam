using EnAruhazam.MailLogic;
using System.Windows;

namespace EnAruhazam.MenuControl.Windows.ManagerWindows
{
    /// <summary>
    /// Interaction logic for SendEmail.xaml
    /// </summary>
    public partial class SendEmail : Window
    {
        public SendEmail()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MailLogicBase.NewMail(NameInput.Text, EmailInput.Text, MailLogicBase.mdc.name, MailLogicBase.mdc.pass, SubjectInput.Text, DescInput.Text);
            MessageBox.Show("Email elküldése megtörtént!");
        }
    }
}
