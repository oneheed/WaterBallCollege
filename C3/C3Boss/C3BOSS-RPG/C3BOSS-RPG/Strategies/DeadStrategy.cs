using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Strategies
{
    internal abstract class DeadStrategy
    {
        protected List<Role> _caster = new List<Role>();

        protected DeadStrategy(Role caster)
        {
            this._caster.Add(caster);
        }

        internal abstract void Execute(Role self);
    }

    internal class CurseStrategy : DeadStrategy
    {
        public CurseStrategy(Role caster) : base(caster)
        {
        }

        internal override void Execute(Role self)
        {
            foreach (Role role in _caster.Where(c => c.Alive()))
            {
                role.Healing(self.MP);
            }
        }
    }

    internal class SummonStrategy : DeadStrategy
    {
        public SummonStrategy(Role caster) : base(caster)
        {
        }

        internal override void Execute(Role self)
        {
            foreach (Role role in _caster.Where(c => c.Alive()))
            {
                role.Healing(30);
            }
        }
    }
}
