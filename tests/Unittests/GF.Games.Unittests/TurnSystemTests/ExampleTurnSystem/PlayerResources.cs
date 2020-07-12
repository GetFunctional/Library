namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class PlayerResources
    {
        public PlayerResources(int maximumActions, int initialAvailableActions)
        {
            this.MaximumActions = maximumActions;
            this.AvailableActions = initialAvailableActions;
        }

        public int MaximumActions { get; }
        public int AvailableActions { get; private set; }

        public void RefreshActionTokensForNextTurn()
        {
            if (this.AvailableActions + 3 > this.MaximumActions)
            {
                this.AvailableActions = this.MaximumActions;
            }
            else
            {
                this.AvailableActions = this.AvailableActions + 3;
            }
        }

        public void ReduceAvailableActions(int reduction)
        {
            if (this.AvailableActions - reduction < 0)
            {
                this.AvailableActions = 0;
            }
            else
            {
                this.AvailableActions -= reduction;
            }
        }
    }
}