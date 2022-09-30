using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Move
{
    internal abstract class MoveStrategy
    {
        protected Role _mover;

        protected MoveStrategy(Role mover)
        {
            this._mover = mover;
        }

        public abstract void Move(Direction direction);
    }
}
