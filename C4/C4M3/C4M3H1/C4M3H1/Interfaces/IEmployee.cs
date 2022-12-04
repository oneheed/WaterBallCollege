namespace C4M3H1.Interfaces
{
    internal interface IEmployee
    {
        int Id { get; set; }

        string Name { get; set; }

        int Age { get; set; }

        IEnumerable<int> SubordinateIds { get; set; }

        IEnumerable<IEmployee> GetSubordinates();
    }
}
