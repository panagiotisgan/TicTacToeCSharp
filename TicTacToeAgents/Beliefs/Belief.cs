using TicTacToeAgentGame;

namespace TicTacToeAgents.Beliefs
{
    public abstract class Belief
    {
        /* some finals for convenience, to save typing */
        protected static  FiniteStateMachine.State BLANKSTATE = FiniteStateMachine.State.blank;
        protected static  FiniteStateMachine.State NOUGHTSTATE = FiniteStateMachine.State.nought;
        protected static  FiniteStateMachine.State CROSSSTATE = FiniteStateMachine.State.cross;

        /** boolean to hold truth of belief */
        protected double Predicate;
        /** reference to enviroment i.e. the grid of cells */
        protected FiniteStateMachine.State[,] Grid;
        /* and the actual FiniteStateMachine is also nice ... :) */
        protected FiniteStateMachine State = null;
        /** based on our beliefs, we determine the correct action */
        protected TicTacToeAgentGame.Action Action;
        /** the state we're playgin with ... */
        protected FiniteStateMachine.State MyState;

        /** Creates a new instance of Belief */
        public Belief(FiniteStateMachine fsm, FiniteStateMachine.State myState)
        {
            Predicate = 0.0; // I don't believe it!!
            Grid = fsm.GetGrid();
            Action = null; // the action is unknown right now
            this.MyState = myState;
            this.State = fsm;
        }

        /**
        * is the belief true?
        * @return true if belief holds, false otherwise
        */
        public double IsTrue()
        {
            return Predicate;
        }
        /**
        * update the belief
        */
        public abstract void Update();
        /**
        * get the action as determined from the belief
        * Note: this is null until the Beliefs are updated
        * @return action
        */
        public TicTacToeAgentGame.Action GetAction()
        {
            return Action;
        }
    }
}
