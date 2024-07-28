using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeAgentGame;

namespace TicTacToeAgents.Beliefs
{
    public class ICanBlockAWinSmart : ICanWinSmart
    {
        /** Creates a new instance of ICanBlockAWinSmart*/
        public ICanBlockAWinSmart(FiniteStateMachine fsm, FiniteStateMachine.State myState) : base(fsm, myState) 
        {
            // now 'inverse' myState ... therefore ... i'm the opponent ;]
            MyState = (FiniteStateMachine.State.cross.Equals(myState)) ? FiniteStateMachine.State.nought
                                                                      : FiniteStateMachine.State.nought.Equals(myState) ? FiniteStateMachine.State.cross
                                                                                                                       : FiniteStateMachine.State.blank;
        }
    }
}
