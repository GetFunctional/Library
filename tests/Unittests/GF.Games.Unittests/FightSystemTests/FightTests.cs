using GF.Games.Unittests.FightSystemTests.FightsystemPrototype;
using NUnit.Framework;

namespace GF.Games.Unittests.FightSystemTests
{
    [TestFixture]
    public class FightTests
    {
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
    }
}