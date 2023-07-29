namespace Big2.Models
{
    public class HumanPlayer : Player
    {
        public override IList<Card> Play()
        {
            var command = Console.ReadLine();
            var indexs = new List<int>();

            if (!string.IsNullOrWhiteSpace(command))
            {
                indexs = command.Split(" ")
                    .Where(i => int.TryParse(i, out _))
                    .Select(i => int.Parse(i))
                    .ToList();
            }

            if (indexs.Any())
            {
                return this.Hand.Play(indexs);
            }
            else
            {
                Console.WriteLine("輸入錯誤, 請重新輸入");

                return Play();
            }
        }
    }
}
