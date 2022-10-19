using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG
{
    internal class Battle
    {
        public int Round { get; private set; } = 0;

        public Dictionary<TroopType, Troop> Troops { get; private set; }

        public Hero Hero { get; private set; }

        internal Battle(Dictionary<TroopType, Troop> troops)
        {
            this.Troops = troops;
        }

        internal void BattlStart()
        {
        }

        internal void BattlProcess()
        {
            foreach (var troop in Troops)
            {
                foreach ((var index, var role) in troop.Value.Roles.Select((x, i) => (i, x)))
                {
                    Console.WriteLine($"輪到 [{(int)troop.Key}]{role.Name} (HP: {role.HP}, MP: {role.MP}, STR: {role.STR}, State: {role.State.Name})。");

                    role.State.ChangAction();

                    if (ChangeAction())
                    {
                        Console.WriteLine($"選擇行動： {string.Join(" ", role.Skills.Select((s, i) => $"({i}) {s.Name}"))}");
                    }

                    if (ChangTargets())
                    {
                        Console.WriteLine($"選擇 3 位目標: (0) [1]Servant1 (1) [1]Servant2 (2) [1]Servant3 (3) [1]Servant4 (4) [1]Servant5");
                    }

                    if (ExcuteAction())
                    {
                        Console.WriteLine($"[1]英雄 對 [1]Servant1, [1]Servant2, [1]Servant3 使用了 鼓舞。");
                    }
                }
            }
        }

        private bool ChangeAction()
        {
            return true;
        }

        private bool ChangTargets()
        {
            return true;
        }

        private bool ExcuteAction()
        {
            return true;
        }

        internal bool Gameover()
        {
            return this.Troops[TroopType.Ally].Annihilate() ||
                this.Troops[TroopType.Enemy].Annihilate() ||
                this.Hero.Dead();
        }

        internal bool Winner()
        {
            return this.Hero.Alive();
        }
    }
}
