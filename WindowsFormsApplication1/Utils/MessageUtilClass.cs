using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Utils
{
    public static class MessageUtilClass
    {
        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        public static bool ShowConditionalMessage(string msg, string title)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OKCancel) == DialogResult.OK;         
        }
    }
}
