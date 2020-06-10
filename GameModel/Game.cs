namespace GameModel
{
    public class Game
    {
        

        public Players Players { get; }
        public Questions Questions { get; }

        public Question GetNextQuestion()
        {
            return Questions.GetNextQuestion();
        }
    }
}
