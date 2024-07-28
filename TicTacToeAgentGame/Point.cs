using System.Drawing;

namespace TicTacToeAgentGame
{
	public class Point
	{
		public static readonly Point Empty;


		// Parameters:
		//   sz:
		//     A System.Drawing.Size that specifies the coordinates for the new System.Drawing.Point.
		public Point(Size sz)
		{

		}

		// Parameters:
		//   x:
		//     The horizontal position of the point.
		//
		//   y:
		//     The vertical position of the point.
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		// Returns:
		//     The x-coordinate of this System.Drawing.Point.
		public int X { get; set; }

		// Returns:
		//     The y-coordinate of this System.Drawing.Point.
		public int Y { get; set; }
	}
}
