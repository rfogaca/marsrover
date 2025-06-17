using System;
using System.Collections.Generic;

namespace MarsRover.Commands
{
    public static class CommandFactory
    {
        public static List<ICommand> CreateCommandSequence(string commandString)
        {
            var commands = new List<ICommand>();

            foreach (char c in commandString)
            {
                commands.Add(CreateCommand(c));
            }

            return commands;
        }

        public static ICommand CreateCommand(char commandChar)
        {
            return commandChar switch
            {
                'L' => new RotateLeftCommand(),
                'R' => new RotateRightCommand(),
                'M' => new MoveCommand(),
                _ => throw new ArgumentException($"Comando inválido: {commandChar}")
            };
        }
    }
}