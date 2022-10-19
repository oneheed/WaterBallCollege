using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Skills
{
    internal class BasicAttack : Skill
    {
        internal override string Name => "普通攻擊";

        internal override void Execute(IEnumerable<Role> targets)
        {
            var damage = _caster.STR;
            foreach (var target in targets)
            {
                target.Damage(damage);
            }
        }
    }
}
