using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using agsXMPP;

namespace talk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            XmppClientConnection xmppCon = new XmppClientConnection();
            xmppCon.Username = "aaa@gmail.com";
            xmppCon.Password = "aaaa";
            xmppCon.Server = "talk.google.com";
            xmppCon.Port = 443;
            xmppCon.UseStartTLS = true;
            xmppCon.AutoResolveConnectServer = true;
            xmppCon.Open();
            Console.WriteLine("Bye");
        }
    }
}
