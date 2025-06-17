using MarsRover.Domain;

namespace MarsRover.Commands
{
    public interface ICommand
    {
        void Execute(Rover rover);
    }
}