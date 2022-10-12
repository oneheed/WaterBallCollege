using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Models
{
    internal class Map
    {
        public int Round { get; private set; } = 0;

        public int Width { get; private set; } = 10;

        public int Height { get; private set; } = 10;

        public int Size => this.Width * this.Height;

        private readonly Dictionary<Type, (int Number, Func<MapObject> ConstructFunc)> _mapObjectTable;

        private readonly Dictionary<Type, List<MapObject>> _mapObjectDic = new Dictionary<Type, List<MapObject>>();

        private readonly MapObject[] _mapObjects;

        public Map(int width, int height, Dictionary<Type, (int Number, Func<MapObject> ConstructFunc)> mapObjectTable)
        {
            this.Width = width;
            this.Height = height;

            this._mapObjectTable = mapObjectTable;
            this._mapObjects = Enumerable.Range(0, this.Size).Select(m => MapObject.Default).ToArray();

            InitMap();
        }

        public void InitMap()
        {
            foreach (var item in this._mapObjectTable)
            {
                this._mapObjectDic.Add(item.Key, new List<MapObject>());

                for (var i = 0; i < item.Value.Number; i++)
                {
                    var randomIndex = new Random().Next(this._mapObjects.Length);

                    if (this._mapObjects[randomIndex] == MapObject.Default)
                    {
                        this._mapObjects[randomIndex] = item.Value.ConstructFunc();
                        this._mapObjects[randomIndex].SetMap(this);
                        this._mapObjectDic[item.Key].Add(this._mapObjects[randomIndex]);

                        if (this._mapObjects[randomIndex] is Character character)
                        {
                            //character.EnterState(new AcceleratedState(character));
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

            Console.WriteLine($"Round {this.Round}");
            Console.WriteLine($"\u3000{bound}\u3000");

            for (var i = 0; i < this._mapObjects.Length; i++)
            {
                var mapObject = this._mapObjects[i];
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
        }

        public void Start()
        {
            while (!this.Gameover())
            {
                this.Round++;

                this.CharacterRound();
                this.MonsterRound();
            }
        }

        public void CharacterRound()
        {
            var character = (Character)_mapObjectDic[typeof(Character)].First();
            character.ActionNumber++;
            character.Action();

            while (character.IsAction)
            {
                var keyInfo = Console.ReadKey();
                var key = keyInfo.Key;
                Console.WriteLine();
                try
                {
                    if (key == ConsoleKey.UpArrow ||
                        key == ConsoleKey.DownArrow ||
                        key == ConsoleKey.LeftArrow ||
                        key == ConsoleKey.RightArrow)
                    {
                        character.Move(MapDirection(key));
                    }
                    else if (key == ConsoleKey.A)
                    {
                        character.Attack();
                    }

                    character.ActionNumber--;
                    PrintMap();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                }
            }

            character.Do();
        }

        public void MonsterRound()
        {
            var monsters = _mapObjectDic[typeof(Monster)];

            foreach (var monster in monsters.Select(m => (Monster)m).ToList())
            {
                monster.ActionNumber++;
                monster.Action();

                while (monster.IsAction)
                {
                    try
                    {
                        monster.DoAction();
                        monster.ActionNumber--;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception)
                    {
                    }
                }

                monster.Do();
            }

            PrintMap();
        }

        private bool Gameover()
        {
            return this._mapObjectDic[typeof(Character)].Count == 0 || this._mapObjectDic[typeof(Monster)].Count == 0;
        }

        public MapObject GetMapObjectByIndex(int index)
        {
            return _mapObjects[index];
        }

        public IEnumerable<MapObject> GetMapObjectsByType(Type type)
        {
            return _mapObjectDic.TryGetValue(type, out List<MapObject> mapObjects) ? mapObjects : new List<MapObject>();
        }

        public void RemoveMapObject(MapObject mapObject)
        {
            var index = this.GetMapIndex(mapObject);

            this._mapObjects[index] = MapObject.Default;
            this._mapObjectDic[mapObject.GetType()].Remove(mapObject);
        }


        public void MoveMapObjectByIndex(MapObject mapObject, int index)
        {
            var fromIndex = this.GetMapIndex(mapObject);
            var toIndex = index;
            var toMapObject = this._mapObjects[toIndex];

            if (mapObject is Role role &&
                toMapObject is Treasure treasure)
            {
                Console.WriteLine($"Get {treasure.Name}");
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
                throw new ArgumentOutOfRangeException();
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
