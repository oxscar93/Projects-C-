using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChatSystem.Common;


namespace ChatSystem.Managers
{
    public class ContactManager
    {
        private ListBox _contacts;

        public void RegistryListBox(ListBox listBox)
        {
            _contacts = listBox;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Items.Add(contact);
        }

        public Contact GetCurrentContactSelected()
        {
            return (Contact) _contacts.SelectedItem;
        }

        public Contact SearchContact()
        {
            return new Contact(null, "127.0.0.1");
        }
    }
}
