namespace TreasureMap.Models
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
            this.ReduceTimeLimit();

            if (this._timeLimit <= 0)
            {
                this.Finished();
            }
        }

        internal virtual void ExitState()
        {
        }

        private void ReduceTimeLimit()
            => this._timeLimit--;

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

    internal class NormalState : State
    {
        internal NormalState(Role role) : base(role)
        {
        }

        internal override void DoState()
        {
            // Method intentionally left empty.
        }
    }

    internal class InvincibleState : State
    {


        internal InvincibleState(Role role) : base(role)
        {
            this._timeLimit = 2;
            this._finishedState = new NormalState(role);
        }

        internal override int CalDamage(int number) => 0;
    }

    internal class PoisonedState : State
    {
        internal PoisonedState(Role role) : base(role)
        {
            this._timeLimit = 3;
            this._finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            this._role.Damage(15);

            base.DoState();
        }
    }

    internal class AcceleratedState : State
    {
        internal AcceleratedState(Role role) : base(role)
        {
            this._timeLimit = 3;
            this._finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            //this._role.Change();

            base.DoState();
        }

        internal override void Damage()
        {
            this.Finished();
        }
    }

    internal class HealingState : State
    {
        internal HealingState(Role role) : base(role)
        {
            this._timeLimit = 5;
            this._finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            this._role.Healing(30);

            if (_role.IsFullHp())
            {
                this.Finished();
            }
            else
            {
                base.DoState();
            }
        }
    }

    internal class OrderlessState : State
    {
        internal OrderlessState(Role role) : base(role)
        {
            this._timeLimit = 3;
            this._finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            //OnlyMoveUpAndDown();
            //OnlyMoveRightAndLeft();
        }
    }

    internal class StockpileState : State
    {
        internal StockpileState(Role role) : base(role)
        {
            this._timeLimit = 2;
            this._finishedState = new EruptingState(role);
        }

        internal override void Damage()
        {
            _role.EnterState(new NormalState(this._role));
        }
    }

    internal class EruptingState : State
    {
        internal EruptingState(Role role) : base(role)
        {
            this._timeLimit = 3;
            this._finishedState = new TeleportState(role);
        }

        internal override void DoState()
        {
            //this._role.ac(50);

            base.DoState();
        }
    }

    internal class TeleportState : State
    {
        internal TeleportState(Role role) : base(role)
        {
            this._timeLimit = 1;
            this._finishedState = new NormalState(role);
        }

        internal override void DoState()
        {
            //this._role.RoundMove();

            base.DoState();
        }
    }
}