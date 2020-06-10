using System.Collections.Generic;

namespace GameModel
{
    public class Players
    {
        private readonly List<Player> participants;

        public IEnumerable<Player> Participants => participants; 
        
        public void AddPlayer(Player player)
        {
            if(participants.Contains(player))
                return;
            participants.Add(player);
        }
    }
}