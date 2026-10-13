

using System.Runtime.InteropServices;

namespace Chess.Core
{
    public class Move
    {
        public Position From { get; private set; }
        public Position To { get; private set; }
        public PromotionPiece? Promotion { get; private set; }
        public Move(Position from, Position to, PromotionPiece? promotion = null)
        {
            From = from;
            To = to;
            Promotion = promotion;
        }
    }
}
