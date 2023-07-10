// See https://aka.ms/new-console-template for more information
using C4M1_PrescriberSystem_.Models;

Console.WriteLine("Hello, World!");

var prescriberFacade = new PrescriberSystemFacade("Resources/PatientDatabase.Json", "Resources/PrescriberFile.txt");


var task1 = prescriberFacade.PrescriptionDemand("N123000001", "Sneeze", "Headache", "Cough");
var task2 = prescriberFacade.PrescriptionDemand("N123000001", "Sneeze", "Headache", "Cough");

Console.WriteLine(task1.Result.Name);
Console.WriteLine(task2.Result.Name);
