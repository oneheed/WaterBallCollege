using RpgBattleGame.Roles;

namespace RpgBattleGame.States
{
    internal class State
    {
        protected int _timeLimit = 0;

        protected State? _finishedState;

        protected Role _role;

        internal virtual string Name { get; } = string.Empty;

        public State(Role role)
        {
            this._role = role;
        }

        internal virtual void EnterState()
        {
        }

        internal virtual void ExitState()
        {
        }

        /// <summary>
        /// 狀態結束
        /// </summary>
        internal void StateFinished()
        {
            if (_finishedState != null)
            {
                _role.ChangeState(_finishedState);
            }
            else
            {
                _role.ChangeState(new NormalState(this._role));
            }
        }

        internal virtual void BeforeSelectAction()
        {
        }

        internal virtual void ActionFinished()
        {
            this.ReduceTimeLimit();

            if (_timeLimit <= 0)
            {
                StateFinished();
            }
        }

        internal virtual int CalDamage(int unit)
            => unit;

        internal virtual int CalHealing(int unit)
            => unit;

        private void ReduceTimeLimit()
            => _timeLimit--;

        internal virtual bool CanAction()
            => true;
    }
}