using TreasureMap.Enums;
using TreasureMap.Strategies.Attack;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.Roles
{
    internal class Character : Role
    {
        private static readonly Dictionary<Direction, char> _characterDic = new Dictionary<Direction, char>
        {
            { Direction.Up, '↑' },
            { Direction.Down, '↓' },
            { Direction.Left, '←' },
            { Direction.Right, '→' },
        };

        public override char Symbol => _characterDic[_direction];

        protected sealed override int InitHP { get; } = 300;

        private Direction _direction = Direction.Up;


        public Character() : base()
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
            this._attackStrategy.Attack(this._direction);
        }

        public override void Move(Direction direction = Direction.None)
        {
            this._moveStrategy.Move(direction);
            this._direction = direction;
        }
    }
}
