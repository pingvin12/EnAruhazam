using System;
using NUnit.Framework;
using EnAruhazam.MailLogic;


namespace DatabaseConnectionTest
{

    class EmailTests
    {

        /// <summary>
        ///  Testing if the connection is succesful
        /// </summary>
        [Test]
        public void TestEmailConnection()
        {
            string[] inb = Array.Empty<string>();
            MailLogicBase.mdc.Port = 993;
            MailLogicBase.mdc.Server = "imap.gmail.com";
            MailLogicBase.LogIn("tesztemail888", "123456Aa@");
            MailLogicBase.GetMails(inb);
            Assert.IsNotNull(inb);
        }

        /// <summary>
        ///  Testing if sending emails are successful.
        /// </summary>
        [Test]
        public void TestEmailSending()
        {
            MailLogicBase.mdc.name = "tesztemail888";
            MailLogicBase.mdc.pass = "123456Aa@";
            MailLogicBase.LogIn("tesztemail888", "123456Aa@");
            Assert.DoesNotThrow(() => MailLogicBase.NewMail("Fenyesj", "fenyesj@gmail.com", MailLogicBase.mdc.name, MailLogicBase.mdc.pass, "teszt", "teszt"));
            
        }

        /// <summary>
        ///  Testing Contacts List
        /// </summary>
        [Test]
        public void TestAddingToContactsList()
        {
            MailDataHolder mdh = new();
            mdh.AddToContacts(new Contact("tesztnev", "tesztemail"));
            Assert.IsNotNull(mdh.AllContacts[0].Name);
        }


    }
}
