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
                this.TakeRound();
            }

            Console.ReadLine();
        }

        public void TakeRound()
        {
            foreach (var roles in this.Map.RoleMapObjects.Where(r => r.Key.IsSubclassOf(typeof(Role))).Select(r => r.Value))
            {
                foreach (var role in roles.OfType<Role>().ToArray())
                {
                    role.ActionNumber++;
                    role.Action();
                    role.Do();

                    if (role is Character character)
                    {
                        Console.WriteLine($"HP: {character.HP} State: {character.State.Name} Attack: {character.AttackStrategy?.Name}");
                        Console.WriteLine();
                    }

                    while (role.IsAction)
                    {
                        try
                        {
                            role.DoAction();
                            role.ActionNumber--;
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
        }

        private bool GameOver()
        {
            Console.WriteLine();
            Console.WriteLine("Game Finish");

            return this.Map.RoleMapObjects[typeof(Character)].Count == 0 || this.Map.RoleMapObjects[typeof(Monster)].Count == 0;
        }
    }
}