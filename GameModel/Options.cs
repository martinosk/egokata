using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameModel
{
    public abstract class Options : IEnumerable<Option>
    {
        protected readonly List<Option> options = new List<Option>();

        public IEnumerator<Option> GetEnumerator()
        {
            return options.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return options.GetEnumerator();
        }

        public Option FromId(int selection)
        {
            var option = options.Where(f => f.Id == selection).SingleOrDefault();
            if (option is null)
                throw new NotAValidOption();
            return option;
        }
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
            options.AddRange(players.Participants.Select(player => new PersonOption(player, players.Participants.IndexOf(player))));
        }
    }
    public abstract class Option
    {
        public int Id { get; }
        public Option(int id)
        {
            this.Id = id;
        }
    }

    public class PersonOption : Option
    {
        public Player Player { get; }

        public PersonOption(Player player, int id) : base(id)
        {
            Player = player;
        }

        public override string ToString()
        {
            return $"{Id}: {Player.Name.ToString()}";
        }
    }

    public class MultipleChoiceOption : Option
    {
        public string Text { get; }
        public MultipleChoiceOption(string text, int id) : base(id)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{Id}: {Text}";
        }

    }
}