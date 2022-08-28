namespace CollisionWorld.Sprites
{
    public class Hero : Sprite
    {
        public int HP { get; private set; } = 30;

        public Hero(int position) : base("Hero", position)
        {
        }

        public bool IsDead => HP <= 0;

        public void Damage(int damage)
        {
            this.HP -= damage;
            this._world?.Message($"{this.Name} 受 {damage} 傷害!");

            if (this.IsDead)
            {
                this._world?.Message($"{this.Name} 死亡!");
                this.RemovedFromWorld();
            }
        }

        public void Cure(int cure)
        {
            this.HP += cure;

            this._world?.Message($"{this.Name} 被治療 {cure}HP!");
        }
    }
}
