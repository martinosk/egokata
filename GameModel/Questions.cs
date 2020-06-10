using System.Collections.Generic;

namespace GameModel
{
    public class Questions
    {
        private readonly Stack<Question> RemainingQuestions = new Stack<Question>();

        public int QuestionsLeft => RemainingQuestions.Count;

        public void AddQuestion(Question question)
        {
            RemainingQuestions.Push(question);
        }

        public Question GetNextQuestion()
        {
            if (QuestionsLeft == 0)
                throw new NoMoreQuestionsLeftInGame();

            return RemainingQuestions.Pop();
        }
    }
}