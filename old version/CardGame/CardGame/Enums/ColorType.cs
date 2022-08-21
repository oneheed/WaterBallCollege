using System.ComponentModel.DataAnnotations;

namespace CardGame.Enums
{
    public enum ColorType
    {
        [Display(Name = "藍色")]
        BLUE,

        [Display(Name = "紅色")]
        RED,

        [Display(Name = "黃色")]
        YELLOW,

        [Display(Name = "綠色")]
        GREEN,
    }
}
