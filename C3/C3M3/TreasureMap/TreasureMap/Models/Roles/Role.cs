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

        public bool IsAction => this.ActionNumber > 0 && this.HP > 0;

        public int ActionNumber { get; set; }

        public State State { get; private set; }

        public AttackStrategy AttackStrategy { get; private set; }

        public MoveStrategy MoveStrategy { get; private set; }

        protected Role() : base()
        {
            HP = InitHP;
            State = new NormalState(this);
            AttackStrategy = new NormalAttackStrategy(this);
            MoveStrategy = new NormalMoveStrategy(this);
        }

        public void SetAttackStrategy(AttackStrategy attackStrategy)
        {
            this.AttackStrategy = attackStrategy;
        }

        public void SetMoveStrategy(MoveStrategy moveStrategy)
        {
            this.MoveStrategy = moveStrategy;
        }

        public abstract void ResetDefaultStrategy();

        public void EnterState(State state)
        {
            State.ExitState();

            State = state;

            State.EnterState();
        }

        public void Action()
        {
            State.ActionState();
        }

        public void Do()
        {
            State.Do();
        }

        public abstract void DoAction();

        public void Damage(int number)
        {
            number = State.CalDamage(number);

            HP -= number;

            if (HP <= 0)
            {
                Death();
            }

            State.Damaged();
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

        public abstract void Move(Direction direction = Direction.None);

        public abstract void Attack();


        public void Death()
        {
            this.Map?.RemoveMapObject(this);
        }

        public void Touch(Treasure treasure)
        {
            var state = treasure.Touched(this);

            EnterState(state);
        }
    }
}
