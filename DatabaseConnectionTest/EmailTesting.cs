using System;
using NUnit.Framework;
using EnAruhazam.MailLogic;


namespace DatabaseConnectionTest
{
/// <summary>
    /// Email connection, Email sending, and Contact list testing.
    /// </summary>
    class EmailTests
    {

     
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
