﻿using TreasureMap.Models.Roles;

namespace TreasureMap.Models.States
{
    internal abstract class State
    {
        public abstract string Name { get; }

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

        internal void Do()
        {
            if (_timeLimit <= 0)
            {
                Finished();
            }
            else
            {
                DoState();
                ReduceTimeLimit();
            }
        }

        internal virtual void DoState()
        {
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