using EmployeeDataSheetAccess.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EmployeeDataSheetAccess
{
    internal class RealDatabasePasswordProxy : IDatabase
    {
        private readonly string _passwords = @"1qaz2wsx";

        private readonly IConfiguration _configuration;

        private readonly IDatabase _database;

        public RealDatabasePasswordProxy(IDatabase realDatabase, IConfiguration configuration)
        {
            this._database = realDatabase;
            this._configuration = configuration;
        }

        public IEmployee GetEmployeeById(int id)
        {

            if (_passwords == this._configuration["Password"])
            {
                return this._database.GetEmployeeById(id);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
