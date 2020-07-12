using System.Threading;
using System.Threading.Tasks;
using GF.Games.EntityComponentSystem;
using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class PlayCardCommandHandler : IRequestHandler<PlayCardCommand>
    {
        public PlayCardCommandHandler(ComponentEventContext componentEventContext)
        {
            this.ComponentEventContext = componentEventContext;
        }

        public ComponentEventContext ComponentEventContext { get; }
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
    }
}