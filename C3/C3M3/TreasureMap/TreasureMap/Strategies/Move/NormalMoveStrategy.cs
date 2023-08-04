using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Move
{
    internal class NormalMoveStrategy : MoveStrategy
    {
        public NormalMoveStrategy(Role attacker) : base(attacker)
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
                var offset = direction == Direction.Up ? -1 : 1;
                toIndex = map.GetMapIndexByOffset(this._mover, (0, offset));

                bound = (boundData.UpBoundIndex, boundData.DownBoundIndex);
            }
            else
            {
                var offset = direction == Direction.Left ? -1 : 1;
                toIndex = map.GetMapIndexByOffset(this._mover, (offset, 0));

                bound = (boundData.LeftBoundIndex, boundData.RightBoundIndex);
            }

            if (toIndex < 0 || toIndex < bound.Start || toIndex > bound.End)
            {
                throw new ArgumentOutOfRangeException("Out Of Map Range");
            }

            map.MoveMapObjectByIndex(this._mover, toIndex);
        }
    }
}
