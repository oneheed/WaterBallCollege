using Big2.Models;

namespace Big2.Strategies
{
    public class TestAIStrategy : AIStrategy
    {
        private IEnumerator<string> _commands;

        public TestAIStrategy(IEnumerator<string> commands)
        {
            _commands = commands;
        }

        public override IList<Card> Play()
        {
            if (_commands.MoveNext())
            {
                var command = _commands.Current;

                var indexs = command.Trim().Split(" ").Select(c => int.Parse(c)).ToList();

                return this.aiPlayer.Hand.Play(indexs);
            }
            else
            {
                return new List<Card>();
            }
        }
    }
}
