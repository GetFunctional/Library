using System;
using System.Collections.Generic;

namespace GF.Games.EntityComponentSystem
{
    public class ComponentRepositoryContext
    {
        private readonly Dictionary<Type, IComponentRepository> _componentRepositories =
            new Dictionary<Type, IComponentRepository>();


        public IComponentRepository<TComponent> GetRepository<TComponent>() where TComponent : IEntityComponent
        {
            var componentType = typeof(TComponent);
            return (IComponentRepository<TComponent>) this.GetRepository(componentType);
        }


        protected IComponentRepository GetRepository(Type componentType)
        {
            if (!_componentRepositories.ContainsKey(componentType))
            {
                var componentRepositoryType = typeof(ComponentRepository<>).MakeGenericType(componentType);
                var componentRepositoryInstance =
                    (IComponentRepository) Activator.CreateInstance(componentRepositoryType);
                _componentRepositories.Add(componentType, componentRepositoryInstance);
            }

            return _componentRepositories[componentType];
        }


        public TComponent GetComponent<TComponent>(Guid entityId) where TComponent : IEntityComponent
        {
            return this.GetRepository<TComponent>().Get(entityId);
        }

        public void ChangeComponent<TComponent>(Guid entityId, Func<TComponent, TComponent> changeFunc)
            where TComponent : IEntityComponent
        {
            var repository = this.GetRepository<TComponent>();
            var component = repository.Get(entityId);
            repository.Set(entityId, changeFunc(component));
        }
    }
}