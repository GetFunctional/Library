using System;
using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Player : IEntity, IHasHealthComponent
    {
        public Player(HealthComponent health, Guid id)
        {
            this.Health = health;
            this.Id = id;
        }

        public HealthComponent Health { get; }
        public Guid Id { get; }
    }
}