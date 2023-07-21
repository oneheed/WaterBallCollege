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

        private static readonly Dictionary<Direction, char> _characterDic = new()
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
            return consoleKey switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => Direction.Up,
            };
        }
    }
}
