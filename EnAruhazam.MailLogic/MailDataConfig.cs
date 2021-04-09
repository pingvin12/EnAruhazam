using MailKit.Net.Pop3;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnAruhazam.MailLogic
{
    public class MailDataConfig
    {
        public string name;
        public string pass;
        public string Server;
        public int Port;
        
        public NetworkCredential credentials;
        public CancellationTokenSource cancel;
       

      
        public MailDataConfig()
        {
            //Server = "imap.gmail.com";
            //Port = 993; //995 for POP , 993 is for IMAP
            
            credentials = new NetworkCredential($"{name}@gmail.com", pass);
            cancel = new CancellationTokenSource();
           
        }
    }
}

