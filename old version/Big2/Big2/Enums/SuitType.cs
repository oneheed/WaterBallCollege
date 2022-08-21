namespace Big2.Enums
{
    public class SuitType
    {
        public int Number { get; private set; }

        public string Name { get; set; }

        public SuitType(string suit)
        {
            this.Name = suit;

            switch (suit)
            {
                case "C":
                    this.Number = 0;
                    break;
                case "D":
                    this.Number = 1;
                    break;
                case "H":
                    this.Number = 2;
                    break;
                case "S":
                    this.Number = 3;
                    break;
            }
        }
    }
}
