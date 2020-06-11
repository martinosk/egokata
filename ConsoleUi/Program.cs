using GameModel;
using System;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sprint Ego!");
            var gameBuilder = new GameBuilder();
            var game = gameBuilder.WithDefaultPlayers().WithDefaultQuestions().StartGame();
            
            while(!game.IsLastRound())
            {
                PlayTurn(game);
            }
            Console.WriteLine("LAST ROUND!");
            PlayTurn(game);

        }

        private static void PlayTurn(Game game)
        {
            var turn = game.StartTurn();
            ShowQuestion(game, turn);
            AnsweredQuestion answer = AnswerQuestion(turn);
            CollectGuesses(game, turn, answer);
            ShowScore(game, turn, answer);
        }

        private static void ShowQuestion(Game game, Turn turn)
        {
            Console.WriteLine($"Starting turn {game.CurrentTurn}");
            Console.WriteLine($"{turn.ActivePlayer.Name}:");
            Console.WriteLine($"{turn.CurrentQuestion.Text}");
            foreach (var option in turn.CurrentQuestion.Options)
            {
                Console.WriteLine(option.ToString());
            }
        }

        private static AnsweredQuestion AnswerQuestion(Turn turn)
        {
            Console.WriteLine($"{turn.ActivePlayer} please select your answer...");
            var selection = int.Parse(Console.ReadLine());
            var answer = turn.AnswerQuestion(turn.CurrentQuestion.Options.FromId(selection));
            return answer;
        }

        private static void CollectGuesses(Game game, Turn turn, AnsweredQuestion answer)
        {
            foreach (var player in game.Players.Participants)
            {
                if (player == turn.ActivePlayer)
                    continue;
                Console.WriteLine($"{player} please enter your guess...");
                var guess = int.Parse(Console.ReadLine());
                turn.CollectGuess(answer, new Answer(player, turn.CurrentQuestion.Options.FromId(guess)));
            }
        }

        private static void ShowScore(Game game, Turn turn, AnsweredQuestion answer)
        {
            turn.ScoreQuestion(answer, game.Players);
            Console.WriteLine("Score is now:");
            foreach (var player in game.Players.Participants)
            {
                Console.WriteLine($"{player}: {player.Score}");
            }
        }
    }
}
