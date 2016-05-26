using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSystem.Managers;

namespace ChatSystem.Notificators
{
    public abstract class AbstractNotificator
    {
        protected IDictionary<string, ChatWindow> _windows;
        protected ContactManager _contactManager;
        protected ChatSystemMainWindow _mainWindow;
    }
}
