using C4M3H1.Interfaces;

namespace C4M3H1
{
    internal class RealEmplyee : IEmployee
    {
        private readonly IDatabase database;

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public IEnumerable<int> SubordinateIds { get; set; }

        public RealEmplyee(IDatabase database, string line)
        {
            this.database = database;

            var fileds = line.Split(' ');
            this.Id = int.Parse(fileds[0]);
            this.Name = fileds[1];
            this.Age = int.Parse(fileds[2]);
            this.SubordinateIds = fileds[3].Split(',').Select(int.Parse);
        }

        public IEnumerable<IEmployee> GetSubordinates()
        {
            return this.SubordinateIds.Select(database.GetEmployeeById);
        }
    }
}
