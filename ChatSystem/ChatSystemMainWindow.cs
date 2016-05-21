using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatSystem.Common;
using ChatSystem.Factories;
using ChatSystem.Listeners;
using ChatSystem.Managers;
using ChatSystem.Services;

namespace ChatSystem
{
    public partial class ChatSystemMainWindow : Form
    {
        private readonly ContactManager _contactManager;
        private readonly WindowMessageNotificator _windowMessageNotificator;
        private readonly SenderService _senderService;
         
        public ChatSystemMainWindow(ContactManager contactManager, WindowMessageNotificator windowMessageNotificator, SenderService senderService)
        {
            _contactManager = contactManager;
            _windowMessageNotificator = windowMessageNotificator;
            _senderService = senderService;

            InitializeComponent();
            _InitializeObjects();        
        }

        private void _InitializeObjects()
        {
            _contactManager.RegistryListBox(contactsList);
            _windowMessageNotificator.SetMainWindow(this);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            WindowsFactory.GetInstance()
                .GetNewContactWindow(_contactManager).Show();     
        }

        private void contactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var contactSelected = _contactManager.GetCurrentContactSelected();
            GetChatWindow(contactSelected).Show(_windowMessageNotificator);
           
        }

        public ChatWindow GetChatWindow(Contact contact)
        {
            var form = WindowsFactory.GetInstance()
                .GetChatWindow(contact, _senderService);

            return form;
        }
    }
}
