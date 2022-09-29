namespace TreasureMap.Models
{
    internal class MapObject
    {
        public static readonly MapObject Default = new MapObject();

        public virtual char Symbol { get; } = '\u3000';

        protected Map? Map { get; private set; }

        public void SetMap(Map map)
        {
            this.Map = map;
        }

        public void Death()
        {
            if (this.Map != null)
            {
                var index = Array.FindIndex(this.Map.MapObjects, o => o.Equals(this));

                this.Map.MapObjects[index] = Default;
            }
        }
    }
}
