namespace TreasureMap.Models
{
    internal class Treasure : MapObject
    {
        public override char Symbol => '〤';

        public string Name { get; private set; }

        public Func<Role, State> StateFunc { get; private set; }

        public Treasure(string name, Func<Role, State> stateFunc)
        {
            this.Name = name;
            this.StateFunc = stateFunc;
        }
    }
}
