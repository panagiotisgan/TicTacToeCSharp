using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAgentGame.Interfaces
{
    public interface ISelectionListener
    {
        Task SelectionMade(IPlayer player1, IPlayer player2);
    }
}
