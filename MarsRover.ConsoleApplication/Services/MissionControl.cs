using MarsRover.Commands;
using MarsRover.Domain;

namespace MarsRover.Services
{
    public class MissionControl
    {
        private readonly Plateau plateau;
        private readonly List<Rover> rovers = new();

        public MissionControl(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public void DeployRover(Position initialPosition, Direction direction, List<ICommand> commands)
        {
            if (!plateau.IsWithinBounds(initialPosition))
            {
                Console.WriteLine($"ERRO: Posição fora do limite do planalto: {initialPosition}");
                return;
            }

            if (plateau.IsOccupied(initialPosition))
            {
                Console.WriteLine($"ERRO: Já existe uma sonda na posição: {initialPosition}");
                return;
            }

            var rover = new Rover(initialPosition, direction);

            foreach (var command in commands)
            {
                var nextPosition = SimulateMove(rover, command);

                if (command is MoveCommand)
                {
                    if (!plateau.IsWithinBounds(nextPosition))
                    {
                        Console.WriteLine($"Aviso: Movimento ignorado (fora dos limites): {nextPosition}");
                        continue;
                    }

                    if (plateau.IsOccupied(nextPosition))
                    {
                        Console.WriteLine($"Aviso: Movimento ignorado (colisão em): {nextPosition}");
                        continue;
                    }

                    plateau.Vacate(rover.Position);
                    command.Execute(rover);
                    plateau.Occupy(rover.Position);
                }
                else
                {
                    command.Execute(rover);
                }
            }

            plateau.Occupy(rover.Position);
            rovers.Add(rover);

            Console.WriteLine(rover); // Imprime posição final
        }

        private Position SimulateMove(Rover rover, ICommand command)
        {
            if (command is MoveCommand)
                return rover.Position.Move(rover.Direction);

            return rover.Position;
        }
    }
}