using System.Collections.Generic;

namespace GF.Games.EffectSystem
{
    public interface IEffectCarrier
    {
        IList<IEffect> GetAllEffects();
    }
}