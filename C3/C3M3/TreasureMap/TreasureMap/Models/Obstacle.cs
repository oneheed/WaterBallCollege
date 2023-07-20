namespace TreasureMap.Models
{
    internal class Obstacle : MapObject
    {
        public override char Symbol => '□';

        public override ConsoleColor Color => ConsoleColor.DarkGray;
    }
}
