using System;
using System.Collections.Generic;
using System.Reflection;

namespace GF.Games.EntityComponentSystem
{
    public class ComponentSystemContext
    {
        private readonly Dictionary<Type, IComponentSystem>
            _componentSystems = new Dictionary<Type, IComponentSystem>();
        
        public ComponentSystemContext(IEnumerable<IComponentSystem> systems)
        {
            foreach (var componentSystem in systems)
            {
                this.AddSystem(componentSystem);
            }
        }

        public void AddSystem<TComponentSystem>(TComponentSystem system)
            where TComponentSystem : IComponentSystem
        {
            _componentSystems.Add(system.GetType(), system);
        }

        public object GetSystem(Type systemType)
        {
            if (_componentSystems.ContainsKey(systemType))
            {
                return _componentSystems[systemType];
            }

            return null;
        }

        public TComponentSystem GetSystem<TComponentSystem>() where TComponentSystem : IComponentSystem
        {
            return (TComponentSystem) this.GetSystem(typeof(TComponentSystem));
        }
    }
}