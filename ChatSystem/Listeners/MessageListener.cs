using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatSystem.Common;
using ChatSystem.Factories;
using ChatSystem.Managers;
using ChatSystem.Services;
using ChatSystem.UtilClasses;

namespace ChatSystem.Listeners
{
    public class MessageListener
    {
        private readonly WindowMessageNotificator _windowMessageNotificator;

        public MessageListener(WindowMessageNotificator windowMessageNotificator)
        {
            _windowMessageNotificator = windowMessageNotificator;
        }

        public void Start()
        {
            TcpListener tcpListener;
            var ipAddress = IPAddress.Parse("127.0.0.1");
            try
            {
                tcpListener = new TcpListener(ipAddress, 13);
                tcpListener.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                return;
            }

            while (true)
            {
                var message = new StringBuilder();

                var tcpClient = tcpListener.AcceptTcpClient();

                var bytes = new byte[256];
               
                var stream = tcpClient.GetStream();

                if (!stream.DataAvailable) continue;

                var numberOfBytes = stream.Read(bytes, 0, bytes.Length);
                message.AppendFormat("{0}", Encoding.ASCII.GetString(bytes, 0, numberOfBytes));

                if (message.ToString() == string.Empty) continue;
       
                _windowMessageNotificator.UpdateOrCreateWindowIfNeeded(
                    MessageParser.ParseMessageStringToObject(message.ToString()));
            }
        }       
    }
}
