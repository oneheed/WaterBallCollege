using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Attack
{
    internal class StraightLineAttackStrategy : AttackStrategy
    {
        public StraightLineAttackStrategy(Role attacker) : base(attacker)
        {
        }

        public override string Name => "直線攻擊";

        public override void Attack(Direction direction = Direction.None)
        {
            var map = _attacker.Map;
            var fromIndex = _attacker.GetMapIndex();
            var offestDirections = new[] { Direction.Up, Direction.Left };
            var xDirections = new[] { Direction.Left, Direction.Right };
            var offest = offestDirections.Contains(direction) ? -1 : 1;

            if (xDirections.Contains(direction))
            {
                // X
                var startIndex = (fromIndex % map.Width);
                var endIndex = offest > 0 ? (map.Width - 1) : 0;
                var length = Math.Abs(startIndex - endIndex);

                var toIndex = fromIndex;
                while (startIndex != endIndex)
                {
                    toIndex += offest;

                    startIndex += offest;

                    if (map.GetMapObjectByIndex(toIndex) is Obstacle)
                    {
                        break;
                    }
                    else if (map.GetMapObjectByIndex(toIndex) is Monster monster)
                    {
                        monster.Death();
                    }
                }
            }
            else
            {
                // Y
                var startIndex = (fromIndex / map.Width);
                var endIndex = offest > 0 ? (map.Height - 1) : 0;
                var length = Math.Abs(startIndex - endIndex);

                var toIndex = fromIndex;
                while (startIndex != endIndex)
                {
                    toIndex += (offest * map.Width);

                    startIndex += offest;

                    if (map.GetMapObjectByIndex(toIndex) is Obstacle)
                    {
                        break;
                    }
                    else if (map.GetMapObjectByIndex(toIndex) is Monster monster)
                    {
                        monster.Death();
                    }
                }
            }
        }
    }
}
