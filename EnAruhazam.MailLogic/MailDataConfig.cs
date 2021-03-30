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
        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public MailDataConfig()
        {
            using (var client = new Pop3Client())
            {
                var Server = "gmail.com";
                var Port = "995";
                var UseSSL = false;
                var credentials = new NetworkCredential($"{GetName()}@gmail.com", $"{GetName()}");
                var cancel = new CancellationTokenSource();
                var url = new Uri(string.Format("pop{0}://{1}:{2}", (UseSSL ? "s" : ""), Server, Port));

                
               



            }
        }
    }
}

