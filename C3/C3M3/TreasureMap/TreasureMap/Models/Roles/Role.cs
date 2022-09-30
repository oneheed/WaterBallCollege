using TreasureMap.Enums;
using TreasureMap.Models.States;
using TreasureMap.Strategies.Attack;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.Roles
{
    internal abstract class Role : MapObject
    {
        protected abstract int InitHP { get; }

        public int HP { get; private set; }

        public State State { get; protected set; }

        protected AttackStrategy _attackStrategy;

        protected MoveStrategy _moveStrategy;

        protected Role() : base()
        {
            HP = InitHP;
            State = new NormalState(this);
        }

        public void SetAttackStrategy(AttackStrategy attackStrategy)
        {
            this._attackStrategy = attackStrategy;
        }

        public void SetMoveStrategy(MoveStrategy moveStrategy)
        {
            this._moveStrategy = moveStrategy;
        }

        public abstract void ResetDefualtStrategy();

        public void EnterState(State state)
        {
            State.ExitState();

            State = state;

            State.EnterState();
        }

        public void Do()
        {
            State.DoState();
        }

        public void Damage(int number)
        {
            number = State.CalDamage(number);

            HP -= number;

            if (HP <= 0)
            {
                Death();
            }

            State.Damage();
        }

        internal void Healing(int number)
        {
            HP += number;
            HP = IsFullHp() ? InitHP : HP;
        }

        internal bool IsFullHp()
        {
            return HP >= InitHP;
        }

        public abstract void Attack();

        public abstract void Move(Direction direction = Direction.None);

        public void Touch(Treasure treasure)
        {
            var state = treasure.StateFunc(this);

            EnterState(state);
        }
    }
}
