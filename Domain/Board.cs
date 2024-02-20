using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Gomoku.Domain
{
    public class Board(int size)
    {
        private readonly Guid _id = Guid.NewGuid();
        private readonly Piece?[,] _intersections = new Piece?[size, size];

        private Color currentActionColor = Color.Black;

        public event Action<Board, Piece, Positon>? MadeMove;

        public void MakingMove(Piece piece, Positon positon)
        {
            if (piece.Color != currentActionColor) throw new ArgumentException("Non-current color action.");
            if (positon.X < 0 || positon.Y < 0 || positon.X >= size || positon.Y >= size) throw new ArgumentException("Wrong position.");

            var oldPrice = _intersections[positon.X, positon.Y];
            if (oldPrice is not null) throw new ArgumentException("The position has been placed with a piece.");

            _intersections[positon.X, positon.Y] = piece;
            currentActionColor = currentActionColor == Color.Write ? Color.Black : Color.Write;
            MadeMove?.Invoke(this, piece, positon);
        }
    }
}
