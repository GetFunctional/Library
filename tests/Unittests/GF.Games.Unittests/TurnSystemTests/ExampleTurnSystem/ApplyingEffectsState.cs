using System.Collections.Generic;
using System.Linq;
using GF.Games.EffectSystem;
using GF.Games.TurnSystem;

namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    internal class ApplyingEffectsState : StateMachineState, ITurnState
    {
        private readonly IList<Player> _players;

        public ApplyingEffectsState(IList<Player> players)
        {
            this._players = players;
        }

        public override void OnEnteringState<TState>(TState stateBefore)
        {
            // System ansprechen welches Effekte behandeln soll.
        }
    }
}