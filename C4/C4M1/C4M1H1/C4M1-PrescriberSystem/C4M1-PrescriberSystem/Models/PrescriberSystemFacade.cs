using System.Text.Json;
using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.PrescriptionRules;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models
{
    internal class PrescriberSystemFacade
    {
        private readonly PatientDatabase patientDatabase;

        private readonly Prescriber prescriber;

        public PrescriberSystemFacade(string databaseFile, string prescriberFile)
        {
            this.patientDatabase = new PatientDatabase();
            this.patientDatabase.SetData(ReadDatabaseFile(databaseFile));

            this.prescriber = new Prescriber(this.patientDatabase, new List<IPrescriptionRule>
            {
                new COVID19Rule(),
                new AttractiveRule(),
                new SleepApneaSyndromeRule(),
            });

            this.prescriber.SetPrescriptionRules(ReadPrescriberFile(prescriberFile));

            this.prescriber.Start();
        }

        private List<Patient> ReadDatabaseFile(string databaseFile)
        {
            var document = File.ReadAllText(databaseFile);
            var patients = JsonSerializer.Deserialize<List<Patient>>(document);

            return patients;
        }

        private List<string> ReadPrescriberFile(string prescriberFile)
        {
            return File.ReadAllLines(prescriberFile).ToList();
        }



        public async Task<IPrescription?> PrescriptionDemand(string id, params string[] symptom)
        {
            return await prescriber.PrescriptionDemand(id, new Symptom(symptom));
        }

    }
}
