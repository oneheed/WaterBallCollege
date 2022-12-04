namespace C4M4H1
{
    internal class Game
    {
        private Logger log { get; set; }

        private IEnumerable<Player> players { get; set; }

        public void Start()
        {
            log.info("The game begins.");

            // 每個 AI 玩家輪流做決策
            foreach (var ai in players)
            {
                log.trace("The player {ai.getName()} begins his turn.");
                ai.makeDecision();
                log.trace("The player {ai.getName()} finishes his turn.");
            }
        }
    }
}
