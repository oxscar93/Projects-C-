using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Common
{
    public class Contact
    {
        private string _name;
        private string _ip;
        public string NameUnmodified { get; set;}

        public Contact(string name, string ip)
        {
            _name = name;
            _ip = ip;
            NameUnmodified = name;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetIp()
        {
            return _ip;
        }
    }
}
