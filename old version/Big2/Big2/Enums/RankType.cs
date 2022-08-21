namespace Big2.Enums
{
    public class RankType
    {
        public int Number { get; private set; }

        public string Name { get; set; }

        public RankType(string rank)
        {
            this.Name = rank;

            switch (rank)
            {
                case "2":
                    this.Number = 12;
                    break;
                case "A":
                    this.Number = 11;
                    break;
                case "K":
                    this.Number = 10;
                    break;
                case "Q":
                    this.Number = 9;
                    break;
                case "J":
                    this.Number = 8;
                    break;
                default:
                    var number = int.Parse(rank);
                    this.Number = number - 3;
                    break;
            }
        }
    }
}
