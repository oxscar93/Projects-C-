using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Common;
using Json;
using Newtonsoft.Json;

namespace ChatSystem.UtilClasses
{
    public static class MessageParser
    {
        public static string ParseMessageToConversationText(string name, string message)
        {
            return name + " " + DateTime.Now + ": " + message;
        }

        public static string ParseMessageToSendIt(ContactMessage contactMessage)
        {
            return JsonConvert.SerializeObject(contactMessage);
        }

        public static ContactMessage ParseMessageStringToObject(string message)
        {
            return JsonConvert.DeserializeObject<ContactMessage>(message);
        }
    }
}
