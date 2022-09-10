using CommandPattern.interfaces;
using CommandPattern.Models;

namespace CommandPattern.Commands
{
    internal class MoveTankForward : ICommand
    {
        private readonly Tank _tank;

        public MoveTankForward(Tank tank)
        {
            this._tank = tank;
        }

        public void Execute()
        {
            _tank.MoveForward();
        }

        public void Undo()
        {
            _tank.MoveBackward();
        }

        public override string ToString()
        {
            return nameof(MoveTankForward);
        }
    }
}
