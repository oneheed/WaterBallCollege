using TreasureMap.Models.States;

namespace TreasureMap.Models
{
    internal abstract class Role : MapObject
    {
        protected abstract int InitHP { get; }

        public int HP { get; private set; }

        public State State { get; protected set; }

        protected Role() : base()
        {
            this.HP = InitHP;
            this.State = new NormalState(this);
        }

        public void EnterState(State state)
        {
            this.State.ExitState();

            this.State = state;

            this.State.EnterState();
        }

        public void Do()
        {
            this.State.DoState();
        }

        public void Damage(int number)
        {
            number = this.State.CalDamage(number);

            this.HP -= number;

            if (this.HP <= 0)
            {
                this.Death();
            }

            this.State.Damage();
        }

        internal void Healing(int number)
        {
            this.HP += number;
            this.HP = this.IsFullHp() ? InitHP : this.HP;
        }

        internal bool IsFullHp()
        {
            return this.HP >= InitHP;
        }

        protected void Attack()
        {
            throw new NotImplementedException();
        }

        protected void Move()
        {
            throw new NotImplementedException();
        }

        protected void Touch(Treasure treasure)
        {
            var state = treasure.StateFunc(this);

            this.EnterState(state);
        }
    }
}
