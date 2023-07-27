namespace EmployeeDataSheetAccess.Interfaces
{
    internal interface IEmployee
    {
        int Id { get; }

        string Name { get; }

        int Age { get; }

        IEnumerable<int> SubordinateIds { get; }

        IEnumerable<IEmployee> Subordinates { get; set; }
    }
}
