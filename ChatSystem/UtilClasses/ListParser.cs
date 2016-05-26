using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatSystem.Common;

namespace ChatSystem.UtilClasses
{
    public static class ListParser
    {
        public static IList<Contact> ConvertListBoxToListOfContacts(ListBox.ObjectCollection objects)
        {
            return objects.Cast<Contact>().ToList();
        }
    }
}
