using TreasureMap.Models.Roles;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.States
{
    internal class OrderlessState : State
    {
        internal OrderlessState(Role role) : base(role)
        {
            _timeLimit = 3;
            _finishedState = new NormalState(role);
        }

        internal override void EnterState()
        {
            var random = new Random().Next(2);
            var moveStrategy = (MoveStrategy)(random == 0 ? new OnlyUpAndDownMoveStrategy(this._role) : new OnlyRightAndLeftMoveStrategy(this._role));

            this._role.SetMoveStrategy(moveStrategy);
        }
    }
}
