namespace CardGame.Models
{
    public class HumanPlayer : Player
    {
        public override void NameHimself()
        {
            Console.WriteLine("請重新輸入姓名");

            this.Name = Console.ReadLine();
        }

        public override Card Showdown()
        {
            Console.WriteLine(this.Hand.ShowAllCard());

            var command = Console.ReadLine();

            if (int.TryParse(command, out int index) && index < this.Hand.Count)
            {
                return this.Hand.Showdown(index);
            }
            else
            {
                Console.WriteLine("輸入錯誤, 請重新輸入");

                return Showdown();
            }
        }
    }
}
