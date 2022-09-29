namespace TreasureMap.Models
{
    internal class Character : Role
    {
        public override char Symbol => _direction;

        protected sealed override int InitHP { get; } = 300;

        private char _direction = '↑';

        internal void Change()
        {
            var keyInfo = Console.ReadKey();
            var key = keyInfo.Key;

            if (key == ConsoleKey.UpArrow ||
                key == ConsoleKey.DownArrow ||
                key == ConsoleKey.LeftArrow ||
                key == ConsoleKey.RightArrow)
            {
                this.Move();
            }
            else if (key == ConsoleKey.A)
            {
                this.Attack();
            }
        }
    }
}
