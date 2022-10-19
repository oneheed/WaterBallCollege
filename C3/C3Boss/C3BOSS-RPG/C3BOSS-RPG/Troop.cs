using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG
{
    internal class Troop
    {
        internal List<Role> Roles { get; private set; } = new List<Role>();

        internal bool Annihilate()
        {
            return !this.Roles.Any(r => r.Alive());
        }

        internal void Join(Role role)
        {
            this.Roles.Add(role);
        }
    }
}