using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatSystem.Common;
using ChatSystem.Managers;

namespace ChatSystem
{
    public class WindowMessageNotificator
    {
        private IDictionary<string, ChatWindow> _windows;
        private ContactManager _contactManager;
        private ChatSystemMainWindow _mainWindow;

        public WindowMessageNotificator(ContactManager contactManager)
        {
            _windows = new Dictionary<string, ChatWindow>();
            _contactManager = contactManager;
        }

        public void SetMainWindow(ChatSystemMainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void AddWindowToDictionary(ChatWindow window)
        {
            window.SetWindowId(_windows.Count.ToString());
            _windows[_windows.Count.ToString()] = window;
        }

        public void UpdateOrCreateWindowIfNeeded(ContactMessage contactMessage)
        {
            if (contactMessage.GetReceiveId() == null)
            {
                var contactSearched = _contactManager.SearchContact();
                var form = _mainWindow.GetChatWindow(contactSearched);
                
                _mainWindow.Invoke((MethodInvoker)delegate () {
                    form.Show(this);
                    _windows.Last().Value.Update(contactMessage);
                });      
            }
            else
            {
                _mainWindow.Invoke((MethodInvoker)delegate () {
                    _windows[contactMessage.GetReceiveId()].Update(contactMessage);
                });         
            }
        }
    }
}
