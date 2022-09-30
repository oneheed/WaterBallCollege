using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Move
{
    internal class OnlyUpAndDownMoveStrategy : MoveStrategy
    {
        public OnlyUpAndDownMoveStrategy(Role mover) : base(mover)
        {
        }

        public override void Move(Direction direction)
        {
            var map = this._mover.Map;

            (int Start, int End) bound;

            var toIndex = -1;
            var boundData = map.GetBoundIndex(this._mover);

            if (direction == Direction.Left || direction == Direction.Right)
            {
                throw new ArgumentException("Only Up And Down Move");
            }

            var offest = direction == Direction.Up ? -1 : 1;
            toIndex = map.GetMapIndexByOffset(this._mover, (0, offest));

            bound = (boundData.UpBoundIndex, boundData.DownBoundIndex);

            if (toIndex < 0 || toIndex < bound.Start || toIndex > bound.End)
            {
                throw new ArgumentOutOfRangeException("bound", "Out Of Map Range");
            }

            map.MoveMapObjectByIndex(this._mover, toIndex);
        }
    }
}
