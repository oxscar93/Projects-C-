using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Decisions
{
    public class CancelledDownloadDecisionForWebClient: AbstractDecision
    {
        public override string TriggerDecision(DecisionArgs args)
        {
            args.ProgressBar.Value = 0;
            args.Label.Text = Constants.DownloadStopStatus;

            File.Delete(args.DirectoryPath);
            args.DownloadablePrograms.Clear();

            return Constants.DownloadStopStatusForDownloadableProgram;
        }

        public override bool IsDecisionBasedByNm(string decisionNm)
        {
            return decisionNm == Constants.CancelledDownloadDecisionForWebClient;
        }

        public override bool IsDecisionBasedByArgs(DecisionArgs args)
        {
            return args.EventArgsOfWebClient != null && args.EventArgsOfWebClient.Cancelled;
        }
    }
}
