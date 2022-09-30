namespace TreasureMap.Models
{
    internal class MapObject
    {
        public static readonly MapObject Default = new MapObject();

        public virtual char Symbol { get; } = '\u3000';

        public Map? Map { get; private set; }

        public void SetMap(Map map)
        {
            this.Map = map;
        }

        public int GetMapIndex()
        {
            if (this.Map != null)
            {
                return this.Map.GetMapIndex(this);
            }

            return -1;
        }

        public void Death()
        {
            if (this.Map != null)
            {
                this.Map.RemoveMapObject(this);
            }
        }
    }
}
