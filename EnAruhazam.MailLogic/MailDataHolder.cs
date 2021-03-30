using System.Collections.Generic;

namespace EnAruhazam.MailLogic
{
    public class MailDataHolder
    {
        private List<Contact> Contacts { get; set; }

        /// <summary>
        /// Returns all contacts.
        /// </summary>
        public List<Contact> AllContacts
        {
            get => Contacts;
        }

        /// <summary>
        /// Adds a new contact to contact list
        /// </summary>
        /// <param name="desiredContact">The new contact that we want to add.</param>
        public void AddToContacts(Contact desiredContact)
        { Contacts.Add(desiredContact); }
        /// <summary>
        /// Removes contact from contact list.
        /// </summary>
        /// <param name="desiredContact">Our contact that we want to remove</param>
        public void RemoveContacts(Contact desiredContact)
        { Contacts.Remove(desiredContact); }
        /// <summary>
        /// Modifies desired contact name.
        /// </summary>
        /// <param name="cName">desired name for the contact</param>
        /// <param name="desiredContact">the contact type that we want to modify</param>
        public void ModifyContactName(string cName ,Contact desiredContact)
        {Contacts.Find(x => x == desiredContact).Name = cName;}
    }
}

