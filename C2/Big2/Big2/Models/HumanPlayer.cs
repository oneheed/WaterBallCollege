namespace Big2.Models
{
    public class HumanPlayer : Player
    {
        public override IList<Card> Play()
        {
            Console.WriteLine(this.Hand.ShowAllCard());

            var command = Console.ReadLine();

            if (int.TryParse(command, out int index) && index < this.Hand.Count)
            {
                return this.Hand.ShowCard(index);
            }
            else
            {
                Console.WriteLine("輸入錯誤, 請重新輸入");

                return Play();
            }
        }
    }
}
