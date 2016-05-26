using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using ChatSystem.Notificators;
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
            var ipAddress = IpProvider.GetLocalIpAddress(AddressFamily.InterNetwork);

            var tcpListener = _InitializeListener(IPAddress.Parse(ipAddress));

            tcpListener.Start();

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

        private TcpListener _InitializeListener(IPAddress ipAddress)
        {
            try
            {
                return new TcpListener(ipAddress, 13);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "--- The program will be closed");
                Environment.Exit(0);             
            }

            return null;
        }  
    }
}
