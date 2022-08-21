using CardGame.Models;

namespace CardGame.Base
{
    public abstract class Player
    {
        public string Name { get; set; }

        public int Point { get; set; }

        public Hand Hand { get; set; } = new Hand();

        public void Namehimself(string name)
        {
            Name = name;
        }

        public abstract Card Play();
    }
}
