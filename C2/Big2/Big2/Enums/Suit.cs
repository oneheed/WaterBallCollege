using System.ComponentModel.DataAnnotations;

namespace Big2.Enums
{
    public enum Suit
    {
        [Display(Name = "C")]
        Club,

        [Display(Name = "D")]
        Diamond,

        [Display(Name = "H")]
        Heart,

        [Display(Name = "S")]
        Spade
    }
}
