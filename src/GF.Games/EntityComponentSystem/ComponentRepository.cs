using System;
using System.Collections.Generic;

namespace GF.Games.EntityComponentSystem
{
    public class ComponentRepository<TComponent> : IComponentRepository<TComponent> where TComponent : IEntityComponent
    {
        private readonly Dictionary<Guid, IEntityComponent> _components = new Dictionary<Guid, IEntityComponent>();

        public TComponent Get(Guid entityId)
        {
            if (_components.ContainsKey(entityId))
            {
                return (TComponent) _components[entityId];
            }

            return default;
        }

        public void Set(Guid entityId, TComponent component)
        {
            if (_components.ContainsKey(entityId))
            {
                _components[entityId] = component;
            }
            else
            {
                _components.Add(entityId, component);
            }
        }
    }
}