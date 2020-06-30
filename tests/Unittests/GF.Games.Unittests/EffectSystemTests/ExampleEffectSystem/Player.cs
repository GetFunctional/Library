using System.Collections.Generic;
using System.Linq;
using GF.Games.EffectSystem;
using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.EffectSystemTests.ExampleEffectSystem
{
    internal class Player : IEffectTarget
    {
        private readonly EffectStackBag _effects;

        public Player() : this(new EffectStackBag())
        {
        }

        public Player(EffectStackBag effectStackBag)
        {
            _effects = effectStackBag;
            this.Health = 60;
        }

        public bool HasEffect<T>() where T : IEffect
        {
            return _effects.HasEffect<T>();
        }

        public void ApplyEffect<T>(int amount) where T : IEffect
        {
            _effects.IncreaseEffect<T>(amount);
        }


        public int Health { get; set; }
        public IList<IEffect> GetAllEffects()
        {
            return _effects.ToList();
        }

        public void ReduceHealth(int amount)
        {
            this.Health -= amount;
        }

        public void IncreaseHealth(int amount)
        {
            this.Health += amount;
        }

        public TComponent GetComponent<TComponent>() where TComponent : IEntityComponent
        {
            throw new System.NotImplementedException();
        }
    }
}