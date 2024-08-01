namespace TicTacToeAgentGame.Interfaces
{
    public interface IStateChangedListener
    {
        void StateChanged(FiniteStateMachine currentBoard);
    }
}
