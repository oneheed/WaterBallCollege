using C3BOSS_RPG.Skills;
using C3BOSS_RPG.States;
using C3BOSS_RPG.Strategies;

namespace C3BOSS_RPG.Roles
{
    internal class Role
    {
        private Troop? _troop;

        public virtual int HP { get; private set; }

        public virtual int MP { get; private set; }

        public virtual int STR { get; private set; }

        private string _name;
        public string Name
        {
            get => $"{this._troop.Symbol}{this._name}";
            private set => _name = value;
        }

        public State State { get; private set; }

        protected AIStrategy _aiStrategy;

        protected DeadStrategy _deadStrategy;

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

            this._aiStrategy = this._aiStrategy ?? new NormalAIStrategy(this);

            this.Skills.AddRange(skills);
        }

        internal void SetTroop(Troop troop)
        {
            this._troop = troop;
        }

        internal Troop GetTroop()
        {
            return this._troop;
        }

        public bool Dead() => this.HP <= 0;

        public bool Alive() => !this.Dead();

        public void Damage(Role caster, int unit)
        {
            if (caster != null)
            {
                unit = caster.State.CalDamage(unit);
            }

            this.HP -= unit;

            if (caster != null)
            {
                Console.WriteLine($"{caster.Name} 對 {this.Name} 造成 {unit} 點傷害。");
            }

            if (Dead())
            {
                if (this._deadStrategy != null)
                {
                    _deadStrategy.Execute(this);
                }

                Console.WriteLine($"{this.Name} 死亡。");
            }
        }

        internal void Suicide()
        {
            this.HP = 0;
            Console.WriteLine($"{this.Name} 死亡。");
        }

        public void Healing(int unit)
        {
            unit = State.CalHealing(unit);

            this.HP += unit;
        }

        public void ConsumeMP(int unit)
        {
            this.MP -= unit;
        }

        public void ChangeState(State state)
        {
            this.State.ExitState();
            this.State = state;
            this.State.EnterState();
        }

        public Skill ChangeAction()
        {
            return this._aiStrategy.ChangeAction();
        }

        internal void SetDeadStrategy(DeadStrategy deadStrategy)
        {
            this._deadStrategy = deadStrategy;
        }

        public IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles)
        {
            return this._aiStrategy.ChangTargets(skill, roles);
        }
    }
}
