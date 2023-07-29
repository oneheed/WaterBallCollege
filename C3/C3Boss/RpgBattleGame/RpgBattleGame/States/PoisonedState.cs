using RpgBattleGame.Roles;

namespace RpgBattleGame.States
{
    internal class PoisonedState : State
    {
        internal override string Name => "中毒";

        public PoisonedState(Role role) : base(role)
        {
            this._timeLimit = 3;
        }

        internal override void BeforeSelectAction()
        {
            this._role.Damage(null, 30);
        }
    }
}
