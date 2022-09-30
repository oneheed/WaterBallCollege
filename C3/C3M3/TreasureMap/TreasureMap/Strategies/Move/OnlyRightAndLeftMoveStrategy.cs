using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Move
{
    internal class OnlyRightAndLeftMoveStrategy : MoveStrategy
    {
        public OnlyRightAndLeftMoveStrategy(Role mover) : base(mover)
        {
        }

        public override void Move(Direction direction)
        {
            var map = this._mover.Map;

            (int Start, int End) bound;

            var toIndex = -1;
            var boundData = map.GetBoundIndex(this._mover);

            if (direction == Direction.Up || direction == Direction.Down)
            {
                throw new ArgumentException("Only Right And Left Move");
            }

            var offest = direction == Direction.Left ? -1 : 1;
            toIndex = map.GetMapIndexByOffset(this._mover, (offest, 0));

            bound = (boundData.LeftBoundIndex, boundData.RightBoundIndex);


            if (toIndex < 0 || toIndex < bound.Start || toIndex > bound.End)
            {
                throw new ArgumentOutOfRangeException("Out Of Map Range");
            }

            map.MoveMapObjectByIndex(this._mover, toIndex);
        }
    }
}
