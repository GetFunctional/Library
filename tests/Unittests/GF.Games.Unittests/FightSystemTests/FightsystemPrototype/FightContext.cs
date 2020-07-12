using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GF.Games.EntityComponentSystem;
using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class FightContext : EcsContextBase, IEcsContext, IRequestHandler<PlayCardCommand>
    {
        public FightContext() : this(Guid.NewGuid(), Guid.NewGuid())
        {
        }

        public FightContext(Guid playerId, Guid enemyId)
        {
            this.PlayerId = playerId;
            this.EnemyId = enemyId;

            this.InitializeData();
        }

        public Guid PlayerId { get; }
        public Guid EnemyId { get; }


        public async Task<Unit> Handle(PlayCardCommand request, CancellationToken cancellationToken)
        {
            await this.ComponentEventContext
                .Publish(new BeforePlayingCardEvent(request.Card, request.Target), cancellationToken)
                .ConfigureAwait(false);
            await this.ComponentEventContext
                .Publish(new PlayingCardEvent(request.Card, request.Target), cancellationToken)
                .ConfigureAwait(false);
            await this.ComponentEventContext
                .Publish(new AfterPlayingCardEvent(request.Card, request.Target), cancellationToken)
                .ConfigureAwait(false);
            return Unit.Value;
        }

        protected override IEnumerable<IComponentSystem> InitializeSystems()
        {
            return Enumerable.Empty<IComponentSystem>();
        }

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