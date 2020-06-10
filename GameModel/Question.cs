using System.Globalization;

namespace GameModel
{
    public class QuestionBuilder
    {
        private string text;
        private Options options;

        public QuestionBuilder WithText(string text)
        {
            this.text = text;
            return this;
        }

        public QuestionBuilder WithOptions(Options options)
        {
            this.options = options;
            return this;
        }


        public Question Build()
        {
            return new Question(text, options);
        }

    }

    public class AnsweredQuestion
    {
        public Guesses Guesses { get; } = new Guesses();
        public string Text { get; }
        public Answer Answer { get; }

        public void Guess(Answer guess)
        {
            Guesses.AddGuess(guess);
        }

        public AnsweredQuestion(Question question, Answer answer)
        {
            Text = question.Text;
            Answer = answer;
        }
    }


    public class Question
    {
        public string Text { get; }
        public Options Options { get; }
        public Question(string text, Options options)
        {
            Text = text;
            Options = options;
        }
        public AnsweredQuestion AnswerQuestion(Answer answer)
        {
            return new AnsweredQuestion(this, answer);
        }
    }

}