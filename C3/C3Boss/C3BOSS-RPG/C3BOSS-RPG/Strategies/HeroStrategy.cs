using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Skills;

namespace C3BOSS_RPG.Strategies
{
    internal class HeroStrategy : AIStrategy
    {
        private int seed = 0;

        internal HeroStrategy(Role role) : base(role)
        {
        }

        // cheerup
        //private List<string> changeAction = new List<string>
        //{
        //    "1",
        //    "0, 1, 2",
        //    "1",
        //    "2, 3, 4",
        //    "0",
        //};

        // curse
        private List<string> changeAction = new List<string>
        {
            "1",
            "1",
            "0",
            "0",
            "0",
            "1",
            "0",
            "1",
            "0",
        };

        // only-basic-attack
        //private List<string> changeAction = new List<string>
        //{
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "1",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //};

        // petrochemical
        //private List<string> changeAction = new List<string>
        //{
        //    "1",
        //    "0",
        //    "0",
        //    "0",
        //    "1",
        //    "0",
        //    "0",
        //    "1",
        //    "0",
        //    "0",
        //    "0",
        //};

        // poison
        //private List<string> changeAction = new List<string>
        //{
        //    "1",
        //    "0",
        //    "1",
        //    "1",
        //    "1",
        //    "2",
        //    "1",
        //    "0",
        //    "1",
        //    "1",
        //    "1",
        //    "0",
        //};

        // self-explosion
        //private List<string> changeAction = new List<string>
        //{
        //    "1",
        //};

        // self-healing
        //private List<string> changeAction = new List<string>
        //{
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //    "0",
        //};

        // summon
        //private List<string> changeAction = new List<string>
        //{
        //    "1",
        //    "1",
        //    "1",
        //    "1",
        //    "1",
        //    "1",
        //    "1",
        //};

        // waterball-and-fireball-1v2
        //private List<string> changeAction = new List<string>
        //{
        //    "1",
        //    "2",
        //    "1",
        //    "2",
        //    "1",
        //    "2",
        //    "1",
        //};

        internal override Skill ChangeAction()
        {
            var index = int.Parse(changeAction[seed]);

            seed++;

            return this.role.Skills[index];
        }

        internal override IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles)
        {
            var indexs = changeAction[seed].Split(", ").Select(x => int.Parse(x)).ToList();

            seed++;

            return roles.Where((r, i) => indexs.Contains(i));
        }
    }
}
