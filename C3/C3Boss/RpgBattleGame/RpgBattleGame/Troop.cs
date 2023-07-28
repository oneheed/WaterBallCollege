using System.Text.RegularExpressions;
using RpgBattleGame.Roles;

namespace RpgBattleGame
{
    internal class Troop
    {
        internal string Name { get; private set; }

        internal string Symbol { get; private set; }

        internal List<Role> Roles { get; private set; }

        public Troop(string name, List<Role> roles)
        {
            this.Name = name;
            var regex = new Regex(@"\d+");
            this.Symbol = $"[{regex.Match(name).Value}]";
            this.Roles = roles;
        }

        internal bool Annihilate()
        {
            return !this.Roles.Exists(r => r.Alive());
        }

        internal void Join(Role role)
        {
            role.SetTroop(this);

            this.Roles.Add(role);
        }
    }
}