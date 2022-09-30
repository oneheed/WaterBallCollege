using TreasureMap.Enums;
using TreasureMap.Strategies.Attack;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.Roles
{
    internal class Monster : Role
    {
        public override char Symbol => 'Μ';

        protected sealed override int InitHP { get; } = 1;

        public Monster() : base()
        {
            this.ResetDefualtStrategy();
        }

        public override void ResetDefualtStrategy()
        {
            this.SetAttackStrategy(new StraightLineAttackStrategy(this));
            this.SetMoveStrategy(new NormalMoveStrategy(this));
        }

        public override void Attack()
        {
            this._attackStrategy.Attack();
        }

        public override void Move(Direction direction = Direction.None)
        {
            this._moveStrategy.Move(direction);
        }
    }
}
