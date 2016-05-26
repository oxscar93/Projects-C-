using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChatSystem.Common;
using ChatSystem.Managers;

namespace ChatSystem.Notificators
{
    public class WindowMessageNotificator : AbstractNotificator
    {
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
                var contactSearched = _contactManager.SearchContact(contactMessage.GetEmissorContactName());
                var chatWindow = _mainWindow.GetChatWindow(contactSearched);
                
                _mainWindow.Invoke((MethodInvoker)delegate () {
                    chatWindow.Show(this);
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
