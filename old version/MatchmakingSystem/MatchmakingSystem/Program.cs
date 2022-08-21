// See https://aka.ms/new-console-template for more information
using MatchmakingSystem.Enums;
using MatchmakingSystem.Models;

var individuals = new List<Individual>
{
    new Individual
    {
        Id = 1,
        Name = "John",
        Gender = Gender.MALE,
        Age = 20,
        Intro = "",
        Habits = new List<Habit>
        {
            new Habit { Name = "橄欖球" },
            new Habit { Name = "游泳" },
            new Habit { Name = "閱讀" },
        },
        Coord = new Coord
        {
            X = 1,
            Y = 1
        },
        MatchStrategy = new DistanceMatchStrategy(),
    },
    new Individual
    {
        Id = 3,
        Name = "Jack",
        Gender = Gender.FEMALE,
        Age = 20,
        Intro = "Hi Jack",
        Habits = new List<Habit>
        {
            new Habit { Name = "籃球" },
            new Habit { Name = "閱讀" },
        },
        Coord = new Coord
        {
            X = 1,
            Y = 1
        },
        MatchStrategy = new HabitMatchStrategy(),
    },
    new Individual
    {
        Id = 2,
        Name = "Len",
        Gender = Gender.FEMALE,
        Age = 20,
        Intro = "Hi Len",
        Habits = new List<Habit>
        {
            new Habit { Name = "羽球" },
            new Habit { Name = "游泳" },
        },
        Coord = new Coord
        {
            X = 2,
            Y = 2
        },
        MatchStrategy = new DistanceMatchStrategy(),
    },
    new Individual
    {
        Id = 4,
        Name = "Josh",
        Gender = Gender.FEMALE,
        Age = 39,
        Intro = "Hi Josh",
        Habits = new List<Habit>
        {
            new Habit { Name = "爬山" },
            new Habit { Name = "看星星" },
            new Habit { Name = "籃球" },
            new Habit { Name = "閱讀" },
        },
        Coord = new Coord
        {
            X = 4,
            Y = 4
        },
        MatchStrategy = new DistanceMatchStrategy(),
        IsReverse = true,
    },
    new Individual
    {
        Id = 5,
        Name = "Li Li",
        Gender = Gender.FEMALE,
        Age = 20,
        Intro = "Hi Li Li",
        Habits = new List<Habit>
        {
            new Habit { Name = "羽球" },
            new Habit { Name = "游泳" },
            new Habit { Name = "閱讀" },
        },
        Coord = new Coord
        {
            X = 2,
            Y = 2
        },
        MatchStrategy = new HabitMatchStrategy(),
        IsReverse = true,
    },
};

var matchmakingSystem = new MatchmakingGame(individuals);
matchmakingSystem.Match();
