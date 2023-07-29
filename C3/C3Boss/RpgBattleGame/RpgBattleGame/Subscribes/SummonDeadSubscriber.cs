using RpgBattleGame.Roles;

namespace RpgBattleGame.Subscribes
{
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
