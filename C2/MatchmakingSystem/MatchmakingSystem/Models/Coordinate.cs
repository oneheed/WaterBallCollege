namespace MatchmakingSystem.Models
{
    public class Coordinate
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Distance(Coordinate other)
        {
            return Math.Pow(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2), 0.5);
        }
    }
}