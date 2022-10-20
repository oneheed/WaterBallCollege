using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.States
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

        internal virtual void ChangAction()
        {
        }

        internal virtual void ChangTargets()
        {
        }

        internal virtual void ExcuteAction()
        {
        }

        internal virtual void EnterState()
        {
        }

        internal virtual void DoState()
        {
            this.ReduceTimeLimit();

            if (_timeLimit <= 0)
            {
                Finished();
            }
        }

        internal virtual void ExitState()
        {
        }

        /// <summary>
        /// 狀態結束
        /// </summary>
        internal void Finished()
        {
            if (_finishedState != null)
            {
                _role.ChangeState(_finishedState);
            }
        }


        internal virtual int CalDamage(int unit)
            => unit;

        internal virtual int CalHealing(int unit)
            => unit;

        private void ReduceTimeLimit()
            => _timeLimit--;

        internal virtual bool CanAction()
        {
            return true;
        }
    }
}