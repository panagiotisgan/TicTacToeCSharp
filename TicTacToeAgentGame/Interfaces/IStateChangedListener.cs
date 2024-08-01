using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeAgentGame.Interfaces
{
    public interface IStateChangedListener
    {
        void StateChanged(FiniteStateMachine currentBoard);
    }
}
