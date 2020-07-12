using System;

namespace GF.Games.EntityComponentSystem
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}