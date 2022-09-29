namespace TreasureMap.Models.States
{
    internal class OrderlessState : State
    {
        internal OrderlessState(Role role) : base(role)
        {
            _timeLimit = 3;
            _finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            //OnlyMoveUpAndDown();
            //OnlyMoveRightAndLeft();
        }
    }
}
