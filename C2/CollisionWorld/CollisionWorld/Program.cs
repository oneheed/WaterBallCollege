﻿// See https://aka.ms/new-console-template for more information
using CollisionWorld;
using CollisionWorld.Handlers;

Console.WriteLine("Hello, World!");

var world = new World(
    new WaterAndFireCollisionHandler(
        new HeroAndFireCollisionHandler(
            new HeroAndWaterCollisionHandler(
                new SameCollisionHandler(null)))));

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