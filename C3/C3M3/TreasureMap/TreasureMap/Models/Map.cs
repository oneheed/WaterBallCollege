namespace TreasureMap.Models
{
    internal class Map
    {
        public int Length { get; private set; } = 10;

        public int Width { get; private set; } = 10;

        public int Round { get; private set; } = 1;

        public Dictionary<(string Name, Func<MapObject> func), int> MapObjectTable { get; private set; }

        public MapObject[] MapObjects { get; private set; }

        private Character _character;

        public Map(Dictionary<(string Name, Func<MapObject> func), int> mapObjectTable)
        {
            this.MapObjectTable = mapObjectTable;

            InitMap();
        }

        public void InitMap()
        {
            this.MapObjects = Enumerable.Range(0, this.Length * this.Width).Select(m => MapObject.Default).ToArray();

            foreach (var item in this.MapObjectTable)
            {
                for (var i = 0; i < item.Value; i++)
                {
                    var randomIndex = new Random().Next(this.MapObjects.Length);

                    if (this.MapObjects[randomIndex] == MapObject.Default)
                    {
                        this.MapObjects[randomIndex] = item.Key.func();
                        this.MapObjects[randomIndex].SetMap(this);

                        if (this.MapObjects[randomIndex] is Character)
                        {
                            _character = (Character)this.MapObjects[randomIndex];
                        }
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        public void PrintMap()
        {
            var bound = string.Join("\u3000", Enumerable.Range(0, this.Width).Select(x => "—"));

            Console.WriteLine($"\u3000{bound}\u3000");

            for (var i = 0; i < this.MapObjects.Length; i++)
            {
                var mapObject = this.MapObjects[i];
                var symbol = mapObject.Symbol.ToString();

                if ((i + 1) % this.Width == 1)
                {
                    Console.Write("｜");
                }

                Console.Write($"{symbol}｜");

                if ((i + 1) % this.Width == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\u3000{bound}\u3000");
                }
            }

            var location = this.GetMapLocation(this._character);
            Console.WriteLine($"{location.X}, {location.Y}");
        }

        private int GetMapIndex(MapObject mapObject)
            => Array.FindIndex(this.MapObjects, o => o.Equals(mapObject));

        private (int X, int Y) GetMapLocation(MapObject mapObject)
        {
            var index = this.GetMapIndex(mapObject);

            return (index / 10, index % 10);
        }
    }
}
