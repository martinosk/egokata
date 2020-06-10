using System.Collections.Generic;

namespace GameModel
{
    public class Question
    {
        public Answers Answers { get; } = new Answers();
        public string Text { get; private set; }
        public Options Options { get; }
        public Question(string text, Options options)
        {
            Text = text;
            Options = options;
        }

        public void Answer(Answer answer)
        {
            Answers.AddAnswer(answer);
        }
    }

    public class Options
    {
        private List<Option> options;
        public void AddOption(Option option)
        {
            options.Add(option);
        }
    }

    public class Option
    {
        public string Text { get; }
        public Option(string text)
        {
            Text = text;
        }
    }
}