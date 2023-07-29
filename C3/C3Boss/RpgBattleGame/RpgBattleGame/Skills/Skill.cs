using RpgBattleGame.Enums;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal abstract class Skill
    {
        internal abstract string Name { get; }

        internal abstract int MP { get; }

        internal abstract int TargetNumber { get; }

        internal abstract TroopType TroopType { get; }

        internal bool CheckMP(Role role)
        {
            return role.MP >= this.MP;
        }

        internal bool CheckChangTargets(IEnumerable<Role> targets)
        {
            return targets.Count() <= this.TargetNumber;
        }

        internal virtual void ShowExecuteMessage(Role caster, IEnumerable<Role> targets)
        {
            var multiText = string.Empty;

            if ((TroopType & TroopType.ALL) == TroopType && targets.Any())
            {
                multiText = $"對 {string.Join(", ", targets.Select(r => $"{r.Name}"))}";
            }

            Console.WriteLine($"{caster.Name} {multiText} 使用了 {this.Name}。");
        }

        internal void Execute(Role caster, IEnumerable<Role> targets)
        {
            ShowExecuteMessage(caster, targets);

            Effect(caster, targets);

            caster.ConsumeMP(MP);
        }

        internal abstract void Effect(Role caster, IEnumerable<Role> targets);
    }
}
