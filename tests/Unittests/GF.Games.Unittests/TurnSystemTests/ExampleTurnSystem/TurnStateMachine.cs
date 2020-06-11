using System;
using GF.Games.TurnSystem;

namespace GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem
{
    public class TurnStateMachine : StateMachineBase, ITurnStateMachine
    {
        public TurnStateMachine(IStateMachineState initialState) : base(initialState)
        {
        }

        protected override bool IsAllowedTransition<TState>(IStateMachineState currentState, TState newState)
        {
            if (currentState is WaitingForTurnState wft)
            {
                return newState is RestoringResourcesState;
            }

            if (currentState is RestoringResourcesState rrs)
            {
                return newState is PlayingCardsPhase;
            }

            if (currentState is PlayingCardsPhase pcp)
            {
                return newState is ResolvingBattleState;
            }

            if (currentState is ResolvingBattleState rbs)
            {
                return newState is WaitingForTurnState;
            }

            throw new NotImplementedException();
        }
    }
}