namespace RpgBattleGame.Handlers
{
    internal class HpOver500Handler : OnePunchHandler
    {
        public HpOver500Handler(OnePunchHandler? handler = null) : base(handler)
        {
        }

        protected override void Execute()
        {
            _attacked!.Damage(_caster!, 300);
        }

        protected override bool Match()
        {
            return _attacked!.HP >= 500;
        }
    }
}
