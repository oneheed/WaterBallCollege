using System.ComponentModel.DataAnnotations;

namespace CardGame.Enums
{
    public enum SuitType
    {
        [Display(Name = "♣")]
        Clubs,

        [Display(Name = "♦")]
        Diamonds,

        [Display(Name = "♥")]
        Hearts,

        [Display(Name = "♠")]
        Spades
    }
}
