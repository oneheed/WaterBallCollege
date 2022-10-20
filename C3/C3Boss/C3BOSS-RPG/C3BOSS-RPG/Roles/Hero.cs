using C3BOSS_RPG.Skills;
using C3BOSS_RPG.Strategies;

namespace C3BOSS_RPG.Roles
{
    internal class Hero : Role
    {
        public Hero(int hp, int mp, int str, string name, IEnumerable<Skill> skills) : base(hp, mp, str, name, skills)
        {
            this._aiStrategy = new HeroStrategy(this);
        }
    }
}
