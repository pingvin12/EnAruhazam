using MailKit.Net.Pop3;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnAruhazam.MailLogic
{
    class MailDataConfig
    {
        public string name;
        public string pass;
        public string Server;
        public int Port;
        public bool UseSSL = false;
        public NetworkCredential credentials;
        public CancellationTokenSource cancel;
        public Uri url;


      
        public MailDataConfig()
        {
            Server = "imap.gmail.com";
            Port = 993; //995 for POP , 993 is for IMAP
            UseSSL = false;
            credentials = new NetworkCredential($"{name}@gmail.com", pass);
            cancel = new CancellationTokenSource();
            url = new Uri(string.Format("imap{0}://{1}:{2}", (UseSSL ? "s" : ""), Server, Port));
        }
    }
}

