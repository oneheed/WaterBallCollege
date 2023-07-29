using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.Subscribes;

namespace RpgBattleGame.Skills
{
    internal class Curse : Skill
    {
        internal override string Name => "詛咒";

        internal override int MP => 100;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Effect(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.SubscribeDeadNotify(new CurseDeadSubscriber(caster));
            }
        }
    }
}
