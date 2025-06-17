using MarsRover.Commands;
using MarsRover.Domain;
using MarsRover.Services;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Missão: Explorando Marte ===\n");

            // Entrada estática para facilitar testes
            var input = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var plateauSize = input[0].Split(' ');
            int maxX = int.Parse(plateauSize[0]);
            int maxY = int.Parse(plateauSize[1]);

            var plateau = new Plateau(maxX, maxY);
            var missionControl = new MissionControl(plateau);

            for (int i = 1; i < input.Count; i += 2)
            {
                var initialData = input[i].Split(' ');
                var x = int.Parse(initialData[0]);
                var y = int.Parse(initialData[1]);
                var direction = ParseDirection(initialData[2]);

                var commandString = input[i + 1];
                var commands = CommandFactory.CreateCommandSequence(commandString);

                missionControl.DeployRover(new Position(x, y), direction, commands);
            }

            Console.WriteLine("\n=== Missão Finalizada ===");
        }

        static Direction ParseDirection(string input)
        {
            return input switch
            {
                "N" => Direction.North,
                "S" => Direction.South,
                "E" => Direction.East,
                "W" => Direction.West,
                _ => throw new ArgumentException("Direção inválida")
            };
        }
    }
}
