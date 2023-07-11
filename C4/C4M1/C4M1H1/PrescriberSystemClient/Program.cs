// See https://aka.ms/new-console-template for more information

using PrescriberSystemApp;
using PrescriberSystemApp.Enums;

var prescriberFacade = new PrescriberSystemFacade("Resources/PatientDatabase.Json", "Resources/PrescriberFile.txt");
var requests = new List<PrescriptionRequest>
{
    new PrescriptionRequest("N123000001", new[] { "Sneeze", "Headache", "Cough" }),
    new PrescriptionRequest("N123000002", new[] { "Snore" }),
};

foreach (var request in requests)
{
    prescriberFacade.PrescriptionDemand(request);
}

PrescriberSystemFacade.SavePrescriptionToFile(requests[0], "Resources/1.json", FileFormat.Json);
PrescriberSystemFacade.SavePrescriptionToFile(requests[1], "Resources/1.csv", FileFormat.CSV);

Console.WriteLine(requests[0].Prescription?.Name);
Console.WriteLine(requests[1].Prescription?.Name);