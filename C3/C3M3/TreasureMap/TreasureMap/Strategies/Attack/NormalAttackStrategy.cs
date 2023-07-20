using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Attack
{
    internal class NormalAttackStrategy : AttackStrategy
    {
        public NormalAttackStrategy(Role attacker) : base(attacker)
        {
        }

        public override string Name => "一般攻擊";

        public override void Attack(Direction direction = Direction.None)
        {
            var map = _attacker.Map;
            var fromIndex = _attacker.GetMapIndex();
            var offestDirections = new[] { Direction.Up, Direction.Left };
            var xDirections = new[] { Direction.Left, Direction.Right };
            var offest = offestDirections.Contains(direction) ? -1 : 1;

            if (xDirections.Contains(direction))
            {
                var toIndex = fromIndex + offest;

                if (map.GetMapObjectByIndex(toIndex) is Role role)
                {
                    role.Damage(50);
                }
            }
            else
            {
                var toIndex = fromIndex + offest * map.Width;
                if (map.GetMapObjectByIndex(toIndex) is Role role)
                {
                    role.Damage(50);
                }
            }
        }
    }
}
