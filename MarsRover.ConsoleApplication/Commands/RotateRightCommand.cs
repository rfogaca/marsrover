using MarsRover.Domain;

namespace MarsRover.Commands
{
    public class RotateRightCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.RotateRight();
        }
    }
}