using TicTacToeAgentGame;

namespace TicTacToeAgents
{
	public class SillyComputerPlayer : IPlayer
	{
		private FiniteStateMachine.State stateType;

		/** Creates a new instance of SillyComputerPlayer */
		public SillyComputerPlayer(FiniteStateMachine.State stateType)
		{
			this.stateType = stateType;
		}

		public async Task<TicTacToeAgentGame.Action> DoMove(FiniteStateMachine currentBoard)
		{
			// okay, first things first. What moves can I do at this state ?
			List<Point> possibleMoves = FiniteStateMachineExtensions.GetBlankCells(currentBoard);

			// now what i need to do, is check these moves out, one by one:

			// for each possibleMove, i need to rank it, through the Goals class, to the all winning boards.
			// I'm planning to sum up those numbers later, to get an average feel of how good that move actually is.
			// Right now, I'm only taking the best ranking under consideration, so at the end of this process, I'm 
			// left with a sorted list of all my possible moves, from best to worse ;]
			SortedList<double, Point> sortedMoves = new SortedList<double, Point>();
			for (int i = 0; i < possibleMoves.Count; i++)
			{
				// rank it ... 
				Point currentMove = possibleMoves[i];
				double ranking = RankMove(currentMove, currentBoard);
				// and add it ...
				sortedMoves.TryAdd(ranking, currentMove);
			}

			double predicated = 0.0;
			if (sortedMoves.Count > 0)
			{
				var firstElem = sortedMoves.FirstOrDefault();
				predicated = firstElem.Key;
			}


			Point move = sortedMoves.GetValueOrDefault(predicated);

			return new TicTacToeAgentGame.Action(move.X, move.Y, stateType);
		}

		protected double RankMove(Point moveToMake, FiniteStateMachine currentState)
		{
			// hmmm .. okay. .Let's make our move on that state thing ... 
			currentState.UpdateCell(moveToMake.X, moveToMake.Y, this.stateType);

			// now because I was lazy ... i didn't bother mak wining boards in the Goals class
			// for both noughts and crosses. So If I'm a noughts player, i'll 'inverse' this
			// current board before ranking, therfore immitating a 'crosses' player ... if that
			// all makes sence ?
			FiniteStateMachine evalAgainst = (FiniteStateMachine.State.cross.Equals(this.stateType)) ?
											   currentState : FiniteStateMachineExtensions.Inverse(currentState);

			// I need to get it ranked, through the Goals little helper class
			SortedList<double, FiniteStateMachine> rankings = Goals.GetBestRanksFor(evalAgainst, 0.0, FiniteStateMachine.State.cross);

			if (rankings.Count > 0)
				return rankings.First().Key;
			else
				return 0.0;
		}

		public double GetScore()
		{
			return 0.0;
		}
	}
}
