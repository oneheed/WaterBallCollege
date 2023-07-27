using EmployeeDataSheetAccess.Interfaces;

namespace EmployeeDataSheetAccess.Models
{
    internal class RealEmployee : IEmployee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public IEnumerable<int> SubordinateIds { get; set; }

        public IEnumerable<IEmployee> Subordinates { get; set; }
    }

    internal class LazyRealEmployee : IEmployee
    {
        public int Id => _employee.Id;

        public string Name => _employee.Name;

        public int Age => _employee.Age;

        public IEnumerable<int> SubordinateIds => _employee.SubordinateIds;

        public IEnumerable<IEmployee> Subordinates
        {
            get
            {
                if (_employee.Subordinates == null)
                {
                    _employee.Subordinates = _employee.SubordinateIds.Select(_database.GetEmployeeById);
                }

                return _employee.Subordinates;
            }

            set { _employee.Subordinates = value; }
        }

        private readonly IEmployee _employee;

        private readonly IDatabase _database;


        public LazyRealEmployee(IEmployee employee, IDatabase database)
        {
            _employee = employee;
            _database = database;
        }
    }
}
