using TicTacToeAgentGame;

namespace TicTacToeAgents.Beliefs
{
	public class ICanBlockAWin : ICanWin
	{

		/** Creates a new instance of ICanBlockAWin */
		public ICanBlockAWin(FiniteStateMachine fsm, FiniteStateMachine.State myState) : base(fsm, myState) { }


		public override void Update()
		{
			// if i can find two 'adjacent' - in tic tactoe terms - that are
			// followed by a blank, I'm okay !

			FiniteStateMachine.State lookingFor = (MyState.Equals(CROSSSTATE)) ? NOUGHTSTATE : CROSSSTATE;
			List<Point> adjacentPoints = new List<Point>();

			Predicate = 0.0;

			int moveX = 0;
			int moveY = 0;

			for (int i = 0; i < FiniteStateMachine.NUMBEROFROWS && Predicate < 1.0; i++)
			{
				for (int j = 0; j < FiniteStateMachine.NUMBEROFCOLUMNS && Predicate < 1.0; j++)
				{
					FiniteStateMachine.State currState = Grid[i, j];
					Point newPoint = new Point(i, j);
					if (lookingFor.Equals(currState))
					{
						// okay, now, I'm on one of three states here ... 
						// 1. I'm looking for the first cell that matches myState => adjacentFound = 0;
						if (adjacentPoints.Count == 0)
						{
							// found my first one !!!
							adjacentPoints.Add(new Point(i, j));
						}
						else if (adjacentPoints.Count == 1)
						{
							// is it a match, position-wise ?
							if (IsAdjacent(adjacentPoints, newPoint))
							{
								// found my second one !!!
								adjacentPoints.Add(newPoint);
								// change the state I'm looking for ...
								lookingFor = FiniteStateMachine.State.blank;

								// now, depending on how defensive i wanna be, i could leave this
								// be 0.66 .. now i won't react, until it is really necessary ...
								// predicate = 0.66;
							}
						}
						else if (adjacentPoints.Count == 2)
						{
							if (IsAdjacent(adjacentPoints, newPoint))
							{
								Predicate = 1.0;

								moveX = i;
								moveY = j;

								break;
							}
						}
					}
				}
			}

			Action = new TicTacToeAgentGame.Action(moveX, moveY, MyState);
		}
	}
}
