using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Skills;

namespace C3BOSS_RPG.Strategies
{
    internal abstract class AIStrategy
    {
        protected readonly Role role;

        protected AIStrategy(Role role)
        {
            this.role = role;
        }

        internal abstract Skill ChangeAction();

        internal abstract IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles);
    }
}
