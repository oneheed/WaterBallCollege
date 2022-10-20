using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Strategies;

namespace C3BOSS_RPG.Skills
{
    internal class Summon : Skill
    {
        internal override string Name => "召喚";

        internal override int MP => 150;

        internal override int TargetNumber => -1;

        internal override TroopType TroopType => TroopType.None;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            Console.WriteLine($"{caster.Name} 使用了 {this.Name}。");

            var troop = caster.GetTroop();

            var slime = new Role(100, 0, 50, "Slime", new List<Skill> { });
            slime.SetDeadStrategy(new SummonStrategy(caster));
            troop.Join(slime);

            caster.ConsumeMP(MP);
        }
    }
}
