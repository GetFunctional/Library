using System;
using GF.Games.Unittests.TurnSystemTests.ExampleTurnSystem;
using NUnit.Framework;

namespace GF.Games.Unittests.TurnSystemTests
{
    [TestFixture]
    public class TurnStateMachineTests
    {
        [Test]
        public void StateMachine_SwitchState_AsksForTransitionAllowed()
        {
            // Arrange
            var player1 = new Player(new PlayerActions(), new PlayerResources(3, 0));
            var stateMachine = new TurnStateMachine(new WaitingForTurnState());
            var nextState = new ResolvingBattleState();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stateMachine.SwitchState(nextState));
        }

        [Test]
        public void StateMachine_SwitchState_ExecutesStateEnteringBehavior()
        {
            // Arrange
            var player1 = new Player(new PlayerActions(), new PlayerResources(3, 0));
            var stateMachine = new TurnStateMachine(new WaitingForTurnState());
            var nextState = new RestoringResourcesState(player1.PlayerResources);

            // Act
            stateMachine.SwitchState(nextState);

            // Assert
            Assert.That(stateMachine.CurrentState, Is.EqualTo(nextState));
            Assert.That(player1.PlayerResources.AvailableActions, Is.EqualTo(3));
        }

        [Test]
        public void StateMachine_SwitchState_ExecutesStateLeavingBehavior()
        {
            // Arrange
            var player1 = new Player(new PlayerActions(), new PlayerResources(3, 0));
            var stateMachine = new TurnStateMachine(new WaitingForTurnState());
            var nextState = new RestoringResourcesState(player1.PlayerResources);
            var nextState2 = new PlayingCardsPhase(player1.PlayerActions);
            var nextState3 = new ResolvingBattleState();

            // Act & Assert
            Assert.That(player1.PlayerActions.CanPlayActions, Is.EqualTo(false));
            stateMachine.SwitchState(nextState);
            stateMachine.SwitchState(nextState2);
            Assert.That(player1.PlayerActions.CanPlayActions, Is.EqualTo(true));
            stateMachine.SwitchState(nextState3);
            Assert.That(player1.PlayerActions.CanPlayActions, Is.EqualTo(false));
        }

        [Test]
        public void StateMachine_SwitchState_SwitchesState()
        {
            // Arrange
            var player1 = new Player(new PlayerActions(), new PlayerResources(3, 0));
            var stateMachine = new TurnStateMachine(new WaitingForTurnState());
            var nextState = new RestoringResourcesState(player1.PlayerResources);

            // Act
            stateMachine.SwitchState(nextState);

            // Assert
            Assert.That(stateMachine.CurrentState, Is.EqualTo(nextState));
        }
    }
}