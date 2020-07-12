using System.Threading;
using System.Threading.Tasks;
using GF.Games.EntityComponentSystem;
using MediatR;

namespace GF.Games.Unittests.FightSystemTests.FightsystemPrototype
{
    public class Fight
    {
        private readonly EnemyFactory _enemyFactory = new EnemyFactory();
        private readonly FightContext _fightContext;
        private readonly PlayerFactory _playerFactory = new PlayerFactory();
        private readonly TurnStateMachine _turnStateMachine;

        private Fight(FightContext fightContext, TurnStateMachine turnStateMachine)
        {
            _fightContext = fightContext;
            _turnStateMachine = turnStateMachine;
        }

        public Fight(FightContext fightContext) : this(fightContext, new TurnStateMachine(new WaitingForFightStart()))
        {
        }

        public int CurrentTurn => _turnStateMachine.CurrentTurn;

        public bool IsPlayerOnTurn => _turnStateMachine.CurrentState is PlayerTurn;

        public bool EnemyIsOnTurn => _turnStateMachine.CurrentState is EnemyTurn;

        public Player GetImmutablePlayerInfo()
        {
            return _playerFactory.CreateFrom(_fightContext);
        }

        public Enemy GetImmutableEnemyInfo()
        {
            return _enemyFactory.CreateFrom(_fightContext);
        }

        public void Start()
        {
            _turnStateMachine.Start();
        }

        public void EndTurn()
        {
            _turnStateMachine.EndTurn();
        }

        public Task PlayCard(Card card, Enemy target)
        {
            return _fightContext.Send(new PlayCardCommand(card, target));
        }
    }

    public class AfterPlayingCardEvent : INotification
    {
        public Card Card { get; }
        public Enemy Target { get; }

        public AfterPlayingCardEvent(Card card, Enemy target)
        {
            this.Card = card;
            this.Target = target;
        }
    }

    public class PlayingCardEvent : INotification
    {
        public Card Card { get; }
        public Enemy Target { get; }

        public PlayingCardEvent(Card card, Enemy target)
        {
            this.Card = card;
            this.Target = target;
        }
    }

    public class BeforePlayingCardEvent : INotification
    {
        public Card Card { get; }
        public Enemy Target { get; }

        public BeforePlayingCardEvent(Card card, Enemy target)
        {
            this.Card = card;
            this.Target = target;
        }
    }

    public class PlayCardCommand : IRequest
    {
        public Card Card { get; }
        public Enemy Target { get; }

        public PlayCardCommand(Card card, Enemy target)
        {
            this.Card = card;
            this.Target = target;
        }
    }
}