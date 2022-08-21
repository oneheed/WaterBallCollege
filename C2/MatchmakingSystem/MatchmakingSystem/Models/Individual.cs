using MatchmakingSystem.Enums;

namespace MatchmakingSystem.Models
{
    public class Individual
    {
        public int Id { get; private set; }

        public Gender Gender { get; private set; }

        public int Age { get; private set; }

        public string Intro { get; private set; }


        public HashSet<string> Habits { get; private set; }

        public Coord Coord { get; private set; }


        public IMathStrategy MathStrategy { get; private set; }


        public Individual(int id, Gender gender, int age, string intro, HashSet<string> habits, Coord coord, IMathStrategy mathStrategy)
        {
            Id = id;
            Age = age;
            Gender = gender;
            Intro = intro;
            Habits = habits;
            Coord = coord;
            MathStrategy = mathStrategy;
        }

        public string GetHabits()
        {
            return string.Join(",", Habits);
        }

        public IList<Individual> Math(IList<Individual> paired)
        {
            return MathStrategy.Math(this, paired);
        }
    }
}
