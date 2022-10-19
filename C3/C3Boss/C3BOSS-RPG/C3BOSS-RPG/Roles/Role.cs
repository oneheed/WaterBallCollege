using C3BOSS_RPG.Skills;
using C3BOSS_RPG.States;

namespace C3BOSS_RPG.Roles
{
    internal class Role
    {
        public virtual int HP { get; private set; }

        public virtual int MP { get; private set; }

        public virtual int STR { get; private set; }

        public string Name { get; private set; }

        public State State { get; private set; }

        public List<Skill> Skills { get; } = new List<Skill>
        {
            new BasicAttack(),
        };

        public Role(int hp, int mp, int str, string name, IEnumerable<Skill> skills)
        {
            this.HP = hp;
            this.MP = mp;
            this.STR = str;
            this.Name = name;
            this.State = new NormalState(this);

            this.Skills.AddRange(skills);
        }

        public bool Dead() => this.HP <= 0;

        public bool Alive() => !this.Dead();

        public void Damage(int unit)
        {
            unit = State.CalDamage(unit);

            this.HP -= unit;
        }

        public void Healing(int unit)
        {
            unit = State.CalHealing(unit);

            this.HP += unit;
        }

        public void ChangeState(State state)
        {
            this.State.ExitState();
            this.State = state;
            this.State.EnterState();
        }
    }
}
