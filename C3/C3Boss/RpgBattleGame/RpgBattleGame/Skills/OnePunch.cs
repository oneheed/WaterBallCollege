using RpgBattleGame.Enums;
using RpgBattleGame.Handlers;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class OnePunch : Skill
    {
        internal override string Name => "一拳攻擊";

        internal override int MP => 180;

        // 所有敵軍
        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                var onePunchHandler = new HpOver500Handler(
                    new PoisonedOrPetrochemicalStateHandler(
                              new CheerUpStateHandler(
                                  new NormalStateHandler())));

                onePunchHandler.Effect(caster, target);
            }
        }
    }
}
