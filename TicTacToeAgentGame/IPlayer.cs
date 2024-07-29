using System.Threading.Tasks;

namespace TicTacToeAgentGame
{
	public interface IPlayer
	{
		/*
     *  Computes how close the player is
     *  at completing a match
     */
		double GetScore();

		/*
         *  Returns the action the player wishes to take
         *  given the state of the board
         */
		Task<Action> DoMove(FiniteStateMachine state);
	}
}
