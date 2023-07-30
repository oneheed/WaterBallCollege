using Microservices.Logger;

namespace C4M4H1
{
    internal class Game
    {
        public Logger Logger { get; protected set; }

        public IEnumerable<Player> Players { get; private set; } = new List<Player>
        {
            new AI("AI 1"),
            new AI("AI 2"),
            new AI("AI 3"),
            new AI("AI 4"),
        };

        public Game()
        {
            this.Logger = Logger.GetLogger("app.game");
        }

        public void Start()
        {
            this.Logger.Info("The game begins.");

            // 每個 AI 玩家輪流做決策
            foreach (var ai in Players.OfType<AI>())
            {
                this.Logger.Trace($"The player {ai.Name} begins his turn.");
                ai.MakeDecision();
                this.Logger.Trace($"The player {ai.Name} finishes his turn.");
            }

            this.Logger.Debug("Game ends.");
        }
    }
}
