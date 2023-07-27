using RpgBattleGame.Roles;

namespace RpgBattleGame.States
{
    internal class PetrochemicalState : State
    {
        internal override string Name => "石化";

        public PetrochemicalState(Role role) : base(role)
        {
            this._timeLimit = 3;
            this._finishedState = new NormalState(role);
        }

        internal override bool CanAction()
        {
            return false;
        }
    }
}
