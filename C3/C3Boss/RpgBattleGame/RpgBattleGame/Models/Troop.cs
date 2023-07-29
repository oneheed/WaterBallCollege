using System.Text.RegularExpressions;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Models
{
    internal class Troop
    {
        internal string Name { get; private set; }

        internal string Symbol { get; private set; }

        internal List<Role> Roles { get; private set; }

        public Troop(string name, List<Role> roles)
        {
            Name = name;
            var regex = new Regex(@"\d+");
            Symbol = $"[{regex.Match(name).Value}]";
            Roles = roles;
        }

        internal bool Annihilate()
        {
            return !Roles.Exists(r => r.Alive());
        }

        internal void Join(Role role)
        {
            role.SetTroop(this);

            Roles.Add(role);
        }
    }
}