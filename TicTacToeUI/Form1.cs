using System.Collections.ObjectModel;
using TicTacToeAgentGame;
using TicTacToeAgentGame.Interfaces;
using TicTacToeUI.gui;

namespace TicTacToeUI
{
    public partial class Form1 : Form, ISelectionListener, IStateChangedListener
    {

		private Facade facade = null;
		private Form selectPlayersFrame = null;
		private SelectPlayerPanel selectPlayer = null;
		private int playerOneCounter = 0;
		private int playerTwoCounter = 0;

		internal Label[,] labels = null;
		internal ObservableCollection<ILabelClickListener> eventListeners = new ObservableCollection<ILabelClickListener>();

		internal IPlayer player1 = null;
		internal IPlayer player2 = null;

		public Form1()
		{
			InitializeComponent();

			labels = new Label[3, 3]
			{    {txt00, txt01, txt02},
				 {txt10, txt11, txt12},
				 {txt20, txt21, txt22}
			};
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Reset();
		}

		internal void Reset()
		{
			// nullify e v e r y t h i n g   ! ! !  :D
			player1 = null;
			player2 = null;
			facade = null;

			foreach(var item in labels)
			{
				item.Enabled = true;
			}

			selectPlayersFrame = null;

			selectPlayersFrame = new SelectPlayerPanel(this);
			selectPlayersFrame.Name = "Selected Players";

			selectPlayersFrame.AddOwnedForm(GetSelectPlayersPanel());
			selectPlayersFrame.Show();
		}

		public async Task SelectionMade(IPlayer player1, IPlayer player2)
		{
			// ok, get the players and be done with it ... 
			this.player1 = player1;
			this.player2 = player2;

			if (facade != null)
			{
				facade.Dispose();
			}

			facade = new Facade(player1, player2);
			facade.AddSelectionListener(this);

			selectPlayersFrame.Visible = false;

			await facade.Begin();

			if (facade.IsWon)
				MessageBox.Show("We have winner!");
			else if (facade.IsDraw)
				MessageBox.Show("We have draw.");


			if(facade.winnersBoard.Any() && facade.IsWon)
			{
				foreach(var winner in facade.winnersBoard)
				{
					if (winner.Equals(facade.GetPlayer1()))
						playerOneCounter++;
					else
					{
						playerTwoCounter++;
					}
				}
			}

			labelScore1.Text = playerOneCounter.ToString();
			labelScore2.Text = playerTwoCounter.ToString();
		}

		public void StateChanged(FiniteStateMachine currentBoard)
		{
			// okay, enumerate and set texts ... 
			for (int row = 0; row < FiniteStateMachine.NUMBEROFROWS; row++)
			{
				for (int column = 0; column < FiniteStateMachine.NUMBEROFCOLUMNS; column++)
				{
					FiniteStateMachine.State currState = currentBoard.GetCellState(row, column);
					string strVal = ". . .";
					if (currState.Equals(FiniteStateMachine.State.cross))
					{
						strVal = "X";
						labels[row, column].Enabled = false;
					}
					else if (currState.Equals(FiniteStateMachine.State.nought))
					{
						strVal = "O";
                        labels[row, column].Enabled = false;
                    }

					this.labels[row, column].Text = strVal;
				}
			}
		}

		protected SelectPlayerPanel GetSelectPlayersPanel()
		{
			if (null == selectPlayer)
			{
				selectPlayer = new SelectPlayerPanel(this);
				selectPlayer.AddSelectionListener(this);
			}

			return selectPlayer;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txt00_Click(object sender, EventArgs e)
		{
            LabelClicked(0, 0);
		}

		private void txt01_Click(object sender, EventArgs e)
		{
			txt01MouseClicked(sender, e);
		}

		private void txt02_Click(object sender, EventArgs e)
		{
			txt02MouseClicked(sender, e);
		}

		private void txt10_Click(object sender, EventArgs e)
		{
            LabelClicked(1, 0);
		}

		private void txt11_Click(object sender, EventArgs e)
		{
            LabelClicked(1, 1);
		}

		private void txt12_Click(object sender, EventArgs e)
		{
            LabelClicked(1, 2);
		}

		private void txt20_Click(object sender, EventArgs e)
		{
            LabelClicked(2, 0);
		}

		private void txt21_Click(object sender, EventArgs e)
		{
            LabelClicked(2, 1);
		}

		private void txt22_Click(object sender, EventArgs e)
		{
            LabelClicked(2, 2);
		}

		#region button clicked
		internal void txt02MouseClicked(object sender, EventArgs e)
		{
			LabelClicked(0, 2);
		}

		internal void txt01MouseClicked(object sender, EventArgs e)
		{
			LabelClicked(0, 1);
		}

		private void LabelClicked(int row, int column)
		{
			// fire the notifyListeners event ... 
			NotifyListeners(row, column);
		}

		public void AddSelectionListener(ILabelClickListener listener)
		{
			eventListeners.Add(listener);
		}

		public void RemoveSelectionListener(ILabelClickListener listener)
		{
			eventListeners.Remove(listener);
		}

		private void NotifyListeners(int row, int column)
		{
			var listeners = eventListeners.GetEnumerator();
			while (listeners.MoveNext())
			{
				((ILabelClickListener)listeners.Current).SelectionMade(row, column);
			}
		}
		#endregion


	}
}
