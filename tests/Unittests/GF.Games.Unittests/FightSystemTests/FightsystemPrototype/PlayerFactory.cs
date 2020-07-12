using System;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    internal class PlayerFactory

    {
        public Player CreateFrom(FightContext fightContext)
        {
            return new Player(fightContext.GetComponent<HealthComponent>(fightContext.PlayerId));
        }
    }
}