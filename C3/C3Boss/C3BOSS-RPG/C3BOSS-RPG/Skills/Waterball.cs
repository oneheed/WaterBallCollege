using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
{
    internal class Waterball : Skill
    {
        internal override string Name => "水球";

        internal override int MP => 50;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            foreach (var target in targets)
            {
                target.Damage(caster, 120);
            }

            caster.ConsumeMP(MP);
        }
    }
}
