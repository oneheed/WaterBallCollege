using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class WaterBall : Skill
    {
        internal override string Name => "水球";

        internal override int MP => 50;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Effect(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.Damage(caster, 120);
            }
        }
    }
}
