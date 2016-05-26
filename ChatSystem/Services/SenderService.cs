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
        public bool SendData(string dataToSend, string ipToSend, int portToSend)
        {
            try
            {
                var client = new TcpClient(ipToSend, portToSend);

                if (!client.Connected)
                {
                    client.Connect(ipToSend, portToSend);
                }
                
                var data = Encoding.ASCII.GetBytes(dataToSend);

                var stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }                      
        }
    }
}
