using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Decisions
{
    public class DecisionsFactory
    {
        private readonly IList<AbstractDecision> _decisions;

        public DecisionsFactory()
        {
            _decisions = new List<AbstractDecision>
            {
                new ExceptionDecisionForWebClient(),
                new CancelledDownloadDecisionForWebClient(),
                new FinishedDecisionForWebClient(),
                new EventErrorDecisionForWebClient()
            };
        }

        public AbstractDecision GetDecisionByName(string decisionNm)
        {
            return _decisions.FirstOrDefault(decision => decision.IsDecisionBasedByNm(decisionNm));
        }

        public AbstractDecision GetDecisionBasedOnArgs(DecisionArgs args)
        {
            return _decisions.FirstOrDefault(decision => decision.IsDecisionBasedByArgs(args));
        }
    }
}
