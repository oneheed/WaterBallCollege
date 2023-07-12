using EmployeeDataSheetAccess.Interfaces;

namespace EmployeeDataSheetAccess.Models
{
    internal class RealEmployee : IEmployee
    {
        private readonly IDatabase database;

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public IEnumerable<int> SubordinateIds { get; set; }

        public RealEmployee(IDatabase database, string line)
        {
            this.database = database;

            var fields = line.Split(' ');
            Id = int.Parse(fields[0]);
            Name = fields[1];
            Age = int.Parse(fields[2]);
            SubordinateIds = fields[3].Split(',').Select(int.Parse);
        }

        public IEnumerable<IEmployee> GetSubordinates()
        {
            return SubordinateIds.Select(database.GetEmployeeById);
        }
    }
}
