using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class SelfHealing : Skill
    {
        internal override string Name => "自我治療";

        internal override int MP => 50;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Self;

        internal override void Effect(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.Healing(150);
            }
        }
    }
}
