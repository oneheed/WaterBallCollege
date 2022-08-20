using System.ComponentModel.DataAnnotations;

namespace Showdown.Enums
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