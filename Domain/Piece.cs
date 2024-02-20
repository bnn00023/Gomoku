namespace Gomoku.Domain
{
    public record Piece
    {

        public Piece(Color color)
        {
            Color = color;
        }

        public Color Color { get; }
    }
}
