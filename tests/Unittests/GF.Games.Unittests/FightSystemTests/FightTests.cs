using System.Threading.Tasks;
using GF.Games.Unittests.FightSystemTests.FightsystemPrototype;
using NUnit.Framework;

namespace GF.Games.Unittests.FightSystemTests
{
    [TestFixture]
    public class FightTests
    {
        private static Fight CreateFight()
        {
            return new Fight(new FightContext());
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
        public void Fight_DidNotStartStart_PlayerIsNotOnTurn()
        {
            // Arrange
            var fight = CreateFight();

            // Assert
            Assert.That(fight.IsPlayerOnTurn, Is.EqualTo(false));
        }


        [Test]
        public async Task Fight_PlayCardWithDamageAction_DealsDamageToEnemy()
        {
            // Arrange
            var fight = CreateFight();
            fight.Start();
            var enemy = fight.GetImmutableEnemyInfo();
            var startHealth = enemy.Health.HealthValue;

            // Act
            var cardWithDamageAction = new Card("CardWithDamage", new DamageEffect(6));
            await fight.PlayCard(cardWithDamageAction, enemy);
            fight.EndTurn();


            // Assert
            var enemyAfterTurn = fight.GetImmutableEnemyInfo();
            Assert.That(enemyAfterTurn.Health.HealthValue, Is.EqualTo(startHealth - 6));
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
    }
}