using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using agsXMPP;
using agsXMPP.Xml.Dom;

namespace WMTalk
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        XmppClientConnection xmppCon;

        private void MainForm_Load(object sender, EventArgs e)
        {
            xmppCon = new XmppClientConnection();
            xmppCon.OnLogin += new ObjectHandler(xmppCon_OnLogin);
            xmppCon.OnAuthError += new XmppElementHandler(xmppCon_OnAuthError);
            xmppCon.OnError += new ErrorHandler(xmppCon_OnError);
            xmppCon.Username = "rongrongbaba@gmail.com";
            xmppCon.Password = "751109";
            xmppCon.Server = "talk.google.com";
            xmppCon.Port = 443;
            //xmppCon.UseStartTLS = true;
            xmppCon.KeepAlive = true;
            xmppCon.AutoResolveConnectServer = true;
            xmppCon.Open();
        }

        private void xmppCon_OnError(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ErrorHandler(xmppCon_OnError), new object[] { sender, ex });
                return;
            }
            listEvents.Items.Add("OnError");
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        private void xmppCon_OnAuthError(object sender, Element e)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new XmppElementHandler(xmppCon_OnAuthError), new object[] { sender, e });
                return;
            }
            listEvents.Items.Add("OnAuthError");
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        private void xmppCon_OnLogin(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(xmppCon_OnLogin), new object[] { sender });
                return;
            }
            this.listEvents.Items.Add("Login");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            using (var sslhelper = new SslHelper(socket, "talk.google.com"))
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse("72.14.203.125"), 443));
                var encoding = new UTF8Encoding();
                var buf =
                    encoding.GetBytes(
                        @"<?xml version=""1.0""?>


<stream:stream xmlns:stream=""http://etherx.jabber.org/streams"" version=""1.0"" xmlns=""jabber:client"" to=""gmail.com"" xml:lang=""en"" xmlns:xml=""http://www.w3.org/XML/1998/namespace"" >

");
                socket.Send(buf);
                var buff = new byte[1024];
                //while (socket.Available > 0)
                {
                    int i = socket.Receive(buff);
                    Debug.Write(encoding.GetString(buff, 0, i));
                }
                Debug.WriteLine("");
            }
        }
    }
}