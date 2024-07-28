﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TicTacToeAgentGame
{
	public class Facade : IDisposable
	{
		//<editor-fold desc="event listener interface & methods">
		/**
         *  A simple event listener interface, to listen for changes
         *  in the state of the board, as players make their moves
         */

		public bool IsWon = false;
		public bool IsDraw = false;
		public string userInform = string.Empty;

		public List<IPlayer> winnersBoard = new List<IPlayer>();

		public interface IStateChangedListener
		{
			void StateChanged(FiniteStateMachine currentBoard);
		}

		private ObservableCollection<IStateChangedListener> eventListeners = new ObservableCollection<IStateChangedListener>();

		public void AddSelectionListener(IStateChangedListener listener)
		{
			eventListeners.Add(listener);
		}

		public void RemoveSelectionListener(IStateChangedListener listener)
		{
			eventListeners.Remove(listener);
		}

		public void NotifyListeners(FiniteStateMachine board)
		{
			var listeners = eventListeners.GetEnumerator();
			//java.util.Iterator<Object> listeners = eventListeners.iterator();
			while (listeners.MoveNext())
			{
				((IStateChangedListener)listeners.Current).StateChanged(board);
			}
		}

		//</editor-fold>

		private IPlayer player1 = null;

		private IPlayer player2 = null;

		public FiniteStateMachine board = new FiniteStateMachine();

		/** 
         * Creates a new instance of Facade 
         */
		public Facade(IPlayer player1, IPlayer player2)
		{
			SetPlayer1(player1);
			SetPlayer2(player2);
		}

		public void Dispose()
		{
			disposed = true;
		}

		private bool disposed = false;
				
		int d = 0;

		public bool Disposed()
		{
			return disposed;
		}

		public bool Won()
		{
			SortedList<double, FiniteStateMachine> crossScore =  Goals.GetBestRanksFor(board, 1.0, FiniteStateMachine.State.cross);
			SortedList<double, FiniteStateMachine> noughtScore =  Goals.GetBestRanksFor(FiniteStateMachineExtensions.Inverse(board), 1.0, FiniteStateMachine.State.nought);


			return (crossScore.Count > 0 || noughtScore.Count > 0);			
		}

		public bool Draw()
		{
			return (d++) >= 9;
		}

		public async Task Begin()
		{
			IPlayer[] players = new IPlayer[] { GetPlayer1(), GetPlayer2() };
			IPlayer currentPlayer = null;

			// do a first update, to clear the board or something .. 
			this.NotifyListeners(board);

			int playerIndex = 1;
			// actually, while none of my rules fire ...
			while (!this.Won() && !this.Draw() && !Disposed())
			{
				// get a move from a player and update the board
				currentPlayer = players[playerIndex - 1];
				// get the move ... 
				Action move = await currentPlayer.DoMove(board, null, null);
				// update the board ...

				userInform = $"Player [ + {currentPlayer.GetType().Name} + \" ] \" + {playerIndex} + \" made move [ \" + {move.X} + \", \" + {move.Y} + \" ] ranking: \" + {move.Rank}";

				if (3 <= move.X || 3 <= move.Y)
				{
					Console.WriteLine("INVALID - RETRY :Player [" + currentPlayer.GetType().Name + " ] " + playerIndex + " made move [ " + move.X + ", " + move.Y + " ] ranking: " + move.Rank);
					move = await currentPlayer.DoMove(board, move.X, move.Y);
				}

				// i'm doind a little trick here ... I've rigged the playerIndex value
				// to return 1 or 2 ...which cast to X & O in CellState. So I'm controlling
				// the index in the players array and the update value for the board using this
				// single variable

				board.UpdateCell(move.X, move.Y, FiniteStateMachine.ParseState(playerIndex));

				// fire the notifyListeners event ... 
				NotifyListeners(board);

				// alternate the index, before i forget :P
				playerIndex = (playerIndex > 1) ? 1 : 2;
			}

			if (Won())
			{
				IsWon = true;
				winnersBoard.Add(currentPlayer);
			}
			else if (Draw())
			{
				IsDraw = true;
			}
		}


		public IPlayer GetPlayer1()
		{
			return player1;
		}

		public void SetPlayer1(IPlayer player1)
		{
			this.player1 = player1;
		}

		public IPlayer GetPlayer2()
		{
			return player2;
		}

		public void SetPlayer2(IPlayer player2)
		{
			this.player2 = player2;
		}
	}
}