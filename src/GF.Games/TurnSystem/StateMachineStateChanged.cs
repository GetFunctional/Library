namespace GF.Games.TurnSystem
{
    public sealed class StateMachineStateChanged
    {
        public StateMachineStateChanged(IStateMachineState oldState, IStateMachineState newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }

        public IStateMachineState OldState { get; }
        public IStateMachineState NewState { get; }
    }
}