using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.States;

namespace RpgBattleGame.Skills
{
    internal class CheerUp : Skill
    {
        internal override string Name => "鼓舞";

        internal override int MP => 100;

        internal override int TargetNumber => 3;

        internal override TroopType TroopType => TroopType.Ally;


        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.ChangeState(new CheerUpState(target));
            }

            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            caster.ConsumeMP(MP);
        }
    }
}
