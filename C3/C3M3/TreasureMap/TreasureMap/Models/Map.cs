namespace TreasureMap.Models
{
    internal class Map
    {
        public int Length { get; private set; } = 10;

        public int Width { get; private set; } = 10;

        public int Round { get; private set; } = 1;

        public Dictionary<(string Name, Func<MapObject> func), int> MapObjectTable { get; private set; }

        public MapObject[] MapObjects { get; private set; }

        public Map(Dictionary<(string Name, Func<MapObject> func), int> mapObjectTable)
        {
            this.MapObjectTable = mapObjectTable;

            InitMap();
        }

        public void InitMap()
        {
            this.MapObjects = new MapObject[Length * Width];

            foreach (var item in this.MapObjectTable)
            {
                for (var i = 0; i < item.Value; i++)
                {
                    var randomIndex = new Random().Next(this.MapObjects.Length);

                    if (this.MapObjects[randomIndex] == null)
                    {
                        this.MapObjects[randomIndex] = item.Key.func();
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
                var symbol = "\u3000";
                if (mapObject != null)
                {
                    symbol = mapObject.Symbol.ToString();
                }

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
        }
    }
}
