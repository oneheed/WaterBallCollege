using CommandPattern.interfaces;
using CommandPattern.Models;

namespace CommandPattern
{
    internal class MainController
    {
        public Keyboard _keyboard { get; } = new();

        private IEnumerable<ICommand> _commands = new List<ICommand>();

        private readonly Stack<ICommand> _undoCommands = new();

        private readonly Stack<ICommand> _redoCommands = new();


        public void SetCommands(IEnumerable<ICommand> commands)
        {
            this._commands = commands;
        }


        public void Action()
        {
            ShowBind();

            Console.Write($"(1) 快捷鍵設置 (2) Undo (3) Redo (字母) 按下按鍵: ");
            var consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.D1:
                    SettingHotkey();
                    break;
                case ConsoleKey.D2:
                    Undo();
                    break;
                case ConsoleKey.D3:
                    Redo();
                    break;
                default:
                    var command = this._keyboard.Click(consoleKeyInfo.Key);
                    _undoCommands.Push(command);
                    _redoCommands.Clear();
                    break;
            }
        }

        private void ShowBind()
        {
            var binds = this._keyboard.GetBind().Select(b => $"{b.Key.ToString().ToLower()}: {b.Value}");
            Console.WriteLine(string.Join(Environment.NewLine, binds));
        }

        private void SettingHotkey()
        {
            Console.Write($"設置巨集指令 (y/n)：");
            var macroKeyInfo = Console.ReadKey();
            Console.WriteLine();

            if (macroKeyInfo.Key == ConsoleKey.Y)
            {
                SettingMacro();
            }
            else if (macroKeyInfo.Key == ConsoleKey.N)
            {
                Console.Write($"Key: ");
                var consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();

                Console.WriteLine($"要將哪一道指令設置到快捷鍵 {consoleKeyInfo.KeyChar} 上:");
                Console.WriteLine(string.Join(Environment.NewLine, _commands.Select((c, i) => $"({i}) {c}")));
                var commandKeyInfo = Console.ReadKey();
                Console.WriteLine();
                var command = _commands.Where((c, i) => i.ToString() == commandKeyInfo.KeyChar.ToString()).SingleOrDefault();
                this._keyboard.Bind(consoleKeyInfo.Key, command);
            }
        }

        private void SettingMacro()
        {
            Console.Write($"Key: ");
            var consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine($"要將哪些指令設置成快捷鍵 a 的巨集（輸入多個數字，以空白隔開）:");
            Console.WriteLine(string.Join(Environment.NewLine, _commands.Select((c, i) => $"({i}) {c}")));
            var readLine = Console.ReadLine();
            var indexs = readLine.Split(" ");
            var commands = _commands.Where((c, i) => indexs.Contains(i.ToString()));

            var macro = new Macro();
            macro.AddCommands(commands);

            this._keyboard.Bind(consoleKeyInfo.Key, macro);
        }

        private void Undo()
        {
            if (_undoCommands.Any() && _undoCommands.TryPop(out ICommand command))
            {
                command.Undo();
                _redoCommands.Push(command);
            }
        }

        private void Redo()
        {
            if (_redoCommands.Any() && _redoCommands.TryPop(out ICommand command))
            {
                command.Execute();
                _undoCommands.Push(command);
            }
        }
    }
}
