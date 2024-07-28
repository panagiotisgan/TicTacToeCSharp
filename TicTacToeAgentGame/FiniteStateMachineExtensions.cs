using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TicTacToeAgentGame
{
    public static class FiniteStateMachineExtensions
    {
        /**
     *  Locates all the blank cells in the board. I.e. calculates
     *  all the possible moves from this state 
     */
        public static List<Point> GetBlankCells(FiniteStateMachine state)
        {

            List<Point> retVal = new List<Point>();
            for (int row = 0; row < FiniteStateMachine.NUMBEROFROWS; row++)
                for (int column = 0; column < FiniteStateMachine.NUMBEROFCOLUMNS; column++)
                {
                    if (FiniteStateMachine.State.blank.Equals(state.GetCellState(row, column)))
                        retVal.Add(new Point(row, column));
                }

            return retVal;
        }

        /**
     *  'Inverses' a board. Turns noughts into crosses
     *  and the opposite.
     */
        public static FiniteStateMachine Inverse(FiniteStateMachine state)
        {

            FiniteStateMachine retVal = new FiniteStateMachine();

            for (int row = 0; row < FiniteStateMachine.NUMBEROFROWS; row++)
                for (int column = 0; column < FiniteStateMachine.NUMBEROFCOLUMNS; column++)
                {
                    // get the old value, and determine the new, inverse, value
                    FiniteStateMachine.State oldVal = state.GetCellState(row, column);
                    FiniteStateMachine.State newVal = FiniteStateMachine.State.blank;

                    // Do the transformations if required ... 
                    if (FiniteStateMachine.State.nought.Equals(oldVal))
                        newVal = FiniteStateMachine.State.cross;

                    if (FiniteStateMachine.State.cross.Equals(oldVal))
                        newVal = FiniteStateMachine.State.nought;

                    retVal.UpdateCell(row, column, newVal);
                }

            return retVal;
        }


        /**
     *  Attempts to measure the similarity between two boards. It goes about counting the
     *  number of matching, or blank cells. That is divided by the total number of cells
     *  examined, to give an indication of 'close' the two boards are, and whether one of them
     *  can evolve to the other one. 
     *
     *  We can use that to determine if state1 is 'a good way of getting to state2' in simple terms
     */
        public static double SimilarityRank(FiniteStateMachine state1, FiniteStateMachine state2, FiniteStateMachine.State matchOn)
        {
            int matches = 0;
            int cellCount = 0;

            // loop the outter array on state1 ... and the inner array after that
            // and compare values ... 
            for (int row = 0; row < FiniteStateMachine.NUMBEROFROWS; row++)
                for (int column = 0; column < FiniteStateMachine.NUMBEROFCOLUMNS; column++)
                {
                    // get references to the values of the two cells, on the two
                    // boards
                    FiniteStateMachine.State cellState1 = state1.GetCellState(row, column);
                    FiniteStateMachine.State cellState2 = state2.GetCellState(row, column);

                    // are we the same ???
                    if (cellState1.Equals(matchOn))
                    {
                        if (cellState1.Equals(cellState2))
                            matches++;
                        else
                        // if this is an impossible option, i.e. there is something already in the position,
                        // that is not State.blank, then return zero. cold.
                        if (!FiniteStateMachine.State.blank.Equals(cellState2))
                            return 0.00;
                        // inc the cell count
                        cellCount++;
                    }
                }

            // okay ... we're done. Now, to see the results. 
            // ok, computes like this:
            // 1. If I've 0 matches, return 0%. It's just pointless ... 
            // 2. If matches equals cellCount, return 1.0. It's a bullseye !
            // 3. In any other case, return the ratio [cellCount / matches] in two decimals

            // Here goes ...
            if (0 == matches)
                return 0.0;

            if (cellCount == matches)
                return 1.0;

            return (double)matches / (double)cellCount;
        }
    }
}
