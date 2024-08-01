using TicTacToeAgentGame;
using TicTacToeAgentGame.Interfaces;

namespace TicTacToeAgents
{
    public abstract class AbstractPlayer : IPlayer
	{
		protected FiniteStateMachine.State StateType;

		public AbstractPlayer(FiniteStateMachine.State stateType)
		{
			StateType = stateType;
		}

		protected double Score = 0.0;

		public abstract Task<TicTacToeAgentGame.Action> DoMove(FiniteStateMachine currentBoard);

		public double GetScore()
		{
			return Score;
		}
	}
}
