using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnAruhazam.MailLogic
{
    class MailDataConfig
    {



    }

    class MailDataHolder
    {
        private List<Contact> Contacts { get; set; }

        /// <summary>
        /// Adds a new contact to contact list
        /// </summary>
        /// <param name="desiredContact">The new contact that we want to add.</param>
        void AddToContacts(Contact desiredContact)
        { Contacts.Add(desiredContact); }
        /// <summary>
        /// Removes contact from contact list.
        /// </summary>
        /// <param name="desiredContact">Our contact that we want to remove</param>
        void RemoveContacts(Contact desiredContact)
        { Contacts.Remove(desiredContact); }
        /// <summary>
        /// Modifies desired contact name.
        /// </summary>
        /// <param name="cName">desired name for the contact</param>
        /// <param name="desiredContact">the contact type that we want to modify</param>
        void ModifyContactName(string cName ,Contact desiredContact)
        {Contacts.Find(x => x == desiredContact).Name = cName;}
    }
   
    /// <summary>
    /// Contact Model
    /// </summary>
    internal class Contact
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
