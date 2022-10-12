using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal abstract class State
    {
        protected int _timeLimit;

        protected State? _finishedState;

        protected readonly Role _role;

        protected State(Role role)
        {
            _role = role;
        }

        internal virtual void EnterState()
        {
        }

        internal virtual void ActionState()
        {
        }

        internal virtual void DoState()
        {
            ReduceTimeLimit();

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
                _role.EnterState(_finishedState);
            }
        }

        internal virtual int CalDamage(int number) => number;


        /// <summary>
        /// 受到傷害
        /// </summary>
        internal virtual void Damaged()
        {
        }

        private void ReduceTimeLimit()
            => _timeLimit--;
    }
}