

using System.Runtime.InteropServices;

namespace Chess.Core
{
    public class Move
    {
        public Position From { get; private set; }
        public Position To { get; private set; }

        public Move(Position from, Position to)
        {
            From = from;
            To = to;
        }
    }
}
