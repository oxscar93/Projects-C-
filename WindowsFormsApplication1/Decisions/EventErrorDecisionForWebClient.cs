using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Decisions
{
    public class EventErrorDecisionForWebClient : AbstractDecision
    {
        public override string TriggerDecision(DecisionArgs args)
        {
            MessageBox.Show(Constants.ErrorMsgInvalidLink);
            return Constants.StatusError;
        }
        
        public override bool IsDecisionBasedByNm(string decisionNm)
        {
            return false; //TODO agregate name on constants
        }

        public override bool IsDecisionBasedByArgs(DecisionArgs args)
        {
            return args.EventArgsOfWebClient?.Error != null;
        }
    }
}
