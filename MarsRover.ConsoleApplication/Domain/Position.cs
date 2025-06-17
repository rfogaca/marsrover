namespace MarsRover.Domain
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Cria uma nova posição deslocada em uma direção
        public Position Move(Direction direction)
        {
            return direction switch
            {
                Direction.North => new Position(X, Y + 1),
                Direction.South => new Position(X, Y - 1),
                Direction.East => new Position(X + 1, Y),
                Direction.West => new Position(X - 1, Y),
                _ => this
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is not Position other) return false;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => $"{X} {Y}";
    }
}

