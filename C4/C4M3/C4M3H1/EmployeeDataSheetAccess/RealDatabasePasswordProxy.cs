using EmployeeDataSheetAccess.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EmployeeDataSheetAccess
{
    internal class PasswordRealDatabaseProxy : LazyRealDatabaseProxy
    {
        private readonly string _passwords = @"1qaz2wsx";

        private readonly IConfiguration _configuration;

        public PasswordRealDatabaseProxy(IConfiguration configuration)
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
