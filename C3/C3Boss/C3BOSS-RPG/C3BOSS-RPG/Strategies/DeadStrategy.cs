using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Strategies
{
    internal abstract class DeadStrategy
    {
        protected Role _caster;

        protected DeadStrategy(Role caster)
        {
            this._caster = caster;
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
            if (this._caster.Alive())
            {
                this._caster.Healing(self.MP);
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
            if (this._caster.Alive())
            {
                this._caster.Healing(30);
            }
        }
    }
}
