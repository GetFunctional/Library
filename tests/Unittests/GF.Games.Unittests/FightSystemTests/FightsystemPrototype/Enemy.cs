namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Enemy : IHasHealthComponent
    {
        public Enemy(HealthComponent health)
        {
            this.Health = health;
        }

        public HealthComponent Health { get; }
    }
}