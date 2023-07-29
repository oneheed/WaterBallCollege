using System.Data;
using RpgBattleGame.Enums;
using RpgBattleGame.Roles;
using RpgBattleGame.Skills;

namespace RpgBattleGame.Models
{
    internal class Battle
    {
        public int Round { get; private set; } = 0;

        public Troop[] Troops { get; private set; }

        public Role Hero { get; private set; }

        internal Battle(Troop[] troops)
        {
            Troops = troops;

            Hero = troops[0].Roles[0];
        }

        internal void Process()
        {
            while (true)
            {
                try
                {
                    for (var i = 0; i < Troops.Length; i++)
                    {
                        var troop = Troops[i];

                        for (int j = 0; j < troop.Roles.Count; j++)
                        {
                            var index = j;
                            var caster = troop.Roles[index];

                            if (caster.Alive())
                            {
                                Console.WriteLine($"輪到 {caster.Name} (HP: {caster.HP}, MP: {caster.MP}, STR: {caster.STR}, State: {caster.State.Name})。");

                                var action = SelectActionStage(caster);

                                var targets = SelectTargetStage(caster, action);

                                ExecuteActionStage(caster, targets, action);
                            }

                            caster.State.ActionFinished();

                            if (GameOver())
                            {
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Round++;
            }
        }

        private Skill SelectActionStage(Role caster)
        {
            caster.State.BeforeSelectAction();

            var action = default(Skill);

            if (caster.CanAction())
            {
                do
                {
                    Console.WriteLine($"選擇行動： {string.Join(" ", caster.Skills.Select((s, i) => $"({i}) {s.Name}"))}");
                    action = caster.SelectAction();

                    if (!action.CheckMP(caster))
                    {
                        Console.WriteLine("你缺乏 MP，不能進行此行動。");
                    }
                }
                while (!action.CheckMP(caster));
            }

            return action;
        }

        private List<Role> SelectTargetStage(Role caster, Skill action)
        {
            var targets = new List<Role>();

            if (caster.CanAction())
            {
                if (action.TroopType == TroopType.Ally || action.TroopType == TroopType.Enemy)
                {
                    var isAlly = (string troopName) => troopName.Equals(caster.GetTroop().Name);
                    var selectTroop = action.TroopType == TroopType.Ally ?
                        Array.Find(Troops, t => isAlly(t.Name)) : Array.Find(Troops, t => !isAlly(t.Name));

                    targets = selectTroop!.Roles.Where(r => r.Alive() && !r.Equals(caster)).ToList();

                    if (action.IsSelectTargets(targets))
                    {
                        targets = caster.SelectTargets(action, targets).ToList();
                    }
                }
                else if (action.TroopType == TroopType.Self)
                {
                    targets = new List<Role> { caster };
                }
                else if (action.TroopType == TroopType.ALL)
                {
                    targets = Troops.SelectMany(t => t.Roles).Where(r => !r.Equals(caster)).ToList();
                }
            }

            return targets;
        }

        private void ExecuteActionStage(Role caster, List<Role> targets, Skill action)
        {
            if (caster.CanAction())
            {
                action.Effect(caster, targets);
            }
        }

        private bool GameOver()
        {
            return Array.Exists(Troops, t => t.Annihilate()) || Hero.Dead();
        }

        internal void Winner()
        {
            if (Hero.Alive())
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
