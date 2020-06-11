namespace GameModel
{
    public class Turn
    {
        public Player ActivePlayer { get; }
        public Question CurrentQuestion { get; }
        
        public AnsweredQuestion AnswerQuestion(Option answer)
        {
            return CurrentQuestion.AnswerQuestion(new Answer(ActivePlayer, answer));
        }

        public bool AllHasGuessed(AnsweredQuestion question, Players players)
        {
            return question.AllHasGuessed(players);
        }

        public void ScoreQuestion(AnsweredQuestion question, Players players)
        {
            if (!AllHasGuessed(question, players))
                throw new NotAllPlayersHasGuessed();
            question.Guesses.ScoreAnswers(question.Answer);
        }

        public void CollectGuess(AnsweredQuestion question, Answer guess)
        {
            question.Guess(guess);
        }

        public Turn(Player activePlayer, Question currentQuestion)
        {
            ActivePlayer = activePlayer;
            CurrentQuestion = currentQuestion;
        }
    }
}