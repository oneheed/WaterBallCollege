using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Skills;

namespace C3BOSS_RPG
{
    internal class Battle
    {
        public int Round { get; private set; } = 0;

        public Troop[] Troops { get; private set; } = new Troop[2];

        public Hero Hero { get; private set; }

        internal Battle(Troop[] troops)
        {
            this.Troops = troops;

            Hero = (Hero)troops[0].Roles.FirstOrDefault(r => r.GetType() == typeof(Hero));
        }

        internal void BattlStart()
        {
            BattlProcess();
            Winner();
        }

        internal void BattlProcess()
        {
            while (true)
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

                        if (role.State.CanAction() && role.Alive())
                        {
                            Console.WriteLine($"輪到 {role.Name} (HP: {role.HP}, MP: {role.MP}, STR: {role.STR}, State: {role.State.Name})。");

                            role.State.ChangAction();

                            Skill action = new BasicAttack();

                            do
                            {
                                Console.WriteLine($"選擇行動： {string.Join(" ", role.Skills.Select((s, i) => $"({i}) {s.Name}"))}");
                                action = role.ChangeAction();

                                if (role.MP < action.MP)
                                {
                                    Console.WriteLine("你缺乏 MP，不能進行此行動。");
                                }
                            } while (role.MP < action.MP);

                            var targets = new List<Role>();
                            if (action.TroopType == TroopType.Ally || action.TroopType == TroopType.Enemy)
                            {
                                var targetIndex = action.TroopType == TroopType.Ally ? allyIndex : enemyIndex;
                                targets = this.Troops[targetIndex].Roles.Where(r => r.Alive() && !r.Equals(role)).ToList();

                                if (action.TargetNumber != -1 && (targets.Count > action.TargetNumber && role.GetType() == typeof(Hero)))
                                {
                                    var text = string.Join(" ", targets.Select((r, i) => $"({i}) {r.Name}"));
                                    Console.WriteLine($"選擇 {action.TargetNumber} 位目標: {text}");
                                }

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

                        role.State.DoState();

                        if (Gameover())
                        {
                            return;
                        }
                    }

                    //foreach ((var index, var role) in troop.Roles.Where(r => r.Alive()).Select((x, i) => (i, x)).ToList())
                    //{
                    //    Console.WriteLine($"輪到 {role.Name} (HP: {role.HP}, MP: {role.MP}, STR: {role.STR}, State: {role.State.Name})。");

                    //    role.State.ChangAction();

                    //    Skill action = new BasicAttack();

                    //    if (role.State.CanAction() && role.Alive())
                    //    {
                    //        do
                    //        {
                    //            Console.WriteLine($"選擇行動： {string.Join(" ", role.Skills.Select((s, i) => $"({i}) {s.Name}"))}");
                    //            action = role.ChangeAction();

                    //            if (role.MP < action.MP)
                    //            {
                    //                Console.WriteLine("你缺乏 MP，不能進行此行動。");
                    //            }
                    //        } while (role.MP < action.MP);

                    //        var targets = new List<Role>();
                    //        if (action.TroopType == TroopType.Ally || action.TroopType == TroopType.Enemy)
                    //        {
                    //            var targetIndex = action.TroopType == TroopType.Ally ? allyIndex : enemyIndex;
                    //            targets = this.Troops[targetIndex].Roles.Where(r => r.Alive() && !r.Equals(role)).ToList();

                    //            if (action.TargetNumber != -1 && (targets.Count > action.TargetNumber && role.GetType() == typeof(Hero)))
                    //            {
                    //                var text = string.Join(" ", targets.Select((r, i) => $"({i}) {r.Name}"));
                    //                Console.WriteLine($"選擇 {action.TargetNumber} 位目標: {text}");
                    //            }

                    //            if (targets.Count > action.TargetNumber)
                    //            {
                    //                targets = role.ChangTargets(action, targets).ToList();
                    //            }
                    //        }
                    //        else if (action.TroopType == TroopType.Self)
                    //        {
                    //            targets = new List<Role> { role };
                    //        }
                    //        else
                    //        {
                    //            targets = this.Troops.SelectMany(t => t.Roles).Where(r => !r.Equals(role)).ToList();
                    //        }

                    //        action.Execute(role, targets);
                    //    }

                    //    role.State.DoState();

                    //    if (Gameover())
                    //    {
                    //        return;
                    //    }
                    //}
                }

                Round++;
            }
        }

        internal bool Gameover()
        {
            return this.Troops.Any(t => t.Annihilate()) || this.Hero.Dead();
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
