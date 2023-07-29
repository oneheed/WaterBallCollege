using RpgBattleGame.Roles;

namespace RpgBattleGame.Subscribes
{
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
}
