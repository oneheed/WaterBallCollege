using RpgBattleGame.Roles;
using RpgBattleGame.Skills;

namespace RpgBattleGame.Strategies
{
    internal class HeroStrategy : AIStrategy
    {
        private int seed = 0;

        private readonly List<string> changeActions = new();

        internal HeroStrategy(Role role, List<string> actions) : base(role)
        {
            this.changeActions.AddRange(actions);
        }

        internal override Skill ChangeAction()
        {
            var index = int.Parse(changeActions[seed]);

            seed++;

            return this.role.Skills[index];
        }

        internal override IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles)
        {
            if (skill.TargetNumber != -1)
            {
                var text = string.Join(" ", roles.Select((r, i) => $"({i}) {r.Name}"));
                Console.WriteLine($"選擇 {skill.TargetNumber} 位目標: {text}");
            }

            var indexes = changeActions[seed].Split(", ").Select(x => int.Parse(x)).ToList();

            seed++;

            return roles.Where((r, i) => indexes.Contains(i));
        }
    }
}
