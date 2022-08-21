namespace MatchmakingSystem.Models
{
    public class Coord
    {
        public double X { get; set; }

        public double Y { get; set; }


        public double GetDistance(Coord coord)
        {
            return Math.Abs(Math.Sqrt(Math.Pow(this.Y - coord.Y, 2) + Math.Pow(this.X - coord.X, 2)));
        }
    }
}
