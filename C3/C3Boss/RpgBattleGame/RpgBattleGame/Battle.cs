using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.Skills;

namespace RpgBattleGame
{
    internal class Battle
    {
        public int Round { get; private set; } = 0;

        public Troop[] Troops { get; private set; }

        public Role Hero { get; private set; }

        internal Battle(Troop[] troops)
        {
            this.Troops = troops;

            Hero = troops[0].Roles[0];
        }

        internal void BattleStart()
        {
            BattleProcess();
            Winner();
        }

        internal void BattleProcess()
        {
            while (true)
            {
                try
                {
                    for (var i = 0; i < this.Troops.Length; i++)
                    {
                        var troop = this.Troops[i];
                        var allyIndex = i;
                        var enemyIndex = i == 0 ? 1 : 0;

                        for (int j = 0; j < troop.Roles.Count; j++)
                        {
                            var index = j;
                            var role = troop.Roles[index];

                            if (role.Alive())
                            {
                                Console.WriteLine($"輪到 {role.Name} (HP: {role.HP}, MP: {role.MP}, STR: {role.STR}, State: {role.State.Name})。");

                                role.State.ChangAction();

                                if (role.CanAction())
                                {
                                    var action = default(Skill);

                                    do
                                    {
                                        Console.WriteLine($"選擇行動： {string.Join(" ", role.Skills.Select((s, i) => $"({i}) {s.Name}"))}");
                                        action = role.ChangeAction();

                                        if (role.MP < action.MP)
                                        {
                                            Console.WriteLine("你缺乏 MP，不能進行此行動。");
                                        }
                                    }
                                    while (role.MP < action.MP);

                                    var targets = new List<Role>();
                                    if (action.TroopType == TroopType.Ally || action.TroopType == TroopType.Enemy)
                                    {
                                        var targetIndex = action.TroopType == TroopType.Ally ? allyIndex : enemyIndex;
                                        targets = this.Troops[targetIndex].Roles.Where(r => r.Alive() && !r.Equals(role)).ToList();

                                        if (targets.Count > action.TargetNumber)
                                        {
                                            targets = role.ChangTargets(action, targets).ToList();
                                        }
                                    }
                                    else if (action.TroopType == TroopType.Self)
                                    {
                                        targets = new List<Role> { role };
                                    }
                                    else
                                    {
                                        targets = this.Troops.SelectMany(t => t.Roles).Where(r => !r.Equals(role)).ToList();
                                    }

                                    action.Execute(role, targets);
                                }
                            }

                            role.State.DoState();

                            if (GameOver())
                            {
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                Round++;
            }
        }

        internal bool GameOver()
        {
            return Array.Exists(this.Troops, t => t.Annihilate()) || this.Hero.Dead();
        }

        internal void Winner()
        {
            if (this.Hero.Alive())
            {
                Console.WriteLine("你獲勝了！");
            }
            else
            {
                Console.WriteLine("你失敗了！");
            }
        }
    }
}
