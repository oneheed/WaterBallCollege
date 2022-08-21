using CollisionWorld.Base;

namespace CollisionWorld.Models
{
    public class Hero : Sprite
    {
        private int Hp = 30;

        public void ControlHp(int hp)
        {
            this.Hp = this.Hp + hp;
        }

        public bool Dead()
        {
            return Hp <= 0;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
