namespace GF.Games.EffectSystem
{
    public abstract class EffectBase : IEffect
    {
        protected EffectBase() : this(0)
        {
        }

        protected EffectBase(int initialAmount)
        {
            this.CurrentStack = initialAmount;
        }

        public int CurrentStack { get; private set; }
        public void IncreaseStack(int amount)
        {
            this.CurrentStack += amount;
        }

        public void ReduceStack(int amount)
        {
            this.CurrentStack -= amount;
        }
    }
}