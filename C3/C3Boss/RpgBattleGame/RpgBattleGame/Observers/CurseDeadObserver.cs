using RpgBattleGame.Roles;

namespace RpgBattleGame.Observers
{
    internal class CurseDeadObserver : BaseDeadObserver
    {
        public CurseDeadObserver(Role caster) : base(caster)
        {
        }

        public override void Behavior(Role deader)
        {
            _caster.Healing(deader.MP);
        }
    }
}
