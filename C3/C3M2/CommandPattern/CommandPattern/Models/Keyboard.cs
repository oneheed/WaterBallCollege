using CommandPattern.interfaces;

namespace CommandPattern.Models
{
    internal class Keyboard
    {
        private Buttons _buttons = new();

        private Buttons? _undoButtons;

        public bool Bind(ConsoleKey key, ICommand? command)
        {
            return _buttons.Bind(key, command);
        }

        public ICommand Click(ConsoleKey key)
        {
            return _buttons.Click(key);
        }

        public IDictionary<ConsoleKey, ICommand?> GetBind()
        {
            return _buttons.GetBind();
        }

        public void Reset()
        {
            _undoButtons = _buttons;
            _buttons = new Buttons();
        }

        public void Undo()
        {
            if (_undoButtons != null)
            {
                _buttons = _undoButtons;
                _undoButtons = default;
            }
        }
    }
}
