using MarsRover.Domain;

namespace MarsRover.Commands
{
    public class RotateLeftCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.RotateLeft();
        }
    }
}