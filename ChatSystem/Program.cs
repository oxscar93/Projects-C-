using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ChatSystem.Listeners;
using ChatSystem.Managers;
using ChatSystem.Notificators;
using ChatSystem.Services;

namespace ChatSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var contactManager = new ContactManager();
            var senderService = new SenderService();
            var windowsNotificator = new WindowMessageNotificator(contactManager);
            var messageListener = new MessageListener(windowsNotificator);


            var listenerThread = new Thread(messageListener.Start) {IsBackground = true};
            listenerThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatSystemMainWindow(contactManager, windowsNotificator, senderService));
        }
    }
}
