using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class PoisonedState : State
    {
        internal PoisonedState(Role role) : base(role)
        {
            _timeLimit = 3;
            _finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            _role.Damage(15);

            base.DoState();
        }
    }
}
