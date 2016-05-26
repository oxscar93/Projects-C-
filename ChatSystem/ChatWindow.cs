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
using ChatSystem.Notificators;
using ChatSystem.Services;
using ChatSystem.UtilClasses;

namespace ChatSystem
{
    public partial class ChatWindow : Form
    {
        private readonly Contact _contact;
        private readonly SenderService _senderService;
        private string _windowEmissorId;
        private string _windowReceiveId;

        public ChatWindow(Contact contact, SenderService senderService)
        {
            InitializeComponent();
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

        public string GetWindowId()
        {
            return _windowEmissorId;
        }

        public void Show(WindowMessageNotificator windowMessageNotificator)
        {
            windowMessageNotificator.AddWindowToDictionary(this);
            Show();
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            Text = "Chat Window - " + _contact.GetName();
            messageTxt.Focus();
        }

        public void Update(ContactMessage message)
        {
            _ChangeTextColorOfConversationTxt(true, MessageParser.CreateConversationMessageForUser(conversationTxt.Text, message.GetMessage(),_contact.GetName() + ": "));
            _windowReceiveId = message.GetEmissorId();
            _senderService.SendData(_windowEmissorId, _contact.GetIp(), 13);
            Focus();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            var messageToSend = _windowReceiveId == null
                ? new ContactMessage(_windowEmissorId, messageTxt.Text) 
                : new ContactMessage(_windowEmissorId, _windowReceiveId, messageTxt.Text);

            _ChangeTextColorOfConversationTxt(false, MessageParser.CreateConversationMessageForUser(conversationTxt.Text, messageTxt.Text, "Me: "));
            _SetMessageTxtFocusAfterSendMessage();

            messageToSend.SetEmissorContactName(_contact.GetName());
            _senderService.SendData(MessageParser.ParseMessageToSendIt(messageToSend), _contact.GetIp(), 13);         
        }

        private void messageTxt_TextChanged(object sender, EventArgs e)
        {
            if (messageTxt.Text != string.Empty)
            {
                sendBtn.Enabled = true;
                return;
            }

            sendBtn.Enabled = false;
        }

        private void _ChangeTextColorOfConversationTxt(bool isEmissor, string msg)
        {
            var conversationLenght = conversationTxt.TextLength;

            if (conversationLenght == 0)
            {
                conversationTxt.AppendText(msg);
                conversationTxt.ForeColor = isEmissor ? Color.Red : Color.Green;
                return;
            }

            conversationTxt.AppendText(msg);
            conversationTxt.SelectionStart = conversationLenght; 
            conversationTxt.SelectionLength = msg.Length;
            conversationTxt.SelectionColor =  isEmissor ? Color.Red : Color.Green;
        }

        private void _SetMessageTxtFocusAfterSendMessage()
        {
            messageTxt.Text = string.Empty;
            messageTxt.Focus();
            sendBtn.Enabled = false;
        }
    }
}
