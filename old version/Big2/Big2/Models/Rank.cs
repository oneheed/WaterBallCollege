using Big2.Enums;

namespace Big2.Models
{
    public class Rank
    {
        protected IDictionary<RankType, string> _nameDictionary = new Dictionary<RankType, string>
        {
            { RankType.Ace, "A" },
            { RankType.Two, "2" },
            { RankType.Three, "3" },
            { RankType.Four, "4" },
            { RankType.Five, "5" },
            { RankType.Six, "6" },
            { RankType.Seven, "7" },
            { RankType.Eight, "8" },
            { RankType.Nine, "9" },
            { RankType.Ten, "10" },
            { RankType.Jack, "J" },
            { RankType.Queen, "Q" },
            { RankType.King, "K" },
        };

        public RankType Type { get; private set; }

        public Rank(int index)
        {
            this.Type = (RankType)index;
        }

        public string Name
        {
            get
            {
                return _nameDictionary[this.Type];
            }
        }

        public int Number
        {
            get
            {
                return (int)this.Type;
            }
        }
    }
}
