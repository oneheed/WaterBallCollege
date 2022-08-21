namespace MatchmakingSystem.Models
{
    public class Coord
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Distance(Coord other)
        {
            return Math.Pow(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2), 0.5);
        }
    }
}