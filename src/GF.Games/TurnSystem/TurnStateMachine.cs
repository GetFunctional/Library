namespace GF.Games.TurnSystem
{
    public class TurnStateMachine : StateMachineBase, ITurnStateMachine
    {
        public TurnStateMachine(IStateMachineState initialState) : base(initialState)
        {
        }
    }
}