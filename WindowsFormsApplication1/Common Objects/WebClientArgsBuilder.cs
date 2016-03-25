using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Common_Objects
{
    public class WebClientArgsBuilder
    {
        public WebClientServiceArgs CreateArgsForWebClientService(ProgressBar progressBar, Button button, Label lbl, CheckedListBox checkedListBox)
        {
            return new WebClientServiceArgs
            {
                StopButton = button,
                DownloadProgressBar = progressBar,
                DownloadableProgramsCheckedList = checkedListBox,
                DownloadProgressLabel = lbl,
            };
        }
    }
}
