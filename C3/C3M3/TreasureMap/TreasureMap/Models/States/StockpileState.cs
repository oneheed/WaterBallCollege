using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class StockpileState : State
    {
        public override string Name => "蓄力";

        internal StockpileState(Role role) : base(role)
        {
            _timeLimit = 2;
            _finishedState = new EruptingState(role);
        }

        internal override void Damaged()
        {
            _role.EnterState(new NormalState(_role));
        }
    }
}
