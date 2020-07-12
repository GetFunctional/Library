namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    internal class EnemyFactory
    {
        public Enemy CreateFrom(FightContext fightContext)
        {
            return new Enemy(fightContext.GetComponent<HealthComponent>(fightContext.EnemyId), fightContext.EnemyId);
        }
    }
}