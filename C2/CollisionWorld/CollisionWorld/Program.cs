// See https://aka.ms/new-console-template for more information
using CollisionWorld;
using CollisionWorld.Handlers;
using CollisionWorld.Sprites;

Console.WriteLine("Hello, World!");

var generateSpriteTypes = new List<Func<int, Sprite>>
{
    { (position) => new Sprite("Fire", position) },
    { (position) => new Sprite("Water", position) },
    { (position) => new Hero(position) },
};

var collisionHandler = new WaterAndFireCollisionHandler(new HeroAndFireCollisionHandler(new HeroAndWaterCollisionHandler(new SameCollisionHandler(null))));

var world = new World(collisionHandler, generateSpriteTypes);

world.Generate();
while (true)
{
    world.Print();

    Console.WriteLine("輸入兩個數字 x1 x2");
    var command = Console.ReadLine() ?? string.Empty;

    if (command.Contains(' '))
    {
        var commands = command.Split(' ');
        var form = int.TryParse(commands[0], out int result1) ? result1 : 0;
        var to = int.TryParse(commands[1], out int result2) ? result2 : 0;

        world.Move(form, to);
    }
}