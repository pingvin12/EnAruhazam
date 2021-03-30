namespace EnAruhazam.MailLogic
{
    /// <summary>
    /// Contact Model for Contacts List
    /// </summary>
    public class Contact
    {
        public string Name;
        public string Email;

        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}

