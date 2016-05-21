using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Common;
using ChatSystem.UtilClasses;

namespace ChatSystem.Services
{
    public class SenderService
    {
        public bool SendMessage(ContactMessage message, string ipToSend, int portToSend)
        {
            var messageParsedToSend = MessageParser.ParseMessageToSendIt(message);

            try
            {
                var client = new TcpClient(ipToSend, portToSend);

                var data = Encoding.ASCII.GetBytes(messageParsedToSend);

                var stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                return true;
            }
            catch (Exception)
            {
                return false;
            }                      
        }
    }
}
