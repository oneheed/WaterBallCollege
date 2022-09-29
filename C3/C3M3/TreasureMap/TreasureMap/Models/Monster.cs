namespace TreasureMap.Models
{
    internal class Monster : Role
    {
        public override char Symbol => 'Μ';

        protected sealed override int InitHP { get; } = 1;
    }
}
