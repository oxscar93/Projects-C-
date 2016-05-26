using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.UtilClasses
{
    public class IpProvider
    {
        public static string GetLocalIpAddress(AddressFamily ipType)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var ipToReturn = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == ipType);

            return ipToReturn?.ToString();
        }
    }
}
