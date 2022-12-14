using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;
using C3BOSS_RPG.States;

namespace C3BOSS_RPG.Skills
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

            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            caster.ConsumeMP(MP);
        }
    }
}
