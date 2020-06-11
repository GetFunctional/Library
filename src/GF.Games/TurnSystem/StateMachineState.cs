namespace GF.Games.TurnSystem
{
    public class StateMachineState : IStateMachineState
    {
        public virtual void OnLeavingState<TState>(TState nextState) where TState : IStateMachineState
        {
        }

        public virtual void OnEnteringState<TState>(TState stateBefore) where TState : IStateMachineState
        {
        }
    }
}