using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Skills;

namespace C3BOSS_RPG.Strategies
{
    internal class NormalAIStrategy : AIStrategy
    {
        private int seed = 0;

        internal NormalAIStrategy(Role role) : base(role)
        {
        }

        internal override Skill ChangeAction()
        {
            var index = seed % this.role.Skills.Count;

            seed++;

            return this.role.Skills[index];
        }

        internal override IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles)
        {
            var indexs = Enumerable.Range(seed, skill.TargetNumber).Select(i => i % roles.Count());

            seed++;

            return roles.Where((r, i) => indexs.Contains(i));
        }
    }
}
