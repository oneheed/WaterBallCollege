using System.ComponentModel.DataAnnotations;

namespace ShowdownGame.Enums
{
    public enum SuitType
    {
        [Display(Name = "梅花")]
        Clubs,

        [Display(Name = "方塊")]
        Diamonds,

        [Display(Name = "紅心")]
        Hearts,

        [Display(Name = "黑桃")]
        Spades
    }
}