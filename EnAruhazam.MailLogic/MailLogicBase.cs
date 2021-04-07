using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;

namespace EnAruhazam.MailLogic
{
    public static class MailLogicBase
    {
        private static bool isLoggedIn { get; set; }

        static MailDataConfig mdc = new MailDataConfig();
        static MailDataHolder mdh = new MailDataHolder();

        
        


        ///<summary>
        ///Currently right now only supports gmail.
        /// </summary>
        ///<param name="EmailName">Email name before prefix.</param>
        ///<example>(xxxxx@gmail.com)</example>
        public static void LogIn(string EmailName, string Password)
        {
            isLoggedIn = true;
            mdc.name = EmailName;
            mdc.pass = Password;
        }
        /// <summary>
        /// Logs out of the system.
        /// </summary>
        public static void LogOut()
        {
            isLoggedIn = false;
            
        }
        /// <summary>
        /// Returns all the mails present in user's gmail.
        /// </summary>
        /// <param name="client">The Pop3Client</param>
        /// <param name="uri">Object Representation Indentifier</param>
        /// <param name="cancel">Signal cancel token</param>
        /// <param name="credentials">for password based authentication</param>
        /// <param name="mailBox">all of the mails subject in an array</param>
        public static void GetMails(TreeView tree)
        {
            if (isLoggedIn)
            {
                using (var client = new ImapClient(new ProtocolLogger ("imap.log")))
                {
                    try { 
                    client.Connect(mdc.Server,mdc.Port,MailKit.Security.SecureSocketOptions.SslOnConnect);
                    //Since this access uses an XOAUTH2 free authentication, turning off protection from unsafe services in gmail necessary right now.
                  
                        
                        
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(mdc.name, mdc.pass,mdc.cancel.Token);
                        var uids = client.Inbox;

                        //We iterate over the emails that the user has received...
                        for (int i = 0; i < uids.Count; i++)
                    {
                        var msg = uids.GetMessage(i,mdc.cancel.Token);
                            tree.Items.Add(msg.Subject);
                        

                    }
                    client.Disconnect(true,mdc.cancel.Token);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bejelentkezés nélkül nem tudsz emaileket lekérni!", "Hiba");
                //the request did not complete succesfully.

            }
        }

        /// <summary>
        ///  Sending an email without XOAUTH2 token
        /// </summary>
        /// <param name="recipientName">The name of the recipient.</param>
        /// <param name="recipientEmail">The email of the recipient.</param>
        /// <param name="senderName">The name of the sender.</param>
        /// <param name="senderEmail">The email of the sender.</param>
        /// <param name="senderPassword">The password of the sender.</param>
        /// <param name="Subject">The subject of the email.</param>
        /// <param name="bodytext">The text of the email body.</param>
        public static void NewMail
            (string recipientName, string recipientEmail,
            string senderName, string senderEmail, string senderPassword, string Subject,
            string bodytext) {
            if (isLoggedIn) {
            var Message = new MimeMessage();
            Message.From.Add(new MailboxAddress(recipientName, recipientEmail));
            Message.To.Add(new MailboxAddress(senderName, senderEmail));
            Message.Subject = Subject;
            Message.Body = new TextPart("plain") { Text = bodytext };
                //Adding recipient to contact list if its not already in.
            if(!mdh.AllContacts.Contains(new Contact(recipientName,recipientEmail)))
                {
                    mdh.AddToContacts(new Contact(recipientName, recipientEmail));
                }
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                //since we don't have an Oauth2 token, we disable the XOAUTH2 auth mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(senderEmail, senderPassword);
                client.Send(Message);
                client.Disconnect(true);
            }
            }
            else
            {
                MessageBox.Show("Bejelentkezés nélkül nem tudsz emailt küldeni!", "Hiba");
                //the request did not complete succesfully.
            }


        }
    }
}
