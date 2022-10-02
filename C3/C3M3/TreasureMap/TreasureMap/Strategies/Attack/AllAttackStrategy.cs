using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Attack
{
    internal class AllAttackStrategy : AttackStrategy
    {
        public AllAttackStrategy(Role attacker) : base(attacker)
        {
        }

        public override void Attack(Direction direction = Direction.None)
        {
            var map = _attacker.Map;
            var monsters = map.GetMapObjectsByType(typeof(Monster));

            foreach (var mapObject in monsters.ToList())
            {
                if (mapObject is Monster monster)
                {
                    monster.Damage(50);
                }
            }
        }
    }
}
