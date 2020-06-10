using System.Collections.Generic;
using System.Linq;

namespace GameModel
{
    public class Guesses
    {
        private List<Answer> guesses = new List<Answer>();

        internal void AddGuess(Answer answer)
        {
            if(guesses.Any(f=> f.AnsweringPlayer == answer.AnsweringPlayer))
            {
                throw new PlayerAlreadyAnswered();
            }
            guesses.Add(answer);
        }

        public void ScoreAnswers(Answer correctAnswer)
        {
            foreach(var guess in guesses)
            {
                correctAnswer.EvaluateGuess(guess);
            }
        }
    }
}