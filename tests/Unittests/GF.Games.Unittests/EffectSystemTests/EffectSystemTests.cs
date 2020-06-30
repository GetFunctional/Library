using System;
using System.Collections.Generic;
using GF.Games.EffectSystem;
using GF.Games.Unittests.EffectSystemTests.ExampleEffectSystem;
using NUnit.Framework;

namespace GF.Games.Unittests.EffectSystemTests
{
    [TestFixture]
    public class EffectSystemTests
    {
        private static EffectStackBag CreateEffectStackBag()
        {
            return new EffectStackBag();
        }

        [Test]
        public void TwoPlayer_GivenEffectBagWithEffects_DoNotHaveEffects()
        {
            // Arrange
            var player1 = new Player(CreateEffectStackBag());
            var player2 = new Player(CreateEffectStackBag());

            // Act & Assert
            Assert.That(player1.HasEffect<BleedEffect>(), Is.EqualTo(false));
            Assert.That(player2.HasEffect<RegenerationEffect>(), Is.EqualTo(false));
        }

        [Test]
        public void Player_ApplyingEffect_HasEffect()
        {
            // Arrange
            var player1 = new Player(CreateEffectStackBag());

            // Act
            player1.ApplyEffect<BleedEffect>(3);

            // Assert
            Assert.That(player1.HasEffect<BleedEffect>(), Is.EqualTo(true));
        }

        [Test]
        public void Player_ApplyingEffectAndReductinAfter_PlayerHasEffectNoMore()
        {
            // Arrange
            var player1 = new Player(CreateEffectStackBag());

            // Act
            player1.ApplyEffect<BleedEffect>(3);
            player1.ApplyEffect<BleedEffect>(-3);

            // Assert
            Assert.That(player1.HasEffect<BleedEffect>(), Is.EqualTo(false));
        }
    }
}