using System;
using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Enemy : IEntity, IHasHealthComponent
    {
        public Enemy(HealthComponent health, Guid id)
        {
            this.Health = health;
            this.Id = id;
        }

        public HealthComponent Health { get; }
        public Guid Id { get; }
    }
}