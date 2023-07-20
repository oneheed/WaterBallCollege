using TreasureMap.Models.Roles;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.States
{
    internal class TeleportState : State
    {
        public override string Name => "瞬身";

        internal TeleportState(Role role) : base(role)
        {
            _timeLimit = 1;
            _finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            this._role.SetMoveStrategy(new RandomMoveStrategy(this._role));
            this._role.Move(Enums.Direction.Up);
        }
    }
}
