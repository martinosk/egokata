using System;
using System.Runtime.Serialization;

namespace GameModel
{
    [Serializable]
    internal class PlayerAlreadyAddedToGame : Exception
    {
        public PlayerAlreadyAddedToGame()
        {
        }

        public PlayerAlreadyAddedToGame(string message) : base(message)
        {
        }

        public PlayerAlreadyAddedToGame(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerAlreadyAddedToGame(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}