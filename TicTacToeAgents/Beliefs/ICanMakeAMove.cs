using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeAgentGame;

namespace TicTacToeAgents.Beliefs
{
    public class ICanMakeAMove : Belief
    {
        /**
    * Creates a new instance of ICanMakeAMove
    * @param reference to finite state machine
    */
        public ICanMakeAMove(FiniteStateMachine fsm, FiniteStateMachine.State myState) : base(fsm, myState)
        {
        }


        /**
         * update the belief that I can make a move,
         * assuming this is always true!
         */
        public override void Update()
        {
            // reset belief to default - "I don't believe it!"
            Predicate = 0.0;
            // create a list to hold all potential actions
            // i.e. the current blank cells
            List<TicTacToeAgentGame.Action> blanks = new List<TicTacToeAgentGame.Action>();
            // find the blank cells in the grid
            // use the Action class for convenience
            for (int i = 0; i < FiniteStateMachine.NUMBEROFROWS; i++)
            {
                for (int j = 0; j < FiniteStateMachine.NUMBEROFCOLUMNS; j++)
                {
                    if (Grid[i, j] == BLANKSTATE)
                    {
                        blanks.Add(new TicTacToeAgentGame.Action(i, j, 1.0, MyState));
                    }
                }
            }

            if (blanks.Count > 1)
            {
                // generate a random number
                 int randomNumber = GetRandomInRange(1, blanks.Count);
                // get a blank cell at random
                Action = blanks[randomNumber - 1];

                Predicate = 1.0; // now I believe it!!
            }
        }

        /**
        * get random number in range
        * @param lower bound of range
        * @param upper bound of range
        * @return random number in stated range
        */
        private int GetRandomInRange(int lower, int higher)
        {
            var random = new Random();
            return (int)(Math.Floor(random.NextDouble() *
                            (higher - lower - 1)) + lower);
        }
    }
}
