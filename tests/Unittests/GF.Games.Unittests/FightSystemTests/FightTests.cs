using System;
using GF.Games.Unittests.EffectSystemTests.ExampleEffectSystem;
using GF.Games.Unittests.FightSystemTests.FightsystemPrototype;
using NUnit.Framework;

namespace GF.Games.Unittests.FightSystemTests
{
    [TestFixture]
    public class FightTests
    {
        [Test]
        public void Fight_DidNotStartStart_PlayerIsNotOnTurn()
        {
            // Arrange
            var fight = CreateFight();

            // Assert
            Assert.That(fight.IsPlayerOnTurn, Is.EqualTo(false));
        }

        [Test]
        public void Fight_PlayerTakesTurn_EnemyIsOnTurnNext()
        {
            // Arrange
            var fight = CreateFight();
            fight.Start();

            // Act
            fight.EndTurn();

            // Assert
            Assert.That(fight.EnemyIsOnTurn, Is.EqualTo(true));
        }

        [Test]
        public void Fight_Start_PlayerTakesFirstTurn()
        {
            // Arrange
            var fight = CreateFight();

            // Act
            fight.Start();

            // Assert
            Assert.That(fight.IsPlayerOnTurn, Is.EqualTo(true));
        }

        [Test]
        public void Fight_Start_StartsOnRoundOne()
        {
            // Arrange
            var fight = CreateFight();

            // Act
            fight.Start();

            // Assert
            Assert.That(fight.CurrentTurn, Is.EqualTo(1));
        }

        [Test]
        public void Fight_AfterBothEndedTurn_TurnTwoStarts()
        {
            // Arrange
            var fight = CreateFight();
            fight.Start();

            // Act
            fight.EndTurn();
            fight.EndTurn();

            // Assert
            Assert.That(fight.CurrentTurn, Is.EqualTo(2));
        }

        
        [Test]
        public void Fight_DamageAction_DealsDamageToEnemy()
        {
            // Arrange
            var fight = CreateFight();
            fight.Start();

            // Act
            fight.HandleAction(new DamageAction(3, fight.Enemy ));
            fight.EndTurn();

            // Assert
            Assert.Fail();
        }

        private static Fight CreateFight()
        {
            return new Fight(new Player(), new Enemy());
        }
    }
}