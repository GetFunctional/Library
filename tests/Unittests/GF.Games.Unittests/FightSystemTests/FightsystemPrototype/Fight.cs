namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Fight
    {
        private readonly TurnStateMachine _turnStateMachine;

        private Fight(Player player, Enemy enemy, TurnStateMachine turnStateMachine)
        {
            this.Player = player;
            this.Enemy = enemy;
            _turnStateMachine = turnStateMachine;
        }

        public Fight(Player player, Enemy enemy) : this(player, enemy, new TurnStateMachine(new WaitingForFightStart()))
        {
        }

        public Player Player { get; }

        public int CurrentTurn => _turnStateMachine.CurrentTurn;

        public bool IsPlayerOnTurn => _turnStateMachine.CurrentState is PlayerTurn;

        public bool EnemyIsOnTurn => _turnStateMachine.CurrentState is EnemyTurn;
        public Enemy Enemy { get; }

        public void Start()
        {
            _turnStateMachine.Start();
        }

        public void EndTurn()
        {
            _turnStateMachine.EndTurn();
        }

        public void HandleAction(DamageAction damageAction)
        {
        }
    }
}