using Big2.Base;

namespace Big2.Models
{
    public class Hand
    {
        public IList<Card> Cards { get; set; } = new List<Card>();
    }
}
