using System;
using System.Collections.Generic;
using GF.Games.TurnSystem;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class TurnStateMachine : StateMachineBase
    {
        private readonly Queue<IStateMachineState> _stateQueue;

        public TurnStateMachine(IStateMachineState initialState) : base(initialState)
        {
            _stateQueue = CreateTurnQueueStates();
        }

        public int CurrentTurn { get; private set; }

        private static Queue<IStateMachineState> CreateTurnQueueStates()
        {
            var turnStateQueue = new Queue<IStateMachineState>();
            turnStateQueue.Enqueue(new PlayerTurn());
            turnStateQueue.Enqueue(new EnemyTurn());
            return turnStateQueue;
        }

        public void EndTurn()
        {
            var nextState = _stateQueue.Dequeue();
            _stateQueue.Enqueue(nextState);
            if (nextState is PlayerTurn)
            {
                this.CurrentTurn += 1;
            }

            this.SwitchState(nextState);
        }

        public void Start()
        {
            if (!(this.CurrentState is WaitingForFightStart))
            {
                throw new InvalidOperationException();
            }

            var nextState = _stateQueue.Dequeue();
            _stateQueue.Enqueue(nextState);
            this.CurrentTurn = 1;
            this.SwitchState(nextState);
        }
    }
}