using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Common;
using ChatSystem.Managers;
using ChatSystem.Services;

namespace ChatSystem.Factories
{
    public class WindowsFactory
    {
        public static WindowsFactory GetInstance()
        {
            return new WindowsFactory();
        }

        public AddContactWindow GetNewContactWindow(ContactManager contactManager)
        {
            return new AddContactWindow(contactManager);
        }

        public ChatWindow GetChatWindow(Contact contact, SenderService senderService)
        {
            return new ChatWindow(contact, senderService);
        }
    }
}
