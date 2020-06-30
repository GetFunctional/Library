namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Fight
    {
        private readonly TurnStateMachine _turnStateMachine;

        public Fight() : this(new TurnStateMachine(new WaitingForFightStart()))
        {
        }

        public Fight(TurnStateMachine turnStateMachine)
        {
            _turnStateMachine = turnStateMachine;
        }

        public int CurrentTurn => _turnStateMachine.CurrentTurn;

        public bool IsPlayerOnTurn => _turnStateMachine.CurrentState is PlayerTurn;

        public bool EnemyIsOnTurn => _turnStateMachine.CurrentState is EnemyTurn;

        public void Start()
        {
            _turnStateMachine.Start();
        }

        public void EndTurn()
        {
            _turnStateMachine.EndTurn();
        }
    }
}