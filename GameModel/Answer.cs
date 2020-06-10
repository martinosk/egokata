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

    }
}