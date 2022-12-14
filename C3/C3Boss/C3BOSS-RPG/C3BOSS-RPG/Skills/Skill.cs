using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
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

        internal abstract void Execute(Role caster, IEnumerable<Role> targets);
    }
}
