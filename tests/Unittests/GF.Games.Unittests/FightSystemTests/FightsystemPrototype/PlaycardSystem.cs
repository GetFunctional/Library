using System.Threading;
using System.Threading.Tasks;
using GF.Games.EntityComponentSystem;
using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class PlaycardSystem : INotificationHandler<PlayingCardEvent>
    {
        private readonly IEcsContext _ecsContext;

        public PlaycardSystem(IEcsContext ecsContext)
        {
            _ecsContext = ecsContext;
        }


        public Task Handle(PlayingCardEvent notification, CancellationToken cancellationToken)
        {
            return _ecsContext.ComponentEventContext.Publish(new TakeDamageEvent(6, notification.Target), cancellationToken);
        }
    }
}