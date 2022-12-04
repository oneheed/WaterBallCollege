namespace C4M4H1
{
    internal class Player
    {
        private Logger log { get; set; }

        internal void makeDecision()
        {
            log.trace("{name} starts making decisions...");

            log.warn("{name} decides to give up.");
            log.error("Something goes wrong when AI gives up.");

            log.trace("{name} completes its decision.");
        }

        getName()
        {
            return name;
        }
    }
}