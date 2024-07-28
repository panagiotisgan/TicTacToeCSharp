using System;
using System.Collections.Generic;

namespace TicTacToeAgentGame
{
	public class InvertedComparer : Comparer<Double>
	{
		public override int Compare(double x, double y)
		{
			return -x.CompareTo(y);
		}
	}
}
