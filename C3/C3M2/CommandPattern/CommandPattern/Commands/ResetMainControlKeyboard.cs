using CommandPattern.interfaces;

namespace CommandPattern.Commands
{
    internal class ResetMainControlKeyboard : ICommand
    {
        private readonly MainController _mainControl;

        public ResetMainControlKeyboard(MainController mainControl)
        {
            this._mainControl = mainControl;
        }

        public void Execute()
        {
            _mainControl._keyboard.Reset();
        }

        public void Undo()
        {
            _mainControl._keyboard.Undo();
        }

        public override string ToString()
        {
            return nameof(ResetMainControlKeyboard);
        }
    }
}
