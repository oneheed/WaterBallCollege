using CollisionWorld.Base;

namespace CollisionWorld.Models
{
    public class World
    {
        private const int _worldsize = 30;
        private readonly int _spriteNumber = 10;

        private CollisionHandler handler;
        private Sprite[] _sprites = new Sprite[_worldsize];


        public World(CollisionHandler handler)
        {
            this.handler = handler;
        }


        public void Init()
        {
            var number = _spriteNumber;

            while (number > 0)
            {
                var random = new Random();
                var index = random.Next(30);

                if (_sprites[index] == null)
                {
                    var seed = random.Next(3);
                    _sprites[index] = seed % 3 == 0 ? new Water() : seed % 3 == 1 ? new Fire() : new Hero();
                    number--;
                }
            }

            Show();
        }


        private MoveEvent Move()
        {
            var command = Console.ReadLine();

            if (command.Contains(' '))
            {
                var commands = command.Split(' ');
                var index1 = int.TryParse(commands[0], out int result1) ? result1 : 0;
                var index2 = int.TryParse(commands[1], out int result2) ? result2 : 0;

                return new MoveEvent
                {
                    Source = _sprites[index1],
                    Target = _sprites[index2],
                };
            }

            return default;
        }

        public void Handler()
        {
            var moveEvent = Move();

            while (moveEvent != default)
            {


                var result = handler.Handler(moveEvent);
                var indexSource = Array.IndexOf(_sprites, moveEvent.Source);
                var indexTarget = Array.IndexOf(_sprites, moveEvent.Target);

                foreach (var sprite in result.RemovedSprites)
                {
                    var index = Array.IndexOf(_sprites, sprite);
                    _sprites[index] = default;
                }

                if (result.IsMove)
                {
                    _sprites[indexTarget] = default;
                    _sprites[indexTarget] = _sprites[indexSource];
                    _sprites[indexSource] = default;
                }

                Show();

                moveEvent = Move();
            }
        }

        private void Show()
        {
            var text = _sprites.Select((s, i) =>
            {
                var context = s == null ? $"" : s.ToString();

                return new { world = $"{context,3}", index = $"{i,3}" };
            });

            Console.WriteLine(string.Join("", text.Select(t => t.world)));
            Console.WriteLine(string.Join("", text.Select(t => t.index)));
        }
    }
}
