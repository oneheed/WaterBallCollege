using RpgBattleGame.Interfaces;
using RpgBattleGame.Roles;

namespace RpgBattleGame.Observers
{
    internal abstract class BaseDeadObserver : IDeadObserver
    {
        protected readonly Role _caster;

        protected BaseDeadObserver(Role caster)
        {
            _caster = caster;
        }

        public abstract void Behavior(Role deader);
    }
}
