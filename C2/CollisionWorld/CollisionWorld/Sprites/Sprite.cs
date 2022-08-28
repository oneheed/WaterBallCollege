namespace CollisionWorld.Sprites
{
    public class Sprite
    {
        protected World? _world;

        public string Name { get; private set; }

        public string Symbol => Name[0..1];

        public int Position { get; private set; }

        public static readonly Sprite Default = new Sprite("-", -1);

        public Sprite(string name, int position)
        {
            Name = name;
            Position = position;
        }

        public void SetWorld(World world)
        {
            _world = world;
        }

        public bool SetPosition(int position)
        {
            Position = position;

            return this._world != null;
        }

        public void RemovedFromWorld()
        {
            this._world?.Remove(this);
            this._world = null;
        }
    }
}
