using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class Fireball : Skill
    {
        internal override string Name => "火球";

        internal override int MP => 50;

        // 所有敵軍
        internal override int TargetNumber => int.MaxValue;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.Damage(caster, 50);
            }
        }
    }
}
