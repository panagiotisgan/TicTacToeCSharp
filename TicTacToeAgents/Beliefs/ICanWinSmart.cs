using TicTacToeAgentGame;

namespace TicTacToeAgents.Beliefs
{
	public class ICanWinSmart : Belief
	{
		/** Creates a new instance of ICanWinSmart */
		public ICanWinSmart(FiniteStateMachine fsm, FiniteStateMachine.State myState) : base(fsm, myState) { }

		public override void Update()
		{
			// okay, first things first. What moves can I do at this state ?
			List<Point> possibleMoves = FiniteStateMachineExtensions.GetBlankCells(State);

			// now what i need to do, is check these moves out, one by one:

			// for each possibleMove, i need to rank it, through the Goals class, to the all winning boards.
			// I'm planning to sum up those numbers later, to get an average feel of how good that move actually is.
			// Right now, I'm only taking the best ranking under consideration, so at the end of this process, I'm 
			// left with a sorted list of all my possible moves, from best to worse ;]
			SortedList<double, Point> sortedMoves = new SortedList<double, Point>(
							// this is a 'reverse' Double comparator, i.e. larger to smaller
							new InvertedComparer());

			for (int i = 0; i < possibleMoves.Count; i++)
			{
				// rank it ... 
				Point myMove = possibleMoves[i];
				double ranking = RankMove(myMove, State.Clone());
				// and add it ...
				sortedMoves.TryAdd(ranking, myMove);
			}

			// check !
			if (0 == sortedMoves.Count)
			{
				Predicate = 0.0;
				Action = new TicTacToeAgentGame.Action(0, 0, MyState);

				return;
			}

			Predicate = sortedMoves.FirstOrDefault().Key;
			Point move = sortedMoves[Predicate];

			Action = new TicTacToeAgentGame.Action(move.X, move.Y, Predicate, MyState);
		}

		protected double RankMove(Point moveToMake, FiniteStateMachine currentState)
		{
			// hmmm .. okay. .Let's make our move on that state thing ... 
			currentState.UpdateCell(moveToMake.X, moveToMake.Y, MyState);

			// now because I was lazy ... i didn't bother mak wining boards in the Goals class
			// for both noughts and crosses. So If I'm a noughts player, i'll 'inverse' this
			// current board before ranking, therfore immitating a 'crosses' player ... if that
			// all makes sence ?
			FiniteStateMachine evalAgainst = (FiniteStateMachine.State.cross.Equals(MyState)) ?
											   currentState : FiniteStateMachineExtensions.Inverse(currentState);

			// I need to get it ranked, through the Goals little helper class
			SortedList<double, FiniteStateMachine> rankings = Goals.GetBestRanksFor(evalAgainst, 0.0, FiniteStateMachine.State.cross);

			if (rankings.Count > 0)
				return rankings.FirstOrDefault().Key;
			else
				return 0.0;
		}
	}
}
