using RpgBattleGame.Roles;

namespace RpgBattleGame.States
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
