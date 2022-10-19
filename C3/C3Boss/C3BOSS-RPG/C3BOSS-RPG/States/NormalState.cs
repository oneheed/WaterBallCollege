using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.States
{
    internal class NormalState : State
    {
        internal override string Name => "正常";

        public NormalState(Role role) : base(role)
        {
        }

        internal override void DoState()
        {
            // Method intentionally left empty.
        }
    }
}
