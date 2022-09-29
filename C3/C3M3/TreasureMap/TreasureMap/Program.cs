// See https://aka.ms/new-console-template for more information
using TreasureMap.Models;
using TreasureMap.Models.States;

var treasureTable = new Dictionary<(string Name, Func<Role, State> func), int>
{
    { new("Super Sta", role => new InvincibleState(role)) , 10 },
    { new("Poison", role => new PoisonedState(role)) , 25 },
    { new("Accelerating Potion", role => new AcceleratedState(role)) , 20 },
    { new("Healing Potion", role => new HealingState(role)) , 15 },
    { new("Devil Fruit", role => new OrderlessState(role)) , 10 },
    { new("King's Rock", role => new StockpileState(role)) , 10 },
    { new("Dokodemo Door", role => new TeleportState(role)) , 10 },
};

var treasures = new List<Treasure>();
foreach (var item in treasureTable)
{
    for (var i = 0; i < item.Value; i++)
    {
        treasures.Add(new Treasure(item.Key.Name, item.Key.func));
    }
}

var getTreasure = () =>
{
    var randomNumber = new Random().Next(treasures.Count);
    var treasure = treasures[randomNumber];
    treasures.Remove(treasure);

    return treasure;
};

var mapObjectTable = new Dictionary<(string Name, Func<MapObject> func), int>
{
    { new("Character", () => new Character()) , 1 },
    { new("Monster", () => new Monster()) , 15 },
    { new("Obstacle", () => new Obstacle()) , 10 },
    { new("Treasure", () => getTreasure()), 15 },
};

var map = new Map(mapObjectTable);
map.PrintMap();
