using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.EntityComponentSystemTests.ExampleComponentSystem
{
    public sealed class HealthComponent : IEntityComponent
    {
        public int Health { get; set; }
    }
}