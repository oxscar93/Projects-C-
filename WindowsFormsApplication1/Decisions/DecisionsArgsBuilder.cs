using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Common_Objects;

namespace WindowsFormsApplication1.Decisions
{
    public class DecisionsArgsBuilder
    {
        public DecisionArgs Build(Exception e)
        {
            return new DecisionArgs
            {
                Exception = e
            };
        }

        public DecisionArgs Build(AsyncCompletedEventArgs eventArgs)
        {
            return new DecisionArgs
            {
                EventArgsOfWebClient = eventArgs
            };
        }

        public DecisionArgs Build(AsyncCompletedEventArgs eventArgs, ProgressBar progressBar, string directoryPath, Queue<DownloadableProgram> downloadablePrograms, Label label)
        {
            return new DecisionArgs
            {
                EventArgsOfWebClient = eventArgs,
                ProgressBar = progressBar,
                DirectoryPath = directoryPath,
                DownloadablePrograms = downloadablePrograms,
                Label = label
            };
        }
    }
}
