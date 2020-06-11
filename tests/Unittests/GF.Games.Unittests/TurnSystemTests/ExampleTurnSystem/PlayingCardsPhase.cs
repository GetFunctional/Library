using GF.Games.TurnSystem;

namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class PlayingCardsPhase : StateMachineState, ITurnState
    {
        private readonly PlayerActions _playerActions;

        public PlayingCardsPhase(PlayerActions playerActions)
        {
            _playerActions = playerActions;
        }

        public override void OnEnteringState<TState>(TState stateBefore)
        {
            _playerActions.AllowPlayingActions();
        }

        public override void OnLeavingState<TState>(TState nextState)
        {
            _playerActions.ForbidPlayingActions();
        }
    }
}