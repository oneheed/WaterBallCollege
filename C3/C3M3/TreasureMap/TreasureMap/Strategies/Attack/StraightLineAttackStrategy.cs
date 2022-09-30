using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Attack
{
    internal class StraightLineAttackStrategy : AttackStrategy
    {
        public StraightLineAttackStrategy(Role attacker) : base(attacker)
        {
        }

        public override void Attack()
        {
            var map = _attacker.Map;
            var fromIndex = _attacker.GetMapIndex();
            var direction = Direction.Left;
            var offest = -1;
            var test = new[] { Direction.Left, Direction.Right };

            if (test.Contains(direction))
            {
                // X
                var startIndex = (fromIndex % map.Width);
                var endIndex = offest > 0 ? (map.Width - 1) : 0;
                var length = Math.Abs(startIndex - endIndex);


                Console.WriteLine($"{startIndex} {endIndex} {length}");
            }
            else
            {
                // Y
                var startIndex = (fromIndex / map.Width);
                var endIndex = offest > 0 ? (map.Height - 1) : 0;
                var length = Math.Abs(startIndex - endIndex);

                Console.WriteLine($"{startIndex} {endIndex} {length}");
            }
        }
    }
}
