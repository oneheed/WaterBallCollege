using CollisionWorld.Handlers;
using CollisionWorld.Sprites;

namespace CollisionWorld
{
    public class World
    {
        private const int SIZE = 30;

        private const int NUM_OF_SPRITE = 10;

        private readonly IList<Func<int, Sprite>> _generateSpriteTypes;

        private readonly IList<Sprite> _sprites = new List<Sprite>();

        private readonly CollisionHandler _collisionHandler;

        public World(CollisionHandler collisionHandler, IList<Func<int, Sprite>> generateSpriteTypes)
        {

            this._collisionHandler = collisionHandler;
            this._generateSpriteTypes = generateSpriteTypes;
        }

        public void Generate()
        {

            var positions = Enumerable.Range(0, SIZE).ToList();
            var random = new Random();

            var generateSpriteNumber = 0;
            while (generateSpriteNumber < NUM_OF_SPRITE)
            {
                var index = random.Next(0, positions.Count);
                var position = positions.ElementAt(index);
                positions.RemoveAt(index);

                var spriteTypeIndex = random.Next(0, _generateSpriteTypes.Count);
                var sprite = _generateSpriteTypes[spriteTypeIndex](position);

                sprite.SetWorld(this);

                _sprites.Add(sprite);

                generateSpriteNumber++;
            }
        }

        public void Print()
        {
            var text = Enumerable.Range(0, SIZE).Select((position) =>
            {
                var sprite = GetSpriteByPosition(position);

                return new { SpriteSymbol = $"{sprite.Symbol,3}", Position = $"{position,3}" };
            });

            Console.WriteLine(string.Join("", text.Select(t => t.SpriteSymbol)));
            Console.WriteLine(string.Join("", text.Select(t => t.Position)));
        }

        public void Move(int form, int to)
        {
            var collide = GetSpriteByPosition(form);
            var collided = GetSpriteByPosition(to);

            if (collide.Name == Sprite.Default.Name)
            {
                Console.WriteLine($"錯誤的指令");
            }
            else
            {
                try
                {
                    this._collisionHandler.Collision(collide, collided);

                    if (collide.SetPosition(to))
                    {
                        Console.WriteLine($"{collide.Name} 移動成功");
                    }
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"{collide.Name} 和 {collided.Name} 移動失敗");
                }
            }
        }

        public void Remove(Sprite sprite)
        {
            Console.WriteLine($"{sprite.Name} 從世界中被移除");

            _sprites.Remove(sprite);
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public Sprite GetSpriteByPosition(int position)
        {
            return _sprites.FirstOrDefault(s => s.Position == position) ?? Sprite.Default;
        }
    }
}