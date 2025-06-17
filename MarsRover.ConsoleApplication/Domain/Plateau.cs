namespace MarsRover.Domain
{
    public class Plateau
    {
        public int MaxX { get; }
        public int MaxY { get; }

        private readonly HashSet<Position> occupiedPositions = new();

        public Plateau(int maxX, int maxY)
        {
            if (maxX < 0 || maxY < 0)
                throw new ArgumentException("Coordenadas máximas devem ser não-negativas.");

            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsWithinBounds(Position position)
        {
            return position.X >= 0 && position.X <= MaxX &&
                   position.Y >= 0 && position.Y <= MaxY;
        }

        public bool IsOccupied(Position position)
        {
            return occupiedPositions.Contains(position);
        }

        public void Occupy(Position position)
        {
            occupiedPositions.Add(position);
        }

        public void Vacate(Position position)
        {
            occupiedPositions.Remove(position);
        }
    }
}