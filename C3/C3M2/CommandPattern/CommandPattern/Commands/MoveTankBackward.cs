using CommandPattern.interfaces;
using CommandPattern.Models;

namespace CommandPattern.Commands
{
    internal class MoveTankBackward : ICommand
    {
        private readonly Tank _tank;

        public MoveTankBackward(Tank tank)
        {
            this._tank = tank;
        }

        public void Execute()
        {
            _tank.MoveBackward();
        }

        public void Undo()
        {
            _tank.MoveForward();
        }

        public override string ToString()
        {
            return nameof(MoveTankBackward);
        }
    }
}
