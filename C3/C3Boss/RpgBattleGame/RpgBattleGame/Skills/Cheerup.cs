using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.States;

namespace RpgBattleGame.Skills
{
    internal class CheerUp : Skill
    {
        internal override string Name => "鼓舞";

        internal override int MP => 100;

        internal override int TargetNumber => 3;

        internal override TroopType TroopType => TroopType.Ally;


        internal override void Effect(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.ChangeState(new CheerUpState(target));
            }
        }
    }
}
