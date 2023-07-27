// See https://aka.ms/new-console-template for more information

using EmployeeDataSheetAccess;
using EmployeeDataSheetAccess.Interfaces;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var database = new PasswordRealDatabaseProxy(config);
var employee1 = database.GetEmployeeById(4);
var employee2 = database.GetEmployeeById(99);

Console.WriteLine();

List<IEmployee> subordinates1 = employee1.Subordinates.ToList();

Console.WriteLine();
Console.WriteLine($"{employee1.Id} {employee1.Name}");
Console.WriteLine(string.Join("\r\n", subordinates1.Select(employee => $"{employee.Id} {employee.Name}")));

Console.WriteLine();

List<IEmployee> subordinates2 = employee2.Subordinates.ToList();

Console.WriteLine();
Console.WriteLine($"{employee2.Id} {employee2.Name}");
Console.WriteLine(string.Join("\r\n", subordinates2.Select(employee => $"{employee.Id} {employee.Name}")));

Console.ReadLine();