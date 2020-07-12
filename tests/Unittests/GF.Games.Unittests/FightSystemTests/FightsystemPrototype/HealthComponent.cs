using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public readonly struct HealthComponent : IEntityComponent
    {
        public HealthComponent(int healthValue, int healthMaxValue)
        {
            this.HealthValue = healthValue;
            this.HealthMaxValue = healthMaxValue;
        }

        public int HealthValue { get; }

        public int HealthMaxValue { get; }
    }
}