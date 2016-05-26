using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChatSystem.Common;
using ChatSystem.UtilClasses;


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

        public Contact SearchContact(string name)
        {
            var contactsToList = ListParser.ConvertListBoxToListOfContacts(_contacts.Items);

            var contact = contactsToList.FirstOrDefault(c => c.GetName() == name);
          
            return contact;
        }
    }
}
