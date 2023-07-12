namespace EmployeeDataSheetAccess.Interfaces
{
    internal interface IDatabase
    {
        public IEmployee GetEmployeeById(int id);
    }
}
