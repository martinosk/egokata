using System.Linq;

namespace GameModel
{
    public interface PlayerBuilder
    {
        PlayerBuilder AddPlayer(Player player);
        QuestionsBuilder WithQuestion(Question question);
        QuestionsBuilder WithDefaultPlayers();
    }
    public interface QuestionsBuilder
    {
        IGameBuilder AddQuestion(Question question);
        IGameBuilder WithDefaultQuestions();
    }
    public interface IGameBuilder
    {
        IGameBuilder AddQuestion(Question question);
        Game StartGame();
    }

    public class GameBuilder : PlayerBuilder, QuestionsBuilder, IGameBuilder
    {
        private readonly Players players = new Players();
        private readonly Questions questions = new Questions();

        public QuestionsBuilder WithDefaultPlayers()
        {
            AddPlayer(new Player("Martin"));
            AddPlayer(new Player("Cris"));
            AddPlayer(new Player("Ida"));
            AddPlayer(new Player("Lisbeth"));
            AddPlayer(new Player("Nadia"));
            AddPlayer(new Player("Snorri"));
            AddPlayer(new Player("Christian"));
            return this;
        }

        public IGameBuilder WithDefaultQuestions()
        {
            questions.AddQuestion(
                new Question("If I was not working in IT, I would be?",
                new MultipleChoiceOptions()
                .AddOption(new MultipleChoiceOption("Lion tamer", 1))
                .AddOption(new MultipleChoiceOption("Carpenter", 2))
                .AddOption(new MultipleChoiceOption("Skiing instructor", 3))
                .AddOption(new MultipleChoiceOption("Designer", 4))
                ));

            questions.AddQuestion(
                new Question("Who of us gets most frustrated when a bug is introduced in production",
                new SelectAPersonOptions(players)));

            return this;
        }

        public PlayerBuilder AddPlayer(Player player)
        {
            players.AddPlayer(player);
            return this;
        }

        public QuestionsBuilder WithQuestion(Question question)
        {
            questions.AddQuestion(question);
            return this;
        }

        public IGameBuilder AddQuestion(Question question)
        {
            questions.AddQuestion(question);
            return this;
        }

        public Game StartGame()
        {
            return new Game(players, questions);
        }
    }

    public class Game
    {
        public Players Players { get; }
        public Questions Questions { get; }
        public int CurrentTurn { get; private set; }
        public Question GetNextQuestion()
        {
            return Questions.GetNextQuestion();
        }

        public bool IsLastRound()
        {
            return Questions.QuestionsLeft == 1;
        }

        public Turn StartTurn()
        {
            CurrentTurn++;
            var question = Questions.GetNextQuestion();
            var player = Players.GetNextPlayer(CurrentTurn);
            return new Turn(player, question);
        }

        public Game(Players players, Questions questions)
        {
            if (players.Participants.Count() < 3)
                throw new TooFewPlayers();
            if (questions.QuestionsLeft < 1)
                throw new NoMoreQuestionsLeftInGame();
            Players = players;
            Questions = questions;
        }
    }
}
