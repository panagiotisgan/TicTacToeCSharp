using TicTacToeAgentGame;
using TicTacToeAgents.Beliefs;

namespace TicTacToeAgents
{
	public class ComputerPlayer : AbstractPlayer
	{


		private Belief[] beliefs = null;

		/** Creates a new instance of ComputerPlayer */
		public ComputerPlayer(FiniteStateMachine.State stateType) : base(stateType)
		{
		}

		public override async Task<TicTacToeAgentGame.Action> DoMove(FiniteStateMachine currentBoard)
		{
			// init my beliefs ... 
			beliefs = new Belief[] { new ICanWin(currentBoard, StateType), new ICanBlockAWin(currentBoard, StateType), new ICanMakeAMove(currentBoard, StateType) };
			for (int i = 0; i < beliefs.Length; i++)
			{
				beliefs[i].Update();
			}

			double iCanWin = beliefs[0].IsTrue();
			double iCanBlockAWin = beliefs[1].IsTrue();
			double iCanMove = beliefs[2].IsTrue();

			//Console.WriteLine("ICanWin: " + iCanWin + " ICanBlock: " + iCanBlockAWin + " ICanMove: " + iCanMove);

			// ok, if I can win ... go for it ... 
			if (iCanWin >= iCanBlockAWin && iCanWin > 0.0)
			{
				Score = beliefs[0].IsTrue();
				return beliefs[0].GetAction();
			}
			else if (iCanBlockAWin >= iCanMove)
			{
				Score = beliefs[1].IsTrue();
				return beliefs[1].GetAction();
			}

			Score = beliefs[2].IsTrue();
			return beliefs[2].GetAction();
		}
	}
}
