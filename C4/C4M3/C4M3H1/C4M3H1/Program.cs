// See https://aka.ms/new-console-template for more information

using C4M3H1;
using C4M3H1.Interfaces;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var database = new RealDatabaseProxy(config);
var employee = database.GetEmployeeById(4);

List<IEmployee> subordinates = employee.GetSubordinates().ToList();

Console.WriteLine($"{employee.Id} {employee.Name}");
Console.WriteLine(string.Join("\r\n", subordinates.Select(employee => $"{employee.Id} {employee.Name}")));