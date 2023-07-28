using RpgBattleGame.States;

namespace RpgBattleGame.Handlers
{
    internal class PoisonedOrPetrochemicalStateHandler : OnePunchHandler
    {
        public PoisonedOrPetrochemicalStateHandler(OnePunchHandler? handler = null) : base(handler)
        {
        }

        protected override void Execute()
        {
            for (int i = 0; i < 3 && _attacked!.Alive(); i++)
            {
                _attacked!.Damage(_caster!, 80);
            }
        }

        protected override bool Match()
        {
            var stateType = _attacked!.State.GetType();

            return stateType == typeof(PoisonedState) || stateType == typeof(PetrochemicalState);
        }
    }
}
