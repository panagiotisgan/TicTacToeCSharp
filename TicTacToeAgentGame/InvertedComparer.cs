using System.Collections.Generic;

namespace TicTacToeAgentGame
{
    public class InvertedComparer : Comparer<double>
    {
        public override int Compare(double x, double y)
        {
            return -x.CompareTo(y);
        }
    }
}
