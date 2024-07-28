using TicTacToeAgentGame;
using TicTacToeAgents;
using static TicTacToeAgentGame.FiniteStateMachine;

namespace TicTacToeUI.gui
{
	public class GuiPlayer : AbstractPlayer, ILabelClickListener
	{
		private bool listening = false;
		Form1 ui = null;
		private State playerState;
		private TicTacToeAgentGame.Action currentAction = null;
		private int? row = null;
		private int? column = null;

		/** Creates a new instance of GuiPlayer 
		*
		*  I need the uiInstance, to register for the event listeners of the labels in
		*  the gui. Somehow, I need to start listening for a click when my doMove() gets
		*  called, so I can have the player actually pick a move by clicking on a cell.
		*
		*  The hard part will be to block, and wait for that click actually, I got around that
		*  with the players selection panel, where i had to wait for the user to select the types
		*  pf players before continuing to start a new game. There, I just continued and started 
		*  the game in the event handler for the selectionMade event of the dialog. 
		*
		*  But here, perhaps I'm not so lucky. I need to return the value for doMove(), so I have to
		*  block the current thread and wait for the click, before continuing on the same method ! :(
		*/

		public GuiPlayer(State state, int row, int column) : base(state)
		{
			this.row = row;
			this.column = column;
		}

		public GuiPlayer(Form1 parentFrame, State playerState) : base(playerState)
		{
			this.playerState = playerState;
			ui = parentFrame;
		}

		public override async Task<TicTacToeAgentGame.Action> DoMove(FiniteStateMachine currentBoard, int? row = null, int? column = null)
		{
			// okay, start listening ... 
			Listen(true);

			MessageBox.Show(ui, "Make a move");

			//TODO C# Must make it work
			if (row.HasValue && column.HasValue)
				SelectionMade(row.Value, column.Value);
			else
			{
				currentAction = null;
			}

			//SelectionMade()

			while (currentAction == null)
			{
				try
				{
					//callingThread.
					await Task.Run(() =>
					{
						Thread.Sleep(2000);
					});
				}
				catch (ThreadInterruptedException e_int)
				{
					// swallow ... for now
				}
			}

			// stop listening .. 
			Listen(false);

			return currentAction;
		}

		/**
        *  Start / stop listening for clicks ... 
        */
		protected bool Listen(bool listening)
		{
			if (listening)
			{
				ui.AddSelectionListener((ILabelClickListener)this);
			}
			else
			{
				ui.RemoveSelectionListener(this);
			}

			return listening;
		}

		public void SelectionMade(int? row, int? column)
		{
			if (row.HasValue && column.HasValue)
				currentAction = new TicTacToeAgentGame.Action(row.Value, column.Value, StateType);
		}
	}
}
