using System.Threading;
using System.Threading.Tasks;
using GF.Games.EntityComponentSystem;
using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class HealthComponentSystem : IComponentSystem, INotificationHandler<TakeDamageEvent>
    {
        private readonly IEcsContext _context;

        public HealthComponentSystem(IEcsContext context)
        {
            _context = context;
        }

        public async Task Handle(TakeDamageEvent notification, CancellationToken cancellationToken)
        {
            _context.ComponentRepositoryContext.ChangeComponent<HealthComponent>(notification.Target.Id, c => new HealthComponent(c.HealthValue - notification.Damage, c.HealthMaxValue));
            await Task.CompletedTask;
        }
    }
}