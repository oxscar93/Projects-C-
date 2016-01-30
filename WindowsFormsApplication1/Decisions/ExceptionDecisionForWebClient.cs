using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Decisions
{
    public class ExceptionDecisionForWebClient : AbstractDecision
    {
        public override string TriggerDecision(DecisionArgs args)
        {
            return args.Exception.Message;
        }

        public override bool IsDecisionBasedByNm(string decisionNm)
        {
            return decisionNm == Constants.ExceptionDecisionForWebClient;
        }

        public override bool IsDecisionBasedByArgs(DecisionArgs args)
        {
            return args.Exception != null;
        }
    }
}
