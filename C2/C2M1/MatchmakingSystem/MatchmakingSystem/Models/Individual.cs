﻿using MatchmakingSystem.Enums;
using MatchmakingSystem.Strategies;

namespace MatchmakingSystem.Models
{
    internal class Individual
    {
        public int Id { get; private set; }

        public Gender Gender { get; private set; }

        public int Age { get; private set; }

        public string Intro { get; private set; }


        public HashSet<string> Habits { get; private set; }

        public Coordinate Coordinate { get; private set; }


        public IMatchStrategy MathStrategy { get; private set; }


        public Individual(int id, Gender gender, int age, string intro, HashSet<string> habits, Coordinate coordinate, IMatchStrategy mathStrategy)
        {
            Id = id;
            Age = age;
            Gender = gender;
            Intro = intro;
            Habits = habits;
            Coordinate = coordinate;
            MathStrategy = mathStrategy;
        }

        public string GetHabits()
        {
            return string.Join(",", Habits);
        }

        public IEnumerable<Individual> Math(IEnumerable<Individual> paired)
        {
            return MathStrategy.Match(this, paired).ToList();
        }
    }
}
