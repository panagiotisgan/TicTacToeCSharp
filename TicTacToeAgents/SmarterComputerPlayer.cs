using TicTacToeAgentGame;
using TicTacToeAgents.Beliefs;

namespace TicTacToeAgents
{
	public class SmarterComputerPlayer : AbstractPlayer
	{
		private Belief[] beliefs = null;

		/** Creates a new instance of SmarterComputerPlayer */
		public SmarterComputerPlayer(FiniteStateMachine.State stateType) : base(stateType) { }


		public override async Task<TicTacToeAgentGame.Action> DoMove(FiniteStateMachine currentBoard, int? row, int? column)
		{
			// init my beliefs ... 
			beliefs = new Belief[] { new ICanWinSmart(currentBoard, StateType), new ICanBlockAWinSmart(currentBoard, StateType), new ICanMakeAMove(currentBoard, StateType) };
			for (int i = 0; i < beliefs.Length; i++)
			{
				beliefs[i].Update();
			}

			double iCanWin = beliefs[0].IsTrue();
			double iCanBlockAWin = beliefs[1].IsTrue();
			double iCanMove = beliefs[2].IsTrue();

			//Console.WriteLine("ICanWinSmart: " + iCanWin + " ICanBlockSmart: " + iCanBlockAWin + " ICanMove: " + iCanMove);


			// if i'm ambivalent ... 0.6 is a certain defeat in the next move ! 
			if (iCanWin == iCanBlockAWin)
			{
				if (iCanBlockAWin > 0.6)
				{
					Score = beliefs[0].IsTrue();
					return beliefs[0].GetAction();
				}
				else
				{
					Score = beliefs[1].IsTrue();
					return beliefs[1].GetAction();
				}
			}

			if (iCanWin > iCanBlockAWin)
			{
				Score = beliefs[0].IsTrue();
				return beliefs[0].GetAction();
			}

			if (iCanBlockAWin > iCanWin)
			{
				Score = beliefs[1].IsTrue();
				return beliefs[1].GetAction();
			}

			Score = beliefs[2].IsTrue();
			return beliefs[2].GetAction();
		}
	}
}
