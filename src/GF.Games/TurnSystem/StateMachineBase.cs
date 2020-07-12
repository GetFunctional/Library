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
            if (newState.Equals(this.CurrentState) || !this.IsAllowedTransition(this.CurrentState, newState))
            {
                throw new InvalidOperationException(
                    $"That transition is not allowed. {this.CurrentState.GetType().Name} -> {newState.GetType().Name}");
            }

            var oldState = this.CurrentState;
            oldState.OnLeavingState(newState);
            newState.OnEnteringState(oldState);
            this.CurrentState = newState;

            this.RaiseStateChanged(oldState, newState);
        }

        protected virtual bool IsAllowedTransition<TState>(IStateMachineState currentState, TState newState)
            where TState : IStateMachineState
        {
            return true;
        }

        protected virtual void RaiseStateChanged(IStateMachineState oldState, IStateMachineState newState)
        {
            StateChanged?.Invoke(this, new StateMachineStateChanged(oldState, newState));
        }
    }
}