using TreasureMap.Models.Roles;
using TreasureMap.Strategies.Attack;

namespace TreasureMap.Models.States
{
    internal class EruptingState : State
    {
        internal EruptingState(Role role) : base(role)
        {
            _timeLimit = 3;
            _finishedState = new TeleportState(role);
        }

        internal override void DoState()
        {
            this._role.SetAttackStrategy(new AllAttackStrategy(this._role));
        }
    }
}
