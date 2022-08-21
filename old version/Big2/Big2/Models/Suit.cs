using Big2.Enums;

namespace Big2.Models
{
    public class Suit
    {
        protected IDictionary<SuitType, string> _nameDictionary = new Dictionary<SuitType, string>
        {
            { SuitType.Clubs, "C" },
            { SuitType.Diamonds, "D" },
            { SuitType.Hearts, "H" },
            { SuitType.Spades, "S" },
        };

        public SuitType Type { get; private set; }

        public Suit(int index)
        {
            this.Type = (SuitType)index;
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
