using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
{
    internal class BasicAttack : Skill
    {
        internal override string Name => "普通攻擊";

        internal override int MP => 0;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;


        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var damage = caster.STR;
            foreach (var target in targets)
            {
                Console.WriteLine($"{caster.Name} 攻擊 {target.Name}。");
                target.Damage(caster, damage);
            }

            caster.ConsumeMP(MP);
        }
    }
}
