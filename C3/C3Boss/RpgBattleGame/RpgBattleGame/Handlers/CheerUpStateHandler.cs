using RpgBattleGame.States;

namespace RpgBattleGame.Handlers
{
    internal class CheerUpStateHandler : OnePunchHandler
    {
        public CheerUpStateHandler(OnePunchHandler? handler = null) : base(handler)
        {
        }

        protected override void Execute()
        {
            _attacked!.Damage(_caster!, 100);
            _attacked.ChangeState(new NormalState(_attacked));
        }

        protected override bool Match()
        {
            var stateType = _attacked!.State.GetType();

            return stateType == typeof(CheerUpState);
        }
    }
}
