﻿namespace GameModel
{
    public class Player
    {
        public string Name { get; }
        public int Score { get; private set; }

        public void AwardPoint()
        {
            Score++;
        }


        public Player(string name)
        {
            Name = name;
        }

    }
}