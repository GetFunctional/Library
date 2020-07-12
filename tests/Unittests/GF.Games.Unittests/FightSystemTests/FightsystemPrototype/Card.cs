namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Card
    {
        public Card(string name, DamageEffect effect)
        {
            this.Name = name;
            this.Effect = effect;
        }

        public string Name { get; }
        public DamageEffect Effect { get; }
    }
}