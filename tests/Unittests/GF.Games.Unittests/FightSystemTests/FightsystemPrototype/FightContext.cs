using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GF.Games.EntityComponentSystem;
using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class FightContext : EcsContextBase
    {
        public FightContext() : this(Guid.NewGuid(), Guid.NewGuid())
        {
        }

        public FightContext(Guid playerId, Guid enemyId) : base(typeof(FightContext).GetTypeInfo().Assembly)
        {
            this.PlayerId = playerId;
            this.EnemyId = enemyId;

            this.InitializeData();

        }

        public Guid PlayerId { get; }
        public Guid EnemyId { get; }

        private void InitializeData()
        {
            var healthComponentDictionary = this.ComponentRepositoryContext.GetRepository<HealthComponent>();
            healthComponentDictionary.Set(this.PlayerId, new HealthComponent(60, 60));
            healthComponentDictionary.Set(this.EnemyId, new HealthComponent(30, 30));
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            return this.ComponentEventContext.Send(request, cancellationToken);
        }

        public TComponent GetComponent<TComponent>(Guid entityId) where TComponent : IEntityComponent
        {
            return this.ComponentRepositoryContext.GetComponent<TComponent>(entityId);
        }
    }
}