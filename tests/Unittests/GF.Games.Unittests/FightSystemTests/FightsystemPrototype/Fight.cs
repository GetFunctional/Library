namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Fight
    {
        private readonly EnemyFactory _enemyFactory = new EnemyFactory();
        private readonly FightData _fightData;
        private readonly PlayerFactory _playerFactory = new PlayerFactory();
        private readonly TurnStateMachine _turnStateMachine;

        private Fight(FightData fightData, TurnStateMachine turnStateMachine)
        {
            _fightData = fightData;
            _turnStateMachine = turnStateMachine;
        }

        public Fight(FightData fightData) : this(fightData, new TurnStateMachine(new WaitingForFightStart()))
        {
        }

        public int CurrentTurn => _turnStateMachine.CurrentTurn;

        public bool IsPlayerOnTurn => _turnStateMachine.CurrentState is PlayerTurn;

        public bool EnemyIsOnTurn => _turnStateMachine.CurrentState is EnemyTurn;

        public Player GetImmutablePlayerInfo()
        {
            return _playerFactory.CreateFrom(_fightData);
        }

        public Enemy GetImmutableEnemyInfo()
        {
            return _enemyFactory.CreateFrom(_fightData);
        }

        public void Start()
        {
            _turnStateMachine.Start();
        }

        public void EndTurn()
        {
            _turnStateMachine.EndTurn();
        }

        public void PlayCard(Card card, Enemy target)
        {
        }
    }
}