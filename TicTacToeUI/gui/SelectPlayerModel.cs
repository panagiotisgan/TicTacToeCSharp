using System.Collections.ObjectModel;
using TicTacToeAgentGame;

namespace TicTacToeUI.gui
{
	public class SelectPlayerModel
	{
		private string[] playerTypes = null;

		public SelectPlayerModel()
		{
			playerTypes = new string[] { "Human", "Silly Computer", "Complicated Silly Computer" };
		}

		internal string[] GetPlayerTypes()
		{
			if (playerTypes == null)
				return Array.Empty<string>();

			return playerTypes;
		}


		public interface ISelectionListener
		{
			public void SelectionMade(IPlayer player1, IPlayer player2);
		}

		internal ObservableCollection<ISelectionListener> eventListeners = new ObservableCollection<ISelectionListener>();

		public void AddSelectionListener(ISelectionListener listener)
		{
			eventListeners.Add(listener);
		}

		public void RemoveSelectionListener(ISelectionListener listener)
		{
			eventListeners.Remove(listener);
		}

		internal void NotifyListeners(IPlayer player1, IPlayer player2)
		{
			var listeners = eventListeners.GetEnumerator();
			while (listeners.MoveNext())
			{
				((ISelectionListener)listeners.Current).SelectionMade(player1, player2);
			}
		}
	}
}
