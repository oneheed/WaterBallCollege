using System.ComponentModel.DataAnnotations;

namespace Big2.Enums
{
    public enum Pattern
    {
        [Display(Name = "不合法")]
        Illegal = -1,

        [Display(Name = "單張")]
        Single = 0,

        [Display(Name = "對子")]
        Pair,

        [Display(Name = "順子")]
        Straight,

        [Display(Name = "葫蘆")]
        FullHouse,
    }
}
