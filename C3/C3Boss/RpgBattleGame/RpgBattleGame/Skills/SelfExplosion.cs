using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class SelfExplosion : Skill
    {
        internal override string Name => "自爆";

        internal override int MP => 200;

        internal override int TargetNumber => -1;

        internal override TroopType TroopType => TroopType.ALL;

        internal override void Effect(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.Damage(caster, 150);
            }

            caster.Suicide();
        }
    }
}
