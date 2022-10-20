using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
{
    internal class SelfHealing : Skill
    {
        internal override string Name => "自我治療";

        internal override int MP => 50;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Self;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            Console.WriteLine($"{caster.Name} 使用了 {this.Name}。");

            foreach (var target in targets)
            {
                target.Healing(150);
            }

            caster.ConsumeMP(MP);
        }
    }
}
