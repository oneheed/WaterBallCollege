using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Move
{
    internal class RandomMoveStrategy : MoveStrategy
    {
        public RandomMoveStrategy(Role mover) : base(mover)
        {
        }

        public override void Move(Direction direction)
        {
            var map = this._mover.Map;
            var random = new Random();
            var success = false;
            var toIndex = -1;

            while (!success || toIndex == -1)
            {
                toIndex = random.Next(map.Size);

                success = map.GetMapObjectByIndex(toIndex) == MapObject.Default;
            }

            map.MoveMapObjectByIndex(this._mover, toIndex);
        }
    }
}
