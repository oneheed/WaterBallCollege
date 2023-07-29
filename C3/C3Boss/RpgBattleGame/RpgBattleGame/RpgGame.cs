using RpgBattleGame.Models;

namespace RpgBattleGame
{
    internal class RpgGame
    {
        public Battle Battle { get; private set; }

        internal RpgGame(Battle battle)
        {
            Battle = battle;
        }

        internal void Start()
        {
            Battle.Process();

            Battle.Winner();
        }
    }
}
