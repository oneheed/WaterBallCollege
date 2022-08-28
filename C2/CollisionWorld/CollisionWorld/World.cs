using CollisionWorld.Handlers;
using CollisionWorld.Sprites;

namespace CollisionWorld
{
    public class World
    {
        private const int SIZE = 30;

        private const int NUM_OF_SPRITE = 20;

        private readonly IList<Sprite> _sprites = new List<Sprite>();

        private readonly CollisionHandler _collisionHandler;

        public World(CollisionHandler collisionHandler)
        {
            this._collisionHandler = collisionHandler;
        }

        public void Generate()
        {
            var postions = Enumerable.Range(0, SIZE).ToList();
            var random = new Random();

            var generateSpriteNumber = 0;
            while (generateSpriteNumber < NUM_OF_SPRITE)
            {
                var index = random.Next(0, postions.Count);
                var postion = postions.ElementAt(index);
                postions.RemoveAt(index);

                var spriteType = random.Next(0, 3);
                var sprite = GenerateSprite(spriteType, postion);
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
                    this._collisionHandler.Collisio(collide, collided);

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

        private Sprite GenerateSprite(int spriteType, int position) => spriteType switch
        {
            0 => new Sprite("Fire", position),
            1 => new Sprite("Water", position),
            2 => new Hero(position),
            _ => Sprite.Default,
        };
    }
}