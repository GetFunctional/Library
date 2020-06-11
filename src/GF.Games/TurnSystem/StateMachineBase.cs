using System;
using GF.CodeHelpers;

namespace GF.Games.TurnSystem
{
    public class StateMachineBase : IStateMachine
    {
        protected StateMachineBase(IStateMachineState initialState)
        {
            CodeGuard.ArgumentNotNull(initialState, nameof(initialState));
            this.CurrentState = initialState;
        }

        public IStateMachineState CurrentState { get; private set; }
        public event EventHandler<StateMachineStateChanged> StateChanged;

        public void SwitchState<TState>(TState newState) where TState : IStateMachineState
        {
            this.AssignNewState(newState);
        }

        private void AssignNewState<TState>(TState newState) where TState : IStateMachineState
        {
            if (newState.Equals(this.CurrentState))
            {
                throw new InvalidOperationException();
            }

            var oldState = this.CurrentState;
            oldState.OnLeavingState(newState);
            newState.OnEnteringState(oldState);
            this.CurrentState = newState;

            this.RaiseStateChanged(oldState, newState);
        }

        protected virtual void RaiseStateChanged(IStateMachineState oldState, IStateMachineState newState)
        {
            StateChanged?.Invoke(this, new StateMachineStateChanged(oldState, newState));
        }
    }
}