namespace TreasureMap.Models.States
{
    internal class TeleportState : State
    {
        internal TeleportState(Role role) : base(role)
        {
            _timeLimit = 1;
            _finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            //this._role.RoundMove();

            base.DoState();
        }
    }
}
