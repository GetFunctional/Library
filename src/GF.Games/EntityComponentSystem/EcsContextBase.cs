using System.Collections.Generic;
using System.Reflection;
using LightInject;

namespace GF.Games.EntityComponentSystem
{
    public abstract class EcsContextBase
    {
        protected readonly ServiceContainer ServiceContainer;

        protected EcsContextBase()
        {
            this.ServiceContainer = this.CreateServiceContainer();
            this.ComponentSystemContext = new ComponentSystemContext(this.InitializeSystems());
            this.ComponentRepositoryContext = new ComponentRepositoryContext();
            this.ComponentEventContext = new ComponentEventContext(ServiceContainer, this.GetType().GetTypeInfo().Assembly);

            ServiceContainer.RegisterInstance(this);
            ServiceContainer.RegisterInstance(this.ComponentSystemContext);
            ServiceContainer.RegisterInstance(this.ComponentEventContext);
            ServiceContainer.RegisterInstance(this.ComponentRepositoryContext);
        }

        protected abstract IEnumerable<IComponentSystem> InitializeSystems();


        public ComponentRepositoryContext ComponentRepositoryContext { get; }
        public ComponentSystemContext ComponentSystemContext { get; }
        public ComponentEventContext ComponentEventContext { get; }

        private ServiceContainer CreateServiceContainer()
        {
            var serviceContainer = new ServiceContainer(new ContainerOptions() { EnableVariance = false, EnablePropertyInjection = false });
            return serviceContainer;
        }
    }
}