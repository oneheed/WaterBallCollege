// See https://aka.ms/new-console-template for more information
using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models;

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

//prescriberFacade.SavePrescriptionToFile(requests[0], "Resources/1.json", FileFormat.Json);
//prescriberFacade.SavePrescriptionToFile(requests[1], "Resources/1.csv", FileFormat.CSV);

Console.WriteLine(requests[0].Prescription?.Name);
Console.WriteLine(requests[1].Prescription?.Name);