namespace TicTacToeAgentGame
{
	public class FiniteStateMachine
	{
		public enum State { blank, cross, nought };

		public static int ParseInt(State state)
		{
			switch (state)
			{
				case State.cross:
					return 1;
				case State.nought:
					return 2;
				default:
					return 0;
			}
		}

		public static State ParseState(int state)
		{
			switch (state)
			{
				case 1:
					return State.cross;
				case 2:
					return State.nought;
				default:
					return State.blank;
			}
		}

		public static int NUMBEROFROWS = 3;
		public static int NUMBEROFCOLUMNS = 3;
		/**
        * represents the state of cells of game grid
        */
		private State[,] Grid;
		//private State[][] grid;

		/** Creates a new instance of FiniteStateMachine */
		public FiniteStateMachine()
		{
			//grid = new State[NUMBEROFROWS][];
			Grid = new State[NUMBEROFROWS, NUMBEROFCOLUMNS];
			for (int i = 0; i < NUMBEROFROWS; i++)
			{
				for (int j = 0; j < NUMBEROFCOLUMNS; j++)
				{
					Grid[i, j] = State.blank;
				}
			}
		}


		/** 
     *  Creates a new instance of FiniteStateMachine, 
     *  with an initial state as indicated by the initialState parameter
     */
		public FiniteStateMachine(int[][] initialState)
		{
			Grid = new State[NUMBEROFROWS, NUMBEROFCOLUMNS];
			for (int i = 0; i < NUMBEROFROWS; i++)
			{
				for (int j = 0; j < NUMBEROFCOLUMNS; j++)
				{
					Grid[i, j] = ParseState(initialState[i][j]);
				}
			}
		}


		/**
         * update the state of a cell in the game grid
        * @param row number
        * @param column number
        * @param new cell state
        */
		public void UpdateCell(int row, int column, State state)
		{
			Grid[row, column] = state;
		}

		/**
        * get the state of a cell in the game grid
        * @param row number
        * @param column number
        * @teturn state of cell in game grid
        */
		public State GetCellState(int row, int column)
		{
			return Grid[row, column];
		}

		/**
        * get the entire grid
        * @return reference to grid of states
        */
		public State[,] GetGrid()
		{
			return Grid;
		}

		/**
        *  Makes a clone of this instance. For "data privacy" ...
        */
		public FiniteStateMachine Clone()
		{
			FiniteStateMachine retVal = new FiniteStateMachine();

			for (int i = 0; i < NUMBEROFROWS; i++)
			{
				for (int j = 0; j < NUMBEROFCOLUMNS; j++)
				{
					retVal.UpdateCell(i, j, GetCellState(i, j));
				}
			}

			return retVal;
		}
	}
}
