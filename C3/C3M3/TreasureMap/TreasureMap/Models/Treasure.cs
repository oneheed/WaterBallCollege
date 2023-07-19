using TreasureMap.Models.Roles;
using TreasureMap.Models.States;

namespace TreasureMap.Models
{
    internal class Treasure : MapObject
    {
        public override char Symbol => 'x';

        public string Name { get; private set; }

        public Func<Role, State> StateFunc { get; private set; }

        public Treasure(string name, Func<Role, State> stateFunc)
        {
            this.Name = name;
            this.StateFunc = stateFunc;
        }

        public State Touched(Role role)
        {
            this.Map?.RemoveMapObject(this);

            return this.StateFunc(role);
        }
    }
}
