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

        internal virtual int CalDamage(int number) => number;

        internal virtual void EnterState()
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

        private void ReduceTimeLimit()
            => _timeLimit--;

        internal void Finished()
        {
            if (_finishedState != null)
            {
                _role.EnterState(_finishedState);
            }
        }

        internal virtual void Damage()
        {
        }
    }
}