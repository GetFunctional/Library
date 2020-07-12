using System;

namespace GF.Games.EntityComponentSystem
{
    public interface IComponentRepository<TComponent> : IComponentRepository where TComponent : IEntityComponent
    {
        TComponent Get(Guid entityId);
        void Set(Guid entityId, TComponent component);
    }

    public interface IComponentRepository
    {
    }
}