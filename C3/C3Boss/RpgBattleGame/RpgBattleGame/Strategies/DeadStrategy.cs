using RpgBattleGame.Roles;

namespace RpgBattleGame.Strategies
{
    internal interface IDeadSubscriber
    {
        void Behavior(Role deader);
    }

    internal abstract class BaseDeadSubscriber : IDeadSubscriber
    {
        protected readonly Role _caster;

        protected BaseDeadSubscriber(Role caster)
        {
            _caster = caster;
        }

        public abstract void Behavior(Role deader);
    }

    internal class CurseDeadSubscriber : BaseDeadSubscriber
    {
        public CurseDeadSubscriber(Role caster) : base(caster)
        {
        }

        public override void Behavior(Role deader)
        {
            _caster.Healing(deader.MP);
        }
    }

    internal class SummonDeadSubscriber : BaseDeadSubscriber
    {
        public SummonDeadSubscriber(Role caster) : base(caster)
        {
        }

        public override void Behavior(Role deader)
        {
            _caster.Healing(30);
        }
    }
}
