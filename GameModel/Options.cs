using System.Collections.Generic;
using System.Linq;

namespace GameModel
{
    public abstract class Options
    {
        protected readonly List<Option> options = new List<Option>();
    }

    public class MultipleChoiceOptions : Options
    {
        public MultipleChoiceOptions AddOption(MultipleChoiceOption option)
        {
            options.Add(option);
            return this;
        }
    }

    public class SelectAPersonOptions : Options
    {
        public SelectAPersonOptions(Players players)
        {
            options.AddRange(players.Participants.Select(player => new PersonOption(player)));
        }
    }
    public abstract class Option
    {
    }

    public class PersonOption : Option
    {
        public Player Player { get; }

        public PersonOption(Player player)
        {
            Player = player;
        }
    }

    public class MultipleChoiceOption : Option
    {
        public string Text { get; }
        public MultipleChoiceOption(string text)
        {
            Text = text;
        }

    }
}