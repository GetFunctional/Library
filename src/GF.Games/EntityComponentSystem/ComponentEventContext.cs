using System;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
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
            RegisterCommonTypes(serviceContainer, scanningAssembly);
            this._mediator = serviceContainer.GetInstance<IMediator>();
        }

        private void RegisterCommonTypes(ServiceContainer serviceContainer, Assembly scanningAssembly)
        {
            serviceContainer.Register<IMediator, Mediator>();

            serviceContainer.RegisterAssembly(scanningAssembly, (serviceType, implementingType) =>
                serviceType.IsConstructedGenericType &&
                (
                    serviceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                    serviceType.GetGenericTypeDefinition() == typeof(INotificationHandler<>)
                ));

            serviceContainer.RegisterOrdered(typeof(IPipelineBehavior<,>),
                new[]
                {
                    typeof(RequestPreProcessorBehavior<,>),
                    typeof(RequestPostProcessorBehavior<,>)
                }, type => new PerContainerLifetime());

            serviceContainer.Register<ServiceFactory>(fac => fac.GetInstance);
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