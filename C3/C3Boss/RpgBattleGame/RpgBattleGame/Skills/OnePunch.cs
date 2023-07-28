using RpgBattleGame.Enums;
using RpgBattleGame.Handlers;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class OnePunch : Skill
    {
        internal override string Name => "一拳攻擊";

        internal override int MP => 180;

        // 所有敵軍
        internal override int TargetNumber => 1;

        internal override TroopType TroopType => TroopType.Enemy;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var target = targets.FirstOrDefault();

            var text = string.Join(", ", targets.Select(r => $"{r.Name}"));
            Console.WriteLine($"{caster.Name} 對 {text} 使用了 {this.Name}。");

            if (target != null)
            {
                var onePunchHandler = new HpOver500Handler(
                    new PoisonedOrPetrochemicalStateHandler(
                              new CheerUpStateHandler(
                                  new NormalStateHandler())));

                onePunchHandler.Attack(caster, target);
            }

            caster.ConsumeMP(MP);
        }
    }
}
