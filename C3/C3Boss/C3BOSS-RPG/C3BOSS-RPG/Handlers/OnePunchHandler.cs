using C3BOSS_RPG.Roles;

namespace C3BOSS_RPG.Handlers
{
    internal abstract class OnePunchHandler
    {
        private OnePunchHandler? _next;

        private Role attacked;

        public OnePunchHandler(OnePunchHandler handler)
        {
            _next = handler;
        }

        public void Attack(Role role)
        {
            this.attacked = role;

            if (this.Match())
            {
                this.Execute();
            }
            else if (this._next != null)
            {
                this._next.Attack(role);
            }
        }

        protected abstract void Execute();

        protected abstract bool Match();
    }
}
