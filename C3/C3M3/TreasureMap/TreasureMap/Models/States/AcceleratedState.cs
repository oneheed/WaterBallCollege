using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class AcceleratedState : State
    {
        internal AcceleratedState(Role role) : base(role)
        {
            _timeLimit = 3;
            _finishedState = new NormalState(role);
        }

        internal override void ActionState()
        {
            this._role.ActionNumber++;
        }

        internal override void Damaged()
        {
            Finished();
        }
    }
}
