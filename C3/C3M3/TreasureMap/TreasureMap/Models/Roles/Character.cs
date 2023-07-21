using TreasureMap.Enums;
using TreasureMap.Strategies.Attack;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.Roles
{
    internal class Character : Role
    {
        public override char Symbol => _characterDic[_direction];

        public override ConsoleColor Color => ConsoleColor.DarkCyan;

        protected sealed override int InitHP { get; } = 300;

        private Direction _direction = Direction.Up;

        private static readonly Dictionary<Direction, char> _characterDic = new Dictionary<Direction, char>
        {
            { Direction.Up, '↑' },
            { Direction.Down, '↓' },
            { Direction.Left, '←' },
            { Direction.Right, '→' },
        };

        public Character() : base()
        {
            this.ResetDefaultStrategy();
        }

        public override void ResetDefaultStrategy()
        {
            this.SetAttackStrategy(new StraightLineAttackStrategy(this));
            this.SetMoveStrategy(new NormalMoveStrategy(this));
        }

        public override void Attack()
        {
            this.AttackStrategy.Attack(this._direction);
        }

        public override void Move(Direction direction = Direction.None)
        {
            this.MoveStrategy.Move(direction);
            this._direction = direction;
        }

        public override void DoAction()
        {
            var keyInfo = Console.ReadKey();
            var consoleKey = keyInfo.Key;

            if (consoleKey == ConsoleKey.UpArrow ||
                consoleKey == ConsoleKey.DownArrow ||
                consoleKey == ConsoleKey.LeftArrow ||
                consoleKey == ConsoleKey.RightArrow)
            {
                this.Move(MapDirection(consoleKey));
            }
            else if (consoleKey == ConsoleKey.A)
            {
                this.Attack();
            }
        }

        private Direction MapDirection(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                default:
                    return Direction.Up;
            }
        }
    }
}
