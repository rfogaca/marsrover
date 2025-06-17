using MarsRover.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Test]
        public void Deve_mover_para_frente_ao_norte()
        {
            var rover = new Rover(new Position(1, 2), Direction.North);
            rover.MoveForward();
            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);

        }

        [Test]
        public void Deve_rotacionar_para_esquerda()
        {
            var rover = new Rover(new Position(0, 0), Direction.North);
            rover.RotateLeft();
            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [Test]
        public void Deve_rotacionar_para_direita()
        {
            var rover = new Rover(new Position(0, 0), Direction.West);
            rover.RotateRight();
            Assert.AreEqual(Direction.North, rover.Direction);
        }
    }
}
