namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Player : IHasHealthComponent
    {
        public Player(HealthComponent health)
        {
            this.Health = health;
        }

        public HealthComponent Health { get; private set; }
    }
}