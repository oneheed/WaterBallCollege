// See https://aka.ms/new-console-template for more information
using CollisionWorld.Models;

var world = new World(new WaterCollisionHandler(new FireCollisionHandler(new HeroCollisionHandler(null))));

world.Init();
world.Handler();