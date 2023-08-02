using LoggingFramework.Loggers;

namespace LoggingFramework
{
    internal class AI : Player
    {
        public AI(string name)
        {
            this.Name = name;
        }

        public void MakeDecision()
        {
            var logger = Logger.GetLogger("app.game.ai");

            logger.Trace($"{this.Name} starts making decisions...");

            logger.Warn($"{this.Name} decides to give up.");
            logger.Error("Something goes wrong when AI gives up.");

            logger.Trace($"{this.Name} completes its decision.");
        }
    }
}
