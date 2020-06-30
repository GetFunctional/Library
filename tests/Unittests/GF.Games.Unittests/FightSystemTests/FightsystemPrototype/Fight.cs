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

        public void Start()
        {
            _turnStateMachine.Start();
        }
    }
}