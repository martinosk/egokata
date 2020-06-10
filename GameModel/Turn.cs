namespace GameModel
{
    public class Turn
    {
        public Player ActivePlayer { get; }
        public Question CurrentQuestion { get; }
        public Answer AnswerQuestion(Option answer)
        {
            return new Answer(ActivePlayer, answer);
        }
        public Turn(Player activePlayer, Question currentQuestion)
        {
            ActivePlayer = activePlayer;
            CurrentQuestion = currentQuestion;
        }
    }
}