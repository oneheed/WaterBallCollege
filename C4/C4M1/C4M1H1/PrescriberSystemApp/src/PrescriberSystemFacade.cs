using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using PrescriberSystemApp.Enums;
using PrescriberSystemApp.PrescriptionRules;
using PrescriberSystemApp.Prescriptions;

namespace PrescriberSystemApp
{
    public class PrescriberSystemFacade
    {
        private readonly Prescriber prescriber;

        private readonly List<PrescriptionRule> _supportRules = new()
        {
            new Covid19Rule(),
            new AttractiveRule(),
            new SleepApneaSyndromeRule(),
        };

        public PrescriberSystemFacade(string databaseFilePath, string ruleFilePath)
        {
            var patientDatabase = new PatientDatabaseFormFile(databaseFilePath);

            var filterRules = GetFilterRulesFormFile(ruleFilePath);
            var prescriptionRules = _supportRules
                .Where(p => filterRules.Contains(p.Name, StringComparer.OrdinalIgnoreCase));

            prescriber = new Prescriber(patientDatabase, prescriptionRules);
            prescriber.Start();
        }

        public void PrescriptionDemand(PrescriptionRequest prescriptionRequest)
        {
            prescriber.PrescriptionDemand(prescriptionRequest);
        }

        public static void SavePrescriptionToFile(PrescriptionRequest prescriptionRequest, string outFilePath, FileFormat fileFormat)
        {
            var prescription = prescriptionRequest.Prescription;
            if (prescription != null)
            {
                Console.WriteLine($"將 {prescriptionRequest.Id} 診斷結果, 存入 {outFilePath}");

                switch (fileFormat)
                {
                    case FileFormat.Json:
                        var options = new JsonSerializerOptions
                        {
                            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                            WriteIndented = true
                        };

                        var prescriptionJson = JsonSerializer.Serialize(prescription, options);
                        File.WriteAllText(outFilePath, prescriptionJson);

                        break;

                    case FileFormat.CSV:
                        var stringBuilder = new StringBuilder();

                        var properties = typeof(Prescription).GetProperties();
                        var titles = string.Join(",", properties.Select(p => p.Name));
                        stringBuilder.AppendLine(titles);
                        var values = string.Join(",", properties.Select(p => p.GetValue(prescription)?.ToString()));
                        stringBuilder.AppendLine(values);

                        File.WriteAllText(outFilePath, stringBuilder.ToString());

                        break;
                }
            }
        }

        private List<string> GetFilterRulesFormFile(string ruleFilePath)
        {
            var rules = File.ReadAllLines(ruleFilePath).ToList();

            return rules ?? new();
        }
    }
}
