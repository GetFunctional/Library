using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GF.CodeHelpers;

namespace GF.Games.EffectSystem
{
    public sealed class EffectStackBag : IEnumerable<IEffect>
    {
        private readonly Dictionary<Type, IEffect> _effects;

        public EffectStackBag() : this(new HashSet<IEffect>())
        {
        }

        public EffectStackBag(ISet<IEffect> effects)
        {
            this._effects = effects.ToDictionary(key => key.GetType(), val => val);
        }
        
        public IEnumerator<IEffect> GetEnumerator()
        {
            return _effects.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void IncreaseEffect<T>(int amount) where T : IEffect
        {
            CodeGuard.ArgumentPositive(amount, nameof(amount));
            var effectType = typeof(T);
            if (this._effects.ContainsKey(effectType))
            {
                this._effects[effectType].IncreaseStack(amount);
            }
            else
            {
                var effect = (IEffect) Activator.CreateInstance<T>();
                effect.IncreaseStack(amount);
                this._effects.Add(effectType, Activator.CreateInstance<T>());
            }
        }

        public bool HasEffect<T>() where T : IEffect
        {
            var effectType = typeof(T);
            return this._effects.ContainsKey(effectType);
        }
    }
}