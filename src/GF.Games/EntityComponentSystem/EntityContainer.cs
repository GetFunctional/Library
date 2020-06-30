using System;
using System.Collections.Generic;

namespace GF.Games.EntityComponentSystem
{
    public class EntityContainer
    {
        private readonly HashSet<IEntity> _entities;
        private readonly Dictionary<int, IEntityComponent[]> _components;

        public EntityContainer()
        {
            this._entities = new HashSet<IEntity>();
        }

    }
}