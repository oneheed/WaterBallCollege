using RpgBattleGame.Interfaces;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Subscribes
{
    internal abstract class BaseDeadSubscriber : IDeadSubscriber
    {
        protected readonly Role _caster;

        protected BaseDeadSubscriber(Role caster)
        {
            _caster = caster;
        }

        public abstract void Behavior(Role deader);
    }
}
