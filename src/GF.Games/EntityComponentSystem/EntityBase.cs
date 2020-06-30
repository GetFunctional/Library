using System;

namespace GF.Games.EntityComponentSystem
{
    public abstract class EntityBase : IEntity
    {
        protected EntityBase() : this(Guid.NewGuid())
        {
        }

        private EntityBase(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }

        public bool Equals(IEntity other)
        {
            return this.Id.Equals(other.Id);
        }

        protected bool Equals(EntityBase other)
        {
            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((EntityBase) obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}