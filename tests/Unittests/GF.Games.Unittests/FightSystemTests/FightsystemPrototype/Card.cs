namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Card
    {
        public string Name { get; }
        public DamageEffect Effect { get; }

        public Card(string name, DamageEffect effect)
        {
            this.Name = name;
            this.Effect = effect;
        }
    }
}