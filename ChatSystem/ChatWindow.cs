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
using ChatSystem.Listeners;
using ChatSystem.Services;
using ChatSystem.UtilClasses;

namespace ChatSystem
{
    public partial class ChatWindow : Form
    {
        private Contact _contact;
        private readonly SenderService _senderService;
        private string _windowEmissorId;
        private string _windowReceiveId;

        public ChatWindow(Contact contact, SenderService senderService)
        {
            InitializeComponent();
            this.messageTxt.Focus();
            _contact = contact;
            _senderService = senderService;
        }

        public void SetWindowId(string id)
        {
            _windowEmissorId = id;
        }

        public void SetWindowReceiveId(string id)
        {
            _windowReceiveId = id;
        }

        public void Show(WindowMessageNotificator windowMessageNotificator)
        {
            windowMessageNotificator.AddWindowToDictionary(this);
            Show();
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            Text = "Chat Window - " + _contact.GetName();
        }

        public void Update(ContactMessage message)
        {
            conversationTxt.Text += Environment.NewLine + MessageParser.ParseMessageToConversationText(_contact.GetName(), message.GetMessage());
            _windowReceiveId = message.GetEmissorId();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            var messageToSend = _windowReceiveId == null
                ? new ContactMessage(_windowEmissorId, messageTxt.Text) 
                : new ContactMessage(_windowEmissorId, _windowReceiveId, messageTxt.Text);

            _senderService.SendMessage(messageToSend, _contact.GetIp(), 13);
        }
    }
}
