using C4M3H1.Interfaces;
using Microsoft.Extensions.Configuration;

namespace C4M3H1
{
    internal class RealDatabaseProxy : RealDatabase
    {
        private readonly string _paassword = @"1qaz2wsx";

        private readonly IConfiguration _configuration;

        public RealDatabaseProxy(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public override IEmployee GetEmployeeById(int id)
        {

            if (_paassword == this._configuration["Password"])
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
