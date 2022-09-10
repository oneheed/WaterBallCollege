using CommandPattern.interfaces;

namespace CommandPattern.Models
{
    internal class Macro : ICommand
    {
        private readonly ICollection<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void AddCommands(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                AddCommand(command);
            }
        }

        public void ClearCommand()
        {
            _commands.Clear();
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            foreach (var command in _commands)
            {
                command.Undo();
            }
        }

        public override string ToString()
        {
            return string.Join(" & ", _commands.ToList());
        }
    }
}
