using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WindowsFormsApplication1.Common_Objects;

namespace WindowsFormsApplication1.Decisions
{
    public class DecisionArgs
    {
       public Exception Exception { get; set; }
       public AsyncCompletedEventArgs EventArgsOfWebClient { get; set; }
       public ProgressBar ProgressBar { get; set; }
       public Label Label { get; set; }
       public Button Button { get; set;}
       public string DirectoryPath { get; set; }
       public Queue<DownloadableProgram> DownloadablePrograms { get; set; }
    }
}
