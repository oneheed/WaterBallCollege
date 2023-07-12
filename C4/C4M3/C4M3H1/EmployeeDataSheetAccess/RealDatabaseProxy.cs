using EmployeeDataSheetAccess.Interfaces;
using EmployeeDataSheetAccess.Models;
using Microsoft.Extensions.Configuration;

namespace EmployeeDataSheetAccess
{
    internal class RealDatabaseProxy : RealDatabase
    {
        private readonly string _passwords = @"1qaz2wsx";

        private readonly IConfiguration _configuration;

        public RealDatabaseProxy(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public override IEmployee GetEmployeeById(int id)
        {

            if (_passwords == this._configuration["Password"])
            {
                return base.GetEmployeeById(id);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
