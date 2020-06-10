using System;
using System.Runtime.Serialization;

namespace GameModel
{
    [Serializable]
    internal class TooFewPlayers : Exception
    {
        public TooFewPlayers()
        {
        }

        public TooFewPlayers(string message) : base(message)
        {
        }

        public TooFewPlayers(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooFewPlayers(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}