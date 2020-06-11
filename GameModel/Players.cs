using System;
using System.Collections.Generic;

namespace GameModel
{
    public class Players
    {
        private readonly List<Player> participants = new List<Player>();

        public IList<Player> Participants => participants; 
        
        public void AddPlayer(Player player)
        {
            if(participants.Contains(player))
                throw new PlayerAlreadyAddedToGame();
            participants.Add(player);
        }

        public Player GetNextPlayer(int currentTurn)
        {
            return participants[(currentTurn - 1) % participants.Count];
        }
    }
}