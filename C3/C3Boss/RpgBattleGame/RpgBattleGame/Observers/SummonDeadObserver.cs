using RpgBattleGame.Roles;

namespace RpgBattleGame.Observers
{
    internal class SummonDeadObserver : BaseDeadObserver
    {
        public SummonDeadObserver(Role caster) : base(caster)
        {
        }

        public override void Behavior(Role deader)
        {
            _caster.Healing(30);
        }
    }
}
