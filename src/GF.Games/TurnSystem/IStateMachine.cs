using System;

namespace GF.Games.TurnSystem
{
    public interface IStateMachine
    {
        IStateMachineState CurrentState { get; }
        event EventHandler<StateMachineStateChanged> StateChanged;
        void SwitchState<TState>(TState newState) where TState : IStateMachineState;
    }
}