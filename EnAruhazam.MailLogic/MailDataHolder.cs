using System.Collections.Generic;
using System.Xml;

namespace EnAruhazam.MailLogic
{
/// <summary>
    /// Contact list class
    /// </summary>
    public class MailDataHolder
    {
        private List<Contact> Contacts = new List<Contact>();

        /// <summary>
        /// Returns all contacts.
        /// </summary>
        public List<Contact> AllContacts
        {
            get => Contacts;
            set => Contacts.Add(new Contact(value.ToString(),value.ToString()));
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
        /// <summary>
        /// Saves all existing contacts in xml format.
        /// </summary>
        public void SaveAllContacts()
        {
            XmlWriter writer = XmlWriter.Create("contacts.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Contacts");
            for (int i = 0; i < Contacts.Count; i++)
            {
                
                writer.WriteStartElement("Contact");
                writer.WriteAttributeString("Email", Contacts[i].Email);
                writer.WriteElementString("Name", Contacts[i].Name);
                writer.WriteEndElement();
               
                
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

        }




    }
}

