using System.Collections.Generic;

namespace GameModel
{
    public class Player
    {
        public string Name { get; }
        public int Score { get; private set; }


        public void AwardPoints(int increment)
        {
            Score += increment;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public Player(string name)
        {
            Name = name;
        }

        public static bool operator ==(Player left, Player right)
        {
            return EqualityComparer<Player>.Default.Equals(left, right);
        }

        public static bool operator !=(Player left, Player right)
        {
            return !(left == right);
        }
    }
}