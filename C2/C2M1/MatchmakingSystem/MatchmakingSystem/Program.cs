﻿// See https://aka.ms/new-console-template for more information
using MatchmakingSystem.Enums;
using MatchmakingSystem.Models;
using MatchmakingSystem.Strategies;

var individuals = new List<Individual>
{
    new Individual(1, Gender.FEMALE, 20, "火球1", new HashSet<string> { "吃飯", "睡覺", "打咚咚" }, new Coordinate(1,1), new DistanceBasedStrategy()),
    new Individual(2, Gender.MALE, 24, "火球2", new HashSet<string> { "吃飯", "煮菜" }, new Coordinate(2,2), new ReverseStrategy(new DistanceBasedStrategy())),
    new Individual(4, Gender.MALE, 21, "火球4", new HashSet<string> { "打籃球", "煮菜" }, new Coordinate(4,4), new HabitBasedStrategy()),
    new Individual(3, Gender.MALE, 25, "火球3", new HashSet<string> { "打籃球", "煮菜" }, new Coordinate(3,3), new DistanceBasedStrategy()),
};

var app = new MatchmakingApp(individuals);
app.Start();