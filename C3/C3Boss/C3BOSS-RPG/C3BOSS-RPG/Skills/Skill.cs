using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
{
    internal abstract class Skill
    {
        internal virtual string Name { get; set; }

        internal virtual int MP { get; set; } = 0;

        internal virtual int TargetNumber { get; set; } = 1;

        internal Role _caster;

        internal bool CheckMP(Role role)
        {
            return role.MP >= this.MP;
        }

        internal bool CheckChangTargets(IEnumerable<Role> targets)
        {
            return targets.Count() <= this.TargetNumber;
        }

        internal abstract void Execute(IEnumerable<Role> targets);
    }
}
