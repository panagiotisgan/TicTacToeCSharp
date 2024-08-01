using System.Collections.ObjectModel;
using TicTacToeAgentGame;
using TicTacToeAgentGame.Interfaces;
using TicTacToeAgents;
using TicTacToeUI.gui;

namespace TicTacToeUI
{
    public partial class SelectPlayerPanel : Form
	{
		//internal SelectPlayerModel SelectPlayerModel { get; set; }

		internal ObservableCollection<ISelectionListener> eventListeners = new ObservableCollection<ISelectionListener>();
		private Form1 ParentFrame = null;
		private string[] playerTypes = null;
		public interface ISelectionListener
		{
			public Task SelectionMade(IPlayer player1, IPlayer player2);
		}


		public SelectPlayerPanel(Form1 ticTacToeForm)
		{
			//this.SelectPlayerModel = new SelectPlayerModel();

			InitializeComponent();

			playerTypes = new string[] { "Human", "Silly Computer", "Complicated Silly Computer" };

			cmbPlayer1Type.DataSource = playerTypes;

			cmbPlayer2Type.BindingContext = new BindingContext();
			cmbPlayer2Type.DataSource = playerTypes;
			ParentFrame = ticTacToeForm;
		}

		public void AddSelectionListener(ISelectionListener listener)
		{
			eventListeners.Add(listener);
		}

		public void RemoveSelectionListener(ISelectionListener listener)
		{
			eventListeners.Remove(listener);
		}

		internal async void NotifyListeners(IPlayer player1, IPlayer player2)
		{
			var listeners = eventListeners.GetEnumerator();
			while (listeners.MoveNext())
			{
				await ((ISelectionListener)listeners.Current).SelectionMade(player1, player2);
			}
		}

		private async void ActionPerformed()
		{
			string[] selectedValues = new string[] { "", "" };
			selectedValues[0] = (string)cmbPlayer1Type.SelectedItem;
			selectedValues[1] = (string)cmbPlayer2Type.SelectedItem;

			IPlayer[] players = new IPlayer[] { null, null };
			for (int i = 0; i < selectedValues.Count(); i++)
			{

				FiniteStateMachine.State playerState = (0 < i) ? FiniteStateMachine.State.nought : FiniteStateMachine.State.cross;

				if ("Human".Equals(selectedValues[i]))
				{
					players[i] = new GuiPlayer(ParentFrame, playerState);
				}
				else if ("Silly Computer".Equals(selectedValues[i]))
				{
					players[i] = new ComputerPlayer(playerState);
				}
				else if ("Complicated Silly Computer".Equals(selectedValues[i]))
				{
					players[i] = new SmarterComputerPlayer(playerState);
				}

			}

			await ParentFrame.SelectionMade(players[0], players[1]);
			NotifyListeners(players[0], players[1]);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ActionPerformed();
			button1.Enabled = false;
		}

		private void cmbPlayer1Type_SelectionChangeCommitted(object sender, EventArgs e)
		{
			button1.Enabled = true;
		}

		private void cmbPlayer2Type_SelectionChangeCommitted(object sender, EventArgs e)
		{
			button1.Enabled = true;
		}
	}
}
