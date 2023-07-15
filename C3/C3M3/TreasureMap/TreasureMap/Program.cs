// See https://aka.ms/new-console-template for more information
using TreasureMap.Helpers;
using TreasureMap.Models;
using TreasureMap.Models.Roles;
using TreasureMap.Models.States;

var treasureTable = new Dictionary<string, (int Number, Func<Role, State> StateConstructFunc)>
{
    { "Super Sta", new(10, role => new InvincibleState(role)) },
    { "Poison", new(25, role => new PoisonedState(role)) },
    { "Accelerating Potion", new(20, role => new AcceleratedState(role)) },
    { "Healing Potion", new(15, role => new HealingState(role)) },
    { "Devil Fruit", new(10, role => new OrderlessState(role)) },
    { "King's Rock", new(10, role => new StockpileState(role)) },
    { "Dokodemo Door", new(10, role => new TeleportState(role)) },
};

var mapObjectTable = new Dictionary<Type, (int Number, Func<MapObject> ConstructFunc)>
{
    { typeof(Character), new(1, () => new Character()) },
    { typeof(Monster), new(15, () => new Monster()) },
    { typeof(Obstacle), new(10, () => new Obstacle()) },
    { typeof(Treasure), new(15, () => new TreasureHelper(treasureTable).GenerateTreasure()) },
};

var map = new Map(10, 10, mapObjectTable);
map.PrintMap();
map.Start();