using C3BOSS_RPG.Roles;
using C3BOSS_RPG.States;

namespace C3BOSS_RPG.Skills
{
    internal class Cheerup : Skill
    {
        internal override string Name => "鼓舞";

        internal override void Execute(IEnumerable<Role> targets)
        {
            foreach (var target in targets)
            {
                target.ChangeState(new PoisonedState(target));
            }
        }
    }
}
