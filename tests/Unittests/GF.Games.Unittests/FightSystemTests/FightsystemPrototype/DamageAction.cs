using GF.Games.EntityComponentSystem;

namespace GF.Games.Unittests.FightSystemTests
{
    public class DamageAction
    {
        public int Damage { get; }
        public IEntity Target { get; }

        public DamageAction(int damage, IEntity target)
        {
            this.Damage = damage;
            this.Target = target;
        }
    }
}