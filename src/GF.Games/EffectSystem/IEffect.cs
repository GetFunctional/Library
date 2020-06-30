namespace GF.Games.EffectSystem
{
    public interface IEffect
    {
        int CurrentStack { get; }

        void IncreaseStack(int amount);

        void ReduceStack(int amount);
    }
}