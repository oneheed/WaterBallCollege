namespace TreasureMap.Models
{
    internal class MapObject
    {
        public static readonly MapObject Default = new();

        public virtual char Symbol { get; } = ' ';

        public Map? Map { get; private set; }

        public void SetMap(Map map)
        {
            this.Map = map;
        }

        public int GetMapIndex()
        {
            return this.Map != null ? this.Map.GetMapIndex(this) : -1;
        }
    }
}
