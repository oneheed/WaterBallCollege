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

        internal override void DoState()
        {
            //this._role.Change();

            base.DoState();
        }

        internal override void Damage()
        {
            Finished();
        }
    }
}
