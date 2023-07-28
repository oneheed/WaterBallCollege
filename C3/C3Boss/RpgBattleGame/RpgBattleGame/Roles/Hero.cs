using RpgBattleGame.Skills;

namespace RpgBattleGame.Roles
{
    internal class Hero : Role
    {
        public Hero(int hp, int mp, int str, string name, IEnumerable<Skill> skills)
            : base(hp, mp, str, name, skills)
        {
        }

        public override IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles)
        {
            if (skill.TargetNumber != -1)
            {
                var text = string.Join(" ", roles.Select((r, i) => $"({i}) {r.Name}"));
                Console.WriteLine($"選擇 {skill.TargetNumber} 位目標: {text}");
            }

            return base.ChangTargets(skill, roles);
        }
    }
}
