namespace MarsRover.Domain
{
    public class Rover
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public Rover(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public void MoveForward()
        {
            Position = Position.Move(Direction);
        }

        public void RotateLeft()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => Direction
            };
        }

        public void RotateRight()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => Direction
            };
        }

        public override string ToString()
        {
            return $"{Position.X} {Position.Y} {DirectionToChar()}";
        }

        private char DirectionToChar()
        {
            return Direction switch
            {
                Direction.North => 'N',
                Direction.South => 'S',
                Direction.East => 'E',
                Direction.West => 'W',
                _ => '?'
            };
        }
    }
}
