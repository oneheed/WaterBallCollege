using EmployeeDataSheetAccess.Interfaces;
using EmployeeDataSheetAccess.Models;

namespace EmployeeDataSheetAccess
{
    internal class LazyRealDatabaseProxy : IDatabase
    {
        private IDatabase? _database;

        private readonly Dictionary<int, IEmployee> _data = new();

        public virtual IEmployee GetEmployeeById(int id)
        {
            if (_database == null)
            {
                Console.WriteLine("Create RealDatabase");

                this._database = new RealDatabase();
            }

            if (_data.TryGetValue(id, out var employee))
            {
                return employee;
            }
            else
            {
                Console.WriteLine($"Get Employee By Id:{id}");

                var result = new LazyRealEmployee(_database.GetEmployeeById(id), this);

                _data.Add(id, result);

                return result;
            }
        }
    }
}
