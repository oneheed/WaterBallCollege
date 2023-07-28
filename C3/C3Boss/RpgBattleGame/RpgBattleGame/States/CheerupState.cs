using RpgBattleGame.Roles;

namespace RpgBattleGame.States
{
    internal class CheerUpState : State
    {
        internal override string Name => "受到鼓舞";

        public CheerUpState(Role role) : base(role)
        {
            this._timeLimit = 3;
            this._finishedState = new NormalState(role);
        }

        internal override int CalDamage(int unit)
            => unit + 50;
    }
}
