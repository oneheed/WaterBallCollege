using CommandPattern.interfaces;

namespace CommandPattern.Models
{
    internal class Buttons
    {
        private readonly IDictionary<ConsoleKey, ICommand?> _bindCommands;

        public Buttons()
        {
            // A - Z
            _bindCommands = Enumerable.Range(65, 26).ToDictionary(v => (ConsoleKey)v, _ => default(ICommand));
        }

        public bool Bind(ConsoleKey key, ICommand command)
        {
            if (_bindCommands.ContainsKey(key))
            {
                _bindCommands[key] = command;
                return true;
            }

            return false;
        }

        public IEnumerable<KeyValuePair<ConsoleKey, ICommand>> GetBind()
        {
            return _bindCommands.Where(c => c.Value != null);
        }

        public ICommand Click(ConsoleKey key)
        {
            if (_bindCommands.TryGetValue(key, out ICommand? command) && command != null)
            {
                command.Execute();

                return command;
            }

            throw new Exception();
        }
    }
}