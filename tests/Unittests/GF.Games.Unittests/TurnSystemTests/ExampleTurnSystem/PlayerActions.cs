namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class PlayerActions
    {
        public bool CanPlayActions { get; set; }

        public void AllowPlayingActions()
        {
            this.CanPlayActions = true;
        }

        public void ForbidPlayingActions()
        {
            this.CanPlayActions = false;
        }
    }
}