using TreasureMap.Enums;
using TreasureMap.Models.Roles;

namespace TreasureMap.Models
{
    internal class GameApp
    {
        public int Round { get; private set; } = 0;

        public Map Map { get; private set; }

        public GameApp(int width, int height, Dictionary<Type, (int Number, Func<MapObject> ConstructFunc)> initMapObjects)
        {
            Map = new Map(width, height, this, initMapObjects);
        }

        public void Start()
        {
            this.Map.InitMap();

            while (!this.GameOver())
            {
                this.Round++;
                this.Map.PrintMap();
                this.CharacterRound();
                this.MonsterRound();
            }

            Console.ReadLine();
        }

        public void CharacterRound()
        {
            var character = (Character)this.Map.RoleMapObjects[typeof(Character)][0];
            character.ActionNumber++;
            character.Action();
            character.Do();

            Console.WriteLine($"HP: {character.HP} State: {character.State.Name} Attack: {character.AttackStrategy?.Name}");
            Console.WriteLine();

            while (character.IsAction)
            {
                var keyInfo = Console.ReadKey();
                var key = keyInfo.Key;

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
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void MonsterRound()
        {
            var monsters = this.Map.RoleMapObjects[typeof(Monster)];

            foreach (var monster in monsters.Select(m => (Monster)m).ToList())
            {
                monster.ActionNumber++;
                monster.Action();
                monster.Do();

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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private bool GameOver()
        {
            Console.WriteLine();
            Console.WriteLine("Game Finish");

            return this.Map.RoleMapObjects[typeof(Character)].Count == 0 || this.Map.RoleMapObjects[typeof(Monster)].Count == 0;
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
