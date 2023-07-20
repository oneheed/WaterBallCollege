using TreasureMap.Models.Roles;
using TreasureMap.Strategies.Attack;

namespace TreasureMap.Models.States
{
    internal class EruptingState : State
    {
        public override string Name => "爆發";

        internal EruptingState(Role role) : base(role)
        {
            _timeLimit = 3;
            _finishedState = new TeleportState(role);
        }

        internal override void EnterState()
        {
            this._role.SetAttackStrategy(new AllAttackStrategy(this._role));
        }

        internal override void ExitState()
        {
            this._role.ResetDefaultStrategy();
        }
    }
}
