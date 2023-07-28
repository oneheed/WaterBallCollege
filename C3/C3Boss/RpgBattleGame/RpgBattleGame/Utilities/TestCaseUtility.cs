using System.Text.RegularExpressions;
using RpgBattleGame.Roles;
using RpgBattleGame.Skills;
using RpgBattleGame.Strategies;

namespace RpgBattleGame.Utilities
{
    internal static class TestCaseUtility
    {
        public static Battle ConvertBattleByFile(string filePath)
        {
            var text = File.ReadAllText(filePath);
            var troops = new List<Troop>();

            var pattern = @"(#軍隊-\d)-開始([\s\S]*?)#軍隊-\d-結束";
            var matches = Regex.Matches(text, pattern);

            var groupIndex = 0;
            foreach (var groups in matches.Select(m => m.Groups))
            {
                var troop = new Troop(groups[1].Value, new List<Role>());
                var lines = groups[2].Value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < lines.Length; i++)
                {
                    //Console.WriteLine(lines[i].Trim());
                    var roleData = lines[i].Split(' ');
                    var hp = int.Parse(roleData[1]);
                    var mp = int.Parse(roleData[2]);
                    var str = int.Parse(roleData[3]);
                    var skills = roleData.Length >= 5 ? ConvertSkills(string.Join(' ', roleData[4..])) : new List<Skill>();
                    var role = groupIndex == 0 && i == 0 ?
                        new Hero(hp, mp, str, roleData[0], skills) : new Role(hp, mp, str, roleData[0], skills);

                    troop.Join(role);
                }

                troops.Add(troop);
                groupIndex++;
            }

            var remainingText = text.Substring(matches[1].Index + matches[1].Length);
            var actins = remainingText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            troops[0].Roles[0].SetAIStrategy(new HeroStrategy(troops[0].Roles[0], actins.ToList()));

            var battle = new Battle(troops.ToArray());

            return battle;
        }

        private static readonly List<Skill> supportSkills = new List<Skill>
        {
            new BasicAttack(),
            new CheerUp(),
            new Curse(),
            new OnePunch(),
            new Fireball(),
            new Petrochemical(),
            new Poison(),
            new SelfExplosion(),
            new SelfHealing(),
            new Summon(),
            new Waterball(),
        };

        private static List<Skill> ConvertSkills(string skillText)
        {
            var result = new List<Skill>();

            foreach (var skillName in skillText.Split(' '))
            {
                var skill = supportSkills.Find(s => s.Name == skillName);

                if (skill != null) { result.Add(skill); }
            }

            return result;
        }
    }
}
