namespace GF.Games.TurnSystem
{
    public interface IStateMachineState
    {
        void OnLeavingState<TState>(TState nextState) where TState : IStateMachineState;
        void OnEnteringState<TState>(TState stateBefore) where TState : IStateMachineState;
    }
}