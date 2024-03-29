﻿using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class InvincibleState : State
    {
        public override string Name => "無敵";

        internal InvincibleState(Role role) : base(role)
        {
            _timeLimit = 2;
            _finishedState = new NormalState(role);
        }

        internal override int CalDamage(int number) => 0;
    }
}
