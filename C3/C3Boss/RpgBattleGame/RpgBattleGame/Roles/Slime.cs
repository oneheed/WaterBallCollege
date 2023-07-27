using RpgBattleGame.Skills;

namespace RpgBattleGame.Roles
{
    internal class Slime : Role
    {
        public Slime() : base(100, 0, 50, "史萊姆", new List<Skill>())
        {
        }
    }
}
