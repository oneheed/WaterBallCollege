using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal class NormalState : State
    {
        internal NormalState(Role role) : base(role)
        {
        }

        internal override void EnterState()
        {
            this._role.ResetDefaultStrategy();
        }

        internal override void DoState()
        {
            // Method intentionally left empty.
        }
    }
}
