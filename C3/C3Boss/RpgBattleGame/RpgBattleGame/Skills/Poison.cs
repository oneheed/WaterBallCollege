using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.States;

namespace RpgBattleGame.Skills
{
    internal class Poison : Skill
    {
        internal override string Name => "下毒";

        internal override int MP => 80;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.ChangeState(new PoisonedState(target));
            }
        }
    }
}
