using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Enums;
using C4M1_PrescriberSystem_.Models.PrescriptionRules;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models
{
    internal class PrescriberSystemFacade
    {
        private readonly Prescriber prescriber;

        private readonly List<string> _supportRules = new();

        public PrescriberSystemFacade(string databaseFilePath, string ruleFilePath)
        {
            var patientDatabase = new PatientDatabaseFormFile(databaseFilePath);

            SetSupportRulesFormFile(ruleFilePath);
            var prescriptionRules = new List<PrescriptionRule>
            {
                new Covid19Rule(),
                new AttractiveRule(),
                new SleepApneaSyndromeRule(),
            }.Where(p => _supportRules.Contains(p.Name, StringComparer.OrdinalIgnoreCase));

            this.prescriber = new Prescriber(patientDatabase, prescriptionRules);
            this.prescriber.Start();
        }

        public void PrescriptionDemand(PrescriptionRequest prescriptionRequest)
        {
            prescriber.PrescriptionDemand(prescriptionRequest);
        }

        public void SavePrescriptionToFile(PrescriptionRequest prescriptionRequest, string outFilePath, FileFormat fileFormat)
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

                        var properties = typeof(IPrescription).GetProperties();
                        var titles = string.Join(",", properties.Select(p => p.Name));
                        stringBuilder.AppendLine(titles);
                        var values = string.Join(",", properties.Select(p => p.GetValue(prescription)?.ToString()));
                        stringBuilder.AppendLine(values);

                        File.WriteAllText(outFilePath, stringBuilder.ToString());

                        break;
                }
            }
        }

        private void SetSupportRulesFormFile(string ruleFilePath)
        {
            var rules = File.ReadAllLines(ruleFilePath).ToList();

            _supportRules.AddRange(rules);
        }
    }
}
