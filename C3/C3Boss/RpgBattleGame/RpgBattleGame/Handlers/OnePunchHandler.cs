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

        public void Attack(Role caster, Role attacked)
        {
            _caster = caster;
            _attacked = attacked;

            if (this.Match())
            {
                this.Execute();
            }
            else if (this._next != null)
            {
                this._next.Attack(caster, attacked);
            }
        }

        protected abstract void Execute();

        protected abstract bool Match();
    }
}
