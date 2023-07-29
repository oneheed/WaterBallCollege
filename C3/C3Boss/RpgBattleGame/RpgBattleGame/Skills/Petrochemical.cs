using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.States;

namespace RpgBattleGame.Skills
{
    internal class Petrochemical : Skill
    {
        internal override string Name => "石化";

        internal override int MP => 100;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Effect(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.ChangeState(new PetrochemicalState(target));
            }
        }
    }
}
