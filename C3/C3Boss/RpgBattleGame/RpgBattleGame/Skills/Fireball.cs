using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class Fireball : Skill
    {
        internal override string Name => "火球";

        internal override int MP => 50;

        // 所有敵軍
        internal override int TargetNumber => 99;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            foreach (var target in targets)
            {
                target.Damage(caster, 50);
            }

            caster.ConsumeMP(MP);
        }
    }
}
