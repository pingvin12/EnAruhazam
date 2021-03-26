using System;

using MailKit.Net;
using MailKit.Net.Smtp;
using MimeKit;
using static System.Net.Mime.MediaTypeNames;

namespace EnAruhazam.MailLogic
{
    public static class MailLogicBase
    {
        private static bool isLoggedIn { get; set; }

       

        ///<summary>
        ///Currently right now only supports gmail.
        /// </summary>
        ///<param name="EmailName"
        ///Email name before prefix.
        ///ex:(xxxxx@gmail.com)
        public static void LogIn(string EmailName)
        {
            isLoggedIn = true;
          
        }

        public static void LogOut()
        {
            isLoggedIn = false;
        }



        //Right now can only send a test email
        public static void newMail
            (string recipientName, string recipientEmail,
            string senderName, string senderEmail, string senderPassword, string Subject
            //bodytext string
            )
        {
            if (isLoggedIn) {
            var Message = new MimeMessage();
            Message.From.Add(new MailboxAddress(recipientName, recipientEmail));
            Message.To.Add(new MailboxAddress(senderName, senderEmail));
            Message.Subject = Subject;
            Message.Body = new TextPart("plain") { Text = @"Teszt uzenet" };
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
                throw new NotImplementedException();
            }


        }
    }
}
