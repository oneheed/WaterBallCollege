using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class BasicAttack : Skill
    {
        internal override string Name => "普通攻擊";

        internal override int MP => 0;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void ShowExecuteMessage(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                Console.WriteLine($"{caster.Name} 攻擊 {target.Name}。");
            }
        }

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var damage = caster.STR;

            foreach (var target in targets)
            {
                target.Damage(caster, damage);
            }
        }
    }
}
