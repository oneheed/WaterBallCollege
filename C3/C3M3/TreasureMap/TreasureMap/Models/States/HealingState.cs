﻿using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class HealingState : State
    {
        public override string Name => "恢復";

        internal HealingState(Role role) : base(role)
        {
            _timeLimit = 5;
            _finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            _role.Healing(30);

            if (_role.IsFullHp())
            {
                Finished();
            }
        }
    }
}
