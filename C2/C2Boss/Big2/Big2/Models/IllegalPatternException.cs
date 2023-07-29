namespace Big2.Models
{
    public class IllegalPatternException : NotSupportedException
    {
        public IllegalPatternException() : base("此牌型不合法，請再嘗試一次。")
        {
        }
    }
}
