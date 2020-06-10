using System.Collections.Generic;
using System.Linq;

namespace GameModel
{
    public class Answers
    {
        private List<Answer> answers;
        internal void AddAnswer(Answer answer)
        {
            if(answers.Any(f=> f.AnsweringPlayer == answer.AnsweringPlayer))
            {
                throw new PlayerAlreadyAnswered();
            }
            answers.Add(answer);
        }
    }
}