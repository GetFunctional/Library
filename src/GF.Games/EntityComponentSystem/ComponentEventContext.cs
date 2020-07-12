using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using LightInject;
using MediatR;
using MediatR.Pipeline;

namespace GF.Games.EntityComponentSystem
{
    public class ComponentEventContext
    {
        private readonly IMediator _mediator;

        public ComponentEventContext(ServiceContainer serviceContainer, Assembly scanningAssembly)
        {
            _mediator = serviceContainer.GetInstance<IMediator>();
        }



        /// <summary>
        ///     Asynchronously send a request to a single handler
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A task that represents the send operation. The task result contains the handler response</returns>
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }

        /// <summary>
        ///     Asynchronously send a notification to multiple handlers
        /// </summary>
        /// <param name="notification">Notification object</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A task that represents the publish operation.</returns>
        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            return _mediator.Publish(notification, cancellationToken);
        }
    }
}