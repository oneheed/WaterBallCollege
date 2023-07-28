using RpgBattleGame.States;

namespace RpgBattleGame.Handlers
{
    internal class NormalStateHandler : OnePunchHandler
    {
        public NormalStateHandler(OnePunchHandler? handler = null) : base(handler)
        {
        }

        protected override void Execute()
        {
            _attacked!.Damage(_caster!, 100);
        }

        protected override bool Match()
        {
            var stateType = _attacked!.State.GetType();

            return stateType == typeof(NormalState);
        }
    }
}
