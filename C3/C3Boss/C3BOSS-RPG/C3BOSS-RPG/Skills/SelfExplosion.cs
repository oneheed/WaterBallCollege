using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
{
    internal class SelfExplosion : Skill
    {
        internal override string Name => "自爆";

        internal override int MP => 200;

        internal override int TargetNumber => -1;

        internal override TroopType TroopType => TroopType.ALL;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            foreach (var target in targets)
            {
                target.Damage(caster, 150);
            }

            caster.ConsumeMP(MP);
            caster.Suicide();
        }
    }
}
