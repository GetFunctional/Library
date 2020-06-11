namespace GF.Games.TurnSystem
{
    public sealed class StateMachineStateChanged
    {
        public StateMachineStateChanged(IStateMachineState oldState, IStateMachineState newState)
        {
            OldState = oldState;
            NewState = newState;
        }

        public IStateMachineState OldState { get; }
        public IStateMachineState NewState { get; }
    }
}