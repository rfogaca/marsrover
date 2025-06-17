using MarsRover.Commands;
using MarsRover.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class CommandTests
    {
        [Test]
        public void MoveCommand_deve_avancar_posicao()
        {
            var rover = new Rover(new Position(0, 0), Direction.North);
            var command = new MoveCommand();
            command.Execute(rover);
            Assert.AreEqual(1, rover.Position.Y);
        }

        [Test]
        public void RotateLeftCommand_deve_girar_esquerda()
        {
            var rover = new Rover(new Position(0, 0), Direction.North);
            var command = new RotateLeftCommand();
            command.Execute(rover);
            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [Test]
        public void RotateRightCommand_deve_girar_direita()
        {
            var rover = new Rover(new Position(0, 0), Direction.North);
            var command = new RotateRightCommand();
            command.Execute(rover);
            Assert.AreEqual(Direction.East, rover.Direction);
        }
    }
}
