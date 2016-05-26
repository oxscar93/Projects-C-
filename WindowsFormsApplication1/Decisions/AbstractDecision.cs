using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Decisions
{
    public abstract class AbstractDecision
    {
        public abstract string TriggerDecision(DecisionArgs args);
        public abstract bool IsDecisionBasedByNm(string decisionNm);
        public abstract bool IsDecisionBasedByArgs(DecisionArgs args);
    }
}
