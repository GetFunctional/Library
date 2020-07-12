using System.Reflection;
using LightInject;
using MediatR;
using MediatR.Pipeline;

namespace GF.Games.EntityComponentSystem
{
    public abstract class EcsContextBase : IEcsContext
    {
        protected readonly ServiceContainer ServiceContainer;

        protected EcsContextBase(Assembly assemblyToScan)
        {
            ServiceContainer = this.CreateServiceContainer();

            this.RegisterCommonTypes(ServiceContainer, assemblyToScan);
            this.RegisterSystems(ServiceContainer, assemblyToScan);

            this.ComponentSystemContext =
                new ComponentSystemContext(ServiceContainer.GetAllInstances<IComponentSystem>());
            this.ComponentRepositoryContext = new ComponentRepositoryContext();
            this.ComponentEventContext =
                new ComponentEventContext(ServiceContainer, assemblyToScan);

            this.RegisterContext();
        }

        public ComponentRepositoryContext ComponentRepositoryContext { get; }
        public ComponentSystemContext ComponentSystemContext { get; }
        public ComponentEventContext ComponentEventContext { get; }

        private void RegisterSystems(ServiceContainer serviceContainer, Assembly assemblyToScan)
        {
            serviceContainer.RegisterAssembly(assemblyToScan, (serviceType, implementingType) =>
                serviceType.IsConstructedGenericType &&
                serviceType.GetGenericTypeDefinition() == typeof(IComponentSystem));
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

        private void RegisterContext()
        {
            ServiceContainer.RegisterInstance(this.ComponentSystemContext);
            ServiceContainer.RegisterInstance(this.ComponentEventContext);
            ServiceContainer.RegisterInstance(this.ComponentRepositoryContext);
            ServiceContainer.RegisterInstance(this);
            ServiceContainer.RegisterInstance<IEcsContext>(this);
        }

        private ServiceContainer CreateServiceContainer()
        {
            var serviceContainer = new ServiceContainer(new ContainerOptions
                {EnableVariance = false, EnablePropertyInjection = false});
            return serviceContainer;
        }
    }
}