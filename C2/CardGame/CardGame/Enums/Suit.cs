using System.ComponentModel.DataAnnotations;

namespace CardGame.Enums
{
    public enum Suit
    {
        [Display(Name = "♣")]
        Club,

        [Display(Name = "♦")]
        Diamond,

        [Display(Name = "♥")]
        Heart,

        [Display(Name = "♠")]
        Spade
    }
}