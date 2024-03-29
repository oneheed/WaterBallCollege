﻿using RpgBattleGame.Enums;
using RpgBattleGame.Observers;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Skills
{
    internal class Summon : Skill
    {
        internal override string Name => "召喚";

        internal override int MP => 150;

        internal override int TargetNumber => -1;

        internal override TroopType TroopType => TroopType.Self;

        internal override void Execute(Role caster, IEnumerable<Role> targets)
        {
            var troop = caster.GetTroop();

            var slime = new Role(100, 0, 50, "Slime", new List<Skill> { });
            slime.SubscribeDeadNotify(new SummonDeadObserver(caster));

            troop.Join(slime);
        }
    }
}
