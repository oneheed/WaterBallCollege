using MatchmakingSystem.Enums;
using MatchmakingSystem.Interfaces;

namespace MatchmakingSystem.Models
{
    public class Individual
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public string Intro { get; set; }

        public IList<Habit> Habits { get; set; }

        public Coord Coord { get; set; }

        public IMatchStrategy MatchStrategy { get; set; }

        public bool IsReverse { get; set; } = false;

        public Individual Match(IList<Individual> individuals)
        {
            return this.MatchStrategy.Match(this, individuals);
        }

        public override string ToString()
        {
            return $"{this.Id}:{this.Name}";
        }
    }
}
