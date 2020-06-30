using System;

namespace GF.Games.EntityComponentSystem
{
    public interface IEntity : IEquatable<IEntity>
    {
        Guid Id { get; }
    }
}