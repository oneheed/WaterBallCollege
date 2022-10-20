using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Strategies;

namespace C3BOSS_RPG.Skills
{
    internal class Curse : Skill
    {
        internal override string Name => "詛咒";

        internal override int MP => 100;

        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.SetDeadStrategy(new CurseStrategy(caster));
            }

            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            caster.ConsumeMP(MP);
        }
    }
}
