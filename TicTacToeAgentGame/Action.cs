namespace TicTacToeAgentGame
{
	public class Action : Point
	{
		/** Creates a new instance of Action */
		public Action(int row, int column, FiniteStateMachine.State updateState) : base(row, column)
		{
			//super(row, column);

			this.updateState = updateState;
		}

		public Action(int row, int column, double rank, FiniteStateMachine.State updateState) : base(row, column)
		{
			//super(row, column);

			this.Rank = rank;
			this.updateState = updateState;
		}

		public FiniteStateMachine.State updateState;

		public double Rank = 0.0;
	}
}
