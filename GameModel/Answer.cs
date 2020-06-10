namespace GameModel
{
    public class Answer
    {
        public Answer(Player answeringPlayer, Option answer)
        {
            AnsweringPlayer = answeringPlayer;
            AnsweredOption = answer;
        }

        public Player AnsweringPlayer { get; }
        public Option AnsweredOption { get; }
        
        private bool IsCorrect(Answer guess)
        {
            return guess.AnsweredOption == AnsweredOption;
        }

        public void EvaluateGuess(Answer guess)
        {
            if (IsCorrect(guess))
            {
                guess.AnsweringPlayer.AwardPoints(2);
                AnsweringPlayer.AwardPoints(1);
            }
        }
    }
}