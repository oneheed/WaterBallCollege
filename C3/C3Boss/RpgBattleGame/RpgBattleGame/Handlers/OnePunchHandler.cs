using RpgBattleGame.Roles;

namespace RpgBattleGame.Handlers
{
    internal abstract class OnePunchHandler
    {
        private readonly OnePunchHandler? _next;

        protected Role? _caster;

        protected Role? _attacked;

        protected OnePunchHandler(OnePunchHandler? handler = null)
        {
            _next = handler;
        }

        public void Effect(Role caster, Role attacked)
        {
            _caster = caster;
            _attacked = attacked;

            if (this.Match())
            {
                this.Execute();
            }
            else if (this._next != null)
            {
                this._next.Effect(caster, attacked);
            }
        }

        protected abstract bool Match();

        protected abstract void Execute();
    }
}
