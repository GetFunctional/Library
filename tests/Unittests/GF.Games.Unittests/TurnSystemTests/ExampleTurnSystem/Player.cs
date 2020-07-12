namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class Player
    {
        public Player(PlayerActions playerActions, PlayerResources playerResources)
        {
            this.PlayerActions = playerActions;
            this.PlayerResources = playerResources;
        }

        public PlayerActions PlayerActions { get; }

        public PlayerResources PlayerResources { get; }
    }
}