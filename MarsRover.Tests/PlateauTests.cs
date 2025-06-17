using MarsRover.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        [Test]
        public void Deve_validar_posicao_dentro_do_planalto()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(3, 4);
            Assert.IsTrue(plateau.IsWithinBounds(position));
        }

        [Test]
        public void Deve_detectar_posicao_fora_do_planalto()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(6, 0);
            Assert.IsFalse(plateau.IsWithinBounds(position));
        }

        [Test]
        public void Deve_detectar_colisao()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(2, 2);
            plateau.Occupy(position);
            Assert.IsTrue(plateau.IsOccupied(position));
        }
    }
}   