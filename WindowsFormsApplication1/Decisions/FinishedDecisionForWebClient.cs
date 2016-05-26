using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Decisions
{
    public class FinishedDecisionForWebClient : AbstractDecision
    {
        public override string TriggerDecision(DecisionArgs args)
        {
            return Constants.StatusFinished;
        }

        public override bool IsDecisionBasedByNm(string decisionNm)
        {
            return true; //TODO agregate constant name
        }

        public override bool IsDecisionBasedByArgs(DecisionArgs args)
        {
            var eventArgsOfWebClient = args.EventArgsOfWebClient;

            return eventArgsOfWebClient != null && !eventArgsOfWebClient.Cancelled && eventArgsOfWebClient.Error == null;
        }
    }
}
