using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Strategies.Attack
{
    internal abstract class AttackStrategy
    {
        public abstract string Name { get; }

        protected Role _attacker;

        protected AttackStrategy(Role attacker)
        {
            this._attacker = attacker;
        }

        public abstract void Attack(Direction direction = Direction.None);
    }
}
