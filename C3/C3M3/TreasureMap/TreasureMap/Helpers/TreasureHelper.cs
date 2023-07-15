using TreasureMap.Models;
using TreasureMap.Models.Roles;
using TreasureMap.Models.States;

namespace TreasureMap.Helpers
{
    internal class TreasureHelper
    {
        private readonly IList<Treasure> _treasures = new List<Treasure>();

        public TreasureHelper(Dictionary<string, (int Number, Func<Role, State> StateConstructFunc)> treasureTable)
        {
            foreach (var item in treasureTable)
            {
                for (var i = 0; i < item.Value.Number; i++)
                {
                    _treasures.Add(new Treasure(item.Key, item.Value.StateConstructFunc));
                }
            }
        }

        public Treasure GenerateTreasure()
        {
            var randomIndex = new Random().Next(_treasures.Count);

            var treasure = _treasures[randomIndex];
            _treasures.Remove(treasure);

            return treasure;
        }
    }
}
