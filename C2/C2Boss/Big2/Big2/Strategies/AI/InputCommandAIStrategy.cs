using Big2.Models;

namespace Big2.Strategies.AI
{
    public class InputCommandAIStrategy : AIStrategy
    {
        private IEnumerator<string> _commands;

        public InputCommandAIStrategy(IEnumerator<string> commands)
        {
            _commands = commands;
        }

        public override IList<Card> Play()
        {
            if (_commands.MoveNext())
            {
                var command = _commands.Current;

                var indexs = command.Trim().Split(" ").Select(c => int.Parse(c)).ToList();

                return aiPlayer.Hand.Play(indexs);
            }
            else
            {
                return new List<Card>();
            }
        }
    }
}
