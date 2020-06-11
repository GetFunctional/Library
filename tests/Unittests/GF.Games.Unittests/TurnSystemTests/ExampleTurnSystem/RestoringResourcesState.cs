using GF.Games.TurnSystem;

namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class RestoringResourcesState : StateMachineState, ITurnState
    {
        private readonly PlayerResources _playerResources;

        public RestoringResourcesState(PlayerResources playerResources)
        {
            _playerResources = playerResources;
        }

        public override void OnEnteringState<TState>(TState stateBefore)
        {
            _playerResources.RefreshActionTokensForNextTurn();
        }
    }
}