using System.Collections.Generic;

namespace TicTacToeAgentGame
{
	public class Goals
	{
		#region <editor-fold desc="winning boards" >
		static int[][] board0_horiz = new int[][] {
			 new int[]{1, 1, 1},
			 new int[]{0, 0, 0},
			 new int[]{0, 0, 0}
		};

		static int[][] board1_horiz = new int[][] {
			 new int[]{0, 0, 0},
			 new int[]{1, 1, 1},
			 new int[]{0, 0, 0}
		};

		static int[][] board2_horiz = new int[][] {
			 new int[]{0, 0, 0},
			 new int[]{0, 0, 0},
			 new int[]{1, 1, 1}
		};


		static int[][] board0_vert = new int[][] {
			 new int[]{1, 0, 0},
			 new int[]{1, 0, 0},
			 new int[]{1, 0, 0}
		};

		static int[][] board1_vert = new int[][] {
			 new int[]{0, 1, 0},
			 new int[]{0, 1, 0},
			 new int[]{0, 1, 0}
		};

		static int[][] board2_vert = new int[][] {
			 new int[]{0, 0, 1},
			 new int[]{0, 0, 1},
			 new int[]{0, 0, 1}
		};


		static int[][] board0_diag = new int[][] {
			 new int[]{1, 0, 0},
			 new int[]{0, 1, 0},
			 new int[]{0, 0, 1}
		};

		static int[][] board1_diag = new int[][] {
			 new int[]{0, 0, 1},
			 new int[]{0, 1, 0},
			 new int[]{1, 0, 0}
		};
		#endregion </editor-fold>

		private static List<FiniteStateMachine> _desiredStates = null;

		protected static List<FiniteStateMachine> GetDesiredStates()
		{
			if (null == _desiredStates)
			{

				_desiredStates = new List<FiniteStateMachine>();

				_desiredStates.Add(new FiniteStateMachine(board0_horiz));
				_desiredStates.Add(new FiniteStateMachine(board1_horiz));
				_desiredStates.Add(new FiniteStateMachine(board2_horiz));

				_desiredStates.Add(new FiniteStateMachine(board0_vert));
				_desiredStates.Add(new FiniteStateMachine(board1_vert));
				_desiredStates.Add(new FiniteStateMachine(board2_vert));

				_desiredStates.Add(new FiniteStateMachine(board0_diag));
				_desiredStates.Add(new FiniteStateMachine(board1_diag));
			}

			return _desiredStates;
		}

		/** Creates a new instance of Goals */
		public Goals()
		{
		}


		public static SortedList<double, FiniteStateMachine> GetBestRanksFor(FiniteStateMachine currentState, double lowerBound, FiniteStateMachine.State matchOn)
		{
			// oookay .. now here's the tough cookie. 
			// i need to go through all the wining boards, and rank them again the 
			// board i was given. Then, i must return at most the results whose rank is >= 
			// to what i was instructed to ...

			// create the "results" map ... 
			SortedList<double, FiniteStateMachine> retVal = new SortedList<double, FiniteStateMachine>(
												// this is a 'reverse' Double comparator, i.e. larger to smaller
												new InvertedComparer()
												);
			// get a local reference of the desired states ... for debugging .. 

			List<FiniteStateMachine> desiredStates = GetDesiredStates();

			// and now loop, to create the rankings ...
			for (int i = 0; i < desiredStates.Count; i++)
			{
				// compute my ranking ... 
				var key = FiniteStateMachineExtensions.SimilarityRank(desiredStates[i], currentState, FiniteStateMachine.State.cross);

				// if my similarity is below the treshold given, don't bother with this
				// one any more ... 
				if (lowerBound > key)
					continue;
				// some of these computations are bound to have the same result. 
				// which means that key may already be there. I'm incrementing it very slightly,
				// so that all the matching boards are properly included in the returning
				// list

				while (retVal.ContainsKey(key))
					key += 0.001;

				// okay, now write my 'safe' key into the map ... 
				retVal.Add(key, desiredStates[i]);
			}

			// and return the map. 
			return retVal;
		}

	}
}

