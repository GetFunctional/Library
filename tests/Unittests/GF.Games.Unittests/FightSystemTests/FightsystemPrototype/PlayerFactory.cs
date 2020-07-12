using System;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    internal class PlayerFactory

    {
        public Player CreateFrom(FightData fightData)
        {
            return new Player(fightData.GetComponent<HealthComponent>(fightData.PlayerId));
        }
    }
}