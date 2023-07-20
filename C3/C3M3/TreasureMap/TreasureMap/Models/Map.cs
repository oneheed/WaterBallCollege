using TreasureMap.Models.Roles;
using TreasureMap.Models.States;

namespace TreasureMap.Models
{
    internal class Map
    {
        public GameApp GameApp { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Size => this.Width * this.Height;

        private readonly Dictionary<Type, (int Number, Func<MapObject> ConstructFunc)> _initMapObjects;

        public Dictionary<Type, List<MapObject>> RoleMapObjects { get; } = new();

        private readonly MapObject[] _mapObjects;

        public Map(int width, int height, GameApp gameApp, Dictionary<Type, (int Number, Func<MapObject> ConstructFunc)> initMapObjects)
        {
            this.Width = width;
            this.Height = height;
            this.GameApp = gameApp;

            this._initMapObjects = initMapObjects;
            this._mapObjects = Enumerable.Range(0, this.Size).Select(m => MapObject.Default).ToArray();
        }

        public void InitMap()
        {
            foreach (var item in this._initMapObjects)
            {
                this.RoleMapObjects.Add(item.Key, new List<MapObject>());

                for (var i = 0; i < item.Value.Number; i++)
                {
                    var randomIndex = new Random().Next(this._mapObjects.Length);

                    if (this._mapObjects[randomIndex] == MapObject.Default)
                    {
                        this._mapObjects[randomIndex] = item.Value.ConstructFunc();
                        this._mapObjects[randomIndex].SetMap(this);
                        this.RoleMapObjects[item.Key].Add(this._mapObjects[randomIndex]);

                        if (this._mapObjects[randomIndex] is Character character)
                        {
                            character.EnterState(new StockpileState(character));
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
            var bound = string.Join(" ", Enumerable.Range(0, this.Width).Select(x => "-"));

            Console.WriteLine($"Round {this.GameApp.Round}");
            Console.WriteLine($" {bound} ");

            for (var i = 0; i < this._mapObjects.Length; i++)
            {
                var mapObject = this._mapObjects[i];
                var symbol = mapObject.Symbol.ToString();
                var color = mapObject.Color;

                if ((i + 1) % this.Width == 1)
                {
                    Console.Write($"|");
                }

                Console.ForegroundColor = color;
                Console.Write($"{symbol}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"|");

                if ((i + 1) % this.Width == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($" {bound} ");
                }
            }
        }

        public MapObject GetMapObjectByIndex(int index)
        {
            return _mapObjects[index];
        }

        public IEnumerable<MapObject> GetMapObjectsByType(Type type)
        {
            return RoleMapObjects.TryGetValue(type, out List<MapObject> mapObjects) ? mapObjects : new List<MapObject>();
        }

        public void RemoveMapObject(MapObject mapObject)
        {
            var index = this.GetMapIndex(mapObject);

            this._mapObjects[index] = MapObject.Default;
            this.RoleMapObjects[mapObject.GetType()].Remove(mapObject);
        }

        public void MoveMapObjectByIndex(MapObject mapObject, int index)
        {
            var fromIndex = this.GetMapIndex(mapObject);
            var toIndex = index;
            var toMapObject = this._mapObjects[toIndex];

            if (mapObject is Role role &&
                toMapObject is Treasure treasure)
            {
                role.Touch(treasure);
            }
            else if (toMapObject == MapObject.Default)
            {
                this._mapObjects[fromIndex] = MapObject.Default;
                this._mapObjects[toIndex] = mapObject;
            }
        }

        public (int X, int Y) GetMapLocation(MapObject mapObject)
        {
            var index = this.GetMapIndex(mapObject);

            return (index / this.Width, index % this.Width);
        }

        public int GetMapIndexByOffset(MapObject mapObject, (int X, int Y) locationOffset)
        {
            var fromIndex = this.GetMapIndex(mapObject);
            var index = fromIndex + (this.Width * locationOffset.Y + locationOffset.X);

            if (index >= this.Size || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(locationOffset), "Can't get mapObject");
            }

            return index;
        }

        public int GetMapIndex(MapObject mapObject)
            => Array.FindIndex(this._mapObjects, o => o.Equals(mapObject));

        public (int UpBoundIndex, int DownBoundIndex, int LeftBoundIndex, int RightBoundIndex) GetBoundIndex(MapObject mapObject)
        {
            var fromIndex = this.GetMapIndex(mapObject);

            var heightIndex = fromIndex / this.Width;

            var upBoundIndex = fromIndex - (heightIndex * this.Width);
            var downBoundIndex = fromIndex + ((this.Height - heightIndex - 1) * this.Width);

            var leftBoundIndex = heightIndex * this.Width;
            var rightBoundIndex = (heightIndex + 1) * this.Width - 1;

            return (upBoundIndex, downBoundIndex, leftBoundIndex, rightBoundIndex);
        }
    }
}
