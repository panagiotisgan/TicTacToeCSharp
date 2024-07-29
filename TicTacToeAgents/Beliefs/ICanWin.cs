using TicTacToeAgentGame;

namespace TicTacToeAgents.Beliefs
{
	public class ICanWin : Belief
	{
		public ICanWin(FiniteStateMachine fsm, FiniteStateMachine.State myState) : base(fsm, myState) { }
			

		public override void Update()
		{
			// if i can find two 'adjacent' - in tic tactoe terms - that are
			// followed by a blank, I'm okay !

			FiniteStateMachine.State lookingFor = MyState;
			List<Point> adjacentPoints = new List<Point>();

			Predicate = 0.0;

           int[] backUpBlankState = new int[2];

			int moveX = 0;
			int moveY = 0;

			for (int i = 0; i < FiniteStateMachine.NUMBEROFROWS && Predicate < 1.0; i++)
			{
				for (int j = 0; j < FiniteStateMachine.NUMBEROFCOLUMNS && Predicate < 1.0; j++)
				{
					FiniteStateMachine.State currState = Grid[i, j];
					
					// add it with purpose to fix the bug which override the gui player move in order to win
					if (currState == FiniteStateMachine.State.blank)
					{
						backUpBlankState[0] = i;
						backUpBlankState[1] = j;
					}

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

								Predicate = 0.66;
							}
						}
						else if (adjacentPoints.Count == 2)
						{
							if (IsAdjacent(adjacentPoints, newPoint))
							{
								Predicate = 1.0;

								moveX = i;
								moveY = j;

                                Action = new TicTacToeAgentGame.Action(moveX, moveY, MyState);

                                break;
							}
						}
					}
				}
			}

			//if(adjacentPoints.Count == 1)
			//	Action = new TicTacToeAgentGame.Action(adjacentPoints[0].X, adjacentPoints[0].Y, MyState);

			if(adjacentPoints.Count == 0)
				Action = new TicTacToeAgentGame.Action(moveX, moveY, MyState);
			else
				Action = new TicTacToeAgentGame.Action(backUpBlankState[0], backUpBlankState[1], MyState);
        }

        protected bool IsAdjacent(List<Point> points, Point newPoint)
        {
            // now ... for those points to 'adjacent' in a tic tac toe terms ..
            // they either all share the same row
            // or the same column
            // or ... their corresponding sums or row and column is equal to 3 :P 

            List<Point> searchList = new List<Point>();
            searchList.AddRange(points);
            searchList.Add(newPoint);

            // <editor-fold desc="do they share the same x dimension ?">
            bool shareX = true;
            int x = -1;
            for (int i = 0; i < searchList.Count && shareX; i++)
            {
                Point toExamineX = searchList[i];
                // if this is my first run ... 
                if (x < 0)
                    x = toExamineX.X;

                shareX &= (x == toExamineX.X);
            }

            if (shareX)
                return true;
            // </editor-fold>

            // <editor-fold desc="do they share the same y dimension ?">
            bool shareY = true;
            int y = -1;
            for (int c = 0; c < searchList.Count && shareY; c++)
            {
                Point toExamineY = searchList[c];
                // if this is my first run ... 
                if (y < 0)
                    y = toExamineY.Y;

                shareY &= (y == toExamineY.Y);
            }

            if (shareY)
                return true;
            // </editor-fold>

            // <editor-fold desc="x and y all sum up to three ?">
            int totalX = 0;
            int totalY = 0;
            for (int p = 0; p < searchList.Count; p++)
            {
                totalX += searchList[p].X;
                totalY += searchList[p].Y;
            }

            if (totalX == 3 && totalY == 3)
                return true;

            // </editor-fold>

            return false;
        }
    }
}
