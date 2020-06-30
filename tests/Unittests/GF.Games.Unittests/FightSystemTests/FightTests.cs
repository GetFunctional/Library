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
            var fight = new Fight();

            // Assert
            Assert.That(fight.IsPlayerOnTurn, Is.EqualTo(false));
        }

        [Test]
        public void Fight_PlayerTakesTurn_EnemyIsOnTurnNext()
        {
            // Arrange
            var fight = new Fight();
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
            var fight = new Fight();

            // Act
            fight.Start();

            // Assert
            Assert.That(fight.IsPlayerOnTurn, Is.EqualTo(true));
        }

        [Test]
        public void Fight_Start_StartsOnRoundOne()
        {
            // Arrange
            var fight = new Fight();

            // Act
            fight.Start();

            // Assert
            Assert.That(fight.CurrentTurn, Is.EqualTo(1));
        }

        [Test]
        public void Fight_AfterBothEndedTurn_TurnTwoStarts()
        {
            // Arrange
            var fight = new Fight();
            fight.Start();

            // Act
            fight.EndTurn();
            fight.EndTurn();

            // Assert
            Assert.That(fight.CurrentTurn, Is.EqualTo(2));
        }
    }
}