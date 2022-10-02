using TreasureMap.Enums;
using TreasureMap.Models.States;
using TreasureMap.Strategies.Attack;
using TreasureMap.Strategies.Move;

namespace TreasureMap.Models.Roles
{
    internal class Monster : Role
    {
        public override char Symbol => 'Μ';

        protected sealed override int InitHP { get; } = 1;

        public Monster() : base()
        {
            this.ResetDefualtStrategy();
        }

        public override void ResetDefualtStrategy()
        {
            this.SetAttackStrategy(new NormalAttackStrategy(this));
            this.SetMoveStrategy(new NormalMoveStrategy(this));
        }

        public override void Attack()
        {
            this._attackStrategy.Attack();
        }

        public override void Move(Direction direction = Direction.None)
        {
            this._moveStrategy.Move(direction);
        }

        public void DoAction()
        {
            var map = this.Map;
            var character = (Character)map.GetMapObjectsByType(typeof(Character)).FirstOrDefault();

            if (character != null)
            {
                var fromIndex = this.GetMapIndex();
                var characterIndex = character.GetMapIndex();

                var attackDirections = new Dictionary<int, Direction>
                {
                    { fromIndex - map.Width, Direction.Up },
                    { fromIndex + map.Width, Direction.Down },
                    { fromIndex - 1, Direction.Left },
                    { fromIndex + 1, Direction.Right },
                };

                if (attackDirections.TryGetValue(characterIndex, out Direction attackDirection))
                {
                    this._attackStrategy.Attack(attackDirection);

                    if (character.State.GetType() != typeof(InvincibleState))
                    {
                        character.EnterState(new InvincibleState(character));
                    }
                }
                else
                {
                    var stateType = this.State.GetType();
                    var xOffeset = (characterIndex % map.Width - fromIndex % map.Width);
                    var yOffeset = (characterIndex - fromIndex) / map.Height;

                    if (yOffeset != 0 && stateType != typeof(OrderlessState))
                    {
                        var direction = yOffeset > 0 ? Direction.Down : Direction.Up;
                        this._moveStrategy.Move(direction);
                    }
                    else if (stateType != typeof(OrderlessState))
                    {
                        var direction = xOffeset > 0 ? Direction.Right : Direction.Left;
                        this._moveStrategy.Move(direction);
                    }
                }
            }
        }
    }
}
