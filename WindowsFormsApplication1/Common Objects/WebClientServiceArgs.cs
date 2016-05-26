using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Common_Objects
{
    public class WebClientServiceArgs
    {
        public ProgressBar DownloadProgressBar { get; set; }
        public Label DownloadProgressLabel { get; set; }
        public CheckedListBox DownloadableProgramsCheckedList { get; set; }
        public Button StopButton { get; set; }
    }
}
