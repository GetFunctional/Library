using System.Collections.Generic;
using System.Linq;
using GF.Games.EffectSystem;
using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class Player : IEffectTarget
    {
        public Player(PlayerActions playerActions, PlayerResources playerResources)
        {
            this.PlayerActions = playerActions;
            this.PlayerResources = playerResources;
        }

        public PlayerActions PlayerActions { get; }

        public PlayerResources PlayerResources { get; }

        public EffectStackBag EffectStackBag { get; set; }
        public IList<IEffect> GetAllEffects()
        {
            return EffectStackBag.ToList();
        }

        public void ReduceHealth(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseHealth(int amount)
        {
            throw new System.NotImplementedException();
        }

        public TComponent GetComponent<TComponent>() where TComponent : IEntityComponent
        {
            throw new System.NotImplementedException();
        }
    }
}