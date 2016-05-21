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
using ChatSystem.Managers;

namespace ChatSystem
{
    public partial class AddContactWindow : Form
    {
        private readonly ContactManager _contactManager;

        public AddContactWindow(ContactManager contactManager)
        {
            InitializeComponent();
            _contactManager = contactManager;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var newContact = new Contact(name.Text, ipDirection.Text);
            _contactManager.AddContact(newContact);
        }
    }
}
