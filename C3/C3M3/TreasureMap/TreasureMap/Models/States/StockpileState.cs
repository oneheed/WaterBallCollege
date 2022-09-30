using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class StockpileState : State
    {
        internal StockpileState(Role role) : base(role)
        {
            _timeLimit = 2;
            _finishedState = new EruptingState(role);
        }

        internal override void Damage()
        {
            _role.EnterState(new NormalState(_role));
        }
    }
}
