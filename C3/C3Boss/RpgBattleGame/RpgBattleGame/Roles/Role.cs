using RpgBattleGame.Skills;
using RpgBattleGame.States;
using RpgBattleGame.Strategies;

namespace RpgBattleGame.Roles
{
    internal class Role
    {
        private Troop? _troop;

        public virtual int HP { get; private set; }

        public virtual int MP { get; private set; }

        public virtual int STR { get; private set; }

        private readonly string _name;

        public string Name
        {
            get => $"{this._troop?.Symbol}{this._name}";
        }

        public State State { get; private set; }

        protected AIStrategy _aiStrategy;

        protected readonly List<IDeadSubscriber> _deadObservers = new();

        public List<Skill> Skills { get; } = new List<Skill>
        {
            new BasicAttack(),
        };

        public Role(int hp, int mp, int str, string name, IEnumerable<Skill> skills)
        {
            this.HP = hp;
            this.MP = mp;
            this.STR = str;
            this._name = name;
            this.State = new NormalState(this);

            this._aiStrategy ??= new NormalAIStrategy(this);

            this.Skills.AddRange(skills);
        }

        internal void SetTroop(Troop troop)
        {
            this._troop = troop;
        }

        internal Troop GetTroop()
        {
            return this._troop!;
        }

        public bool Dead() => this.HP <= 0;

        public bool Alive() => !this.Dead();

        public bool CanAction() => this.Alive() && this.State.CanAction();

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
                DeadNotify();
                Console.WriteLine($"{this.Name} 死亡。");
            }
        }

        internal void Suicide()
        {
            this.HP = 0;
            DeadNotify();
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

        internal void SetAIStrategy(AIStrategy aiStrategy)
        {
            this._aiStrategy = aiStrategy;
        }

        internal void SubscribeDeadNotify(IDeadSubscriber casters)
        {
            this._deadObservers.Add(casters);
        }

        internal void DeadNotify()
        {
            this._deadObservers.ForEach(o => o.Behavior(this));
        }

        public virtual IEnumerable<Role> ChangTargets(Skill skill, IEnumerable<Role> roles)
        {
            return this._aiStrategy.ChangTargets(skill, roles);
        }
    }
}
