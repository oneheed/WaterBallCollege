using CardGame.Base;

namespace CardGame.Models
{
    public class Hand
    {
        public IList<Card> Cards { get; set; } = new List<Card>();
    }
}