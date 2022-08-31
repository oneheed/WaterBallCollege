namespace Big2.Models
{
    public class NewRoundMustNotPassException : NotSupportedException
    {
        public NewRoundMustNotPassException() : base("你不能在新的回合中喊 PASS")
        {
        }
    }
}
