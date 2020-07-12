using System;
using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class FightData : ComponentRepositorySet
    {
        public FightData() : this(Guid.NewGuid(), Guid.NewGuid())
        {
        }


        public FightData(Guid playerId, Guid enemyId)
        {
            this.PlayerId = playerId;
            this.EnemyId = enemyId;

            this.InitializeData();
        }

        public Guid PlayerId { get; }
        public Guid EnemyId { get; }

        private void InitializeData()
        {
            var healthComponentDictionary = this.GetRepository<HealthComponent>();
            healthComponentDictionary.Set(this.PlayerId, new HealthComponent(60, 60));
            healthComponentDictionary.Set(this.EnemyId, new HealthComponent(30, 30));
        }
    }
}