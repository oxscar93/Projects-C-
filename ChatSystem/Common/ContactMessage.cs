using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Common
{
    public class ContactMessage
    {
        public string _message { get; set; }
        public string _emissorId { get; set; }
        public string _receiveId { get; set; }

        public ContactMessage()
        {
            
        }

        public ContactMessage(string id, string message)
        {
            _message = message;
            _emissorId = id;
        }

        public ContactMessage(string id, string receiveId, string message)
        {
            _message = message;
            _emissorId = id;
            _receiveId = receiveId;
        }

        public string GetMessage()
        {
            return _message;
        }

        public string GetEmissorId()
        {
            return _emissorId;
        }

        public void SetReceiveId(string id)
        {
            _receiveId = id;
        }

        public string GetReceiveId()
        {
            return _receiveId;
        }
    }
}
