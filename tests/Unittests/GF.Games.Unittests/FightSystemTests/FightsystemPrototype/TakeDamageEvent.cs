using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class TakeDamageEvent : INotification
    {
        public int Damage { get; }
        public Enemy Target { get; }

        public TakeDamageEvent(int damage, Enemy target)
        {
            this.Damage = damage;
            this.Target = target;
        }
    }
}