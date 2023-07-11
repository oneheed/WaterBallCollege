using System.Text.Json;

namespace PrescriberSystemApp.Models
{
    internal abstract class PatientDatabase
    {
        protected readonly Dictionary<string, Patient> _patients = new();

        public Patient? Search(string id)
        {
            return _patients.TryGetValue(id, out var patient) ? patient : default;
        }

        public void AddCase(string id, Case patientCase)
        {
            if (_patients.TryGetValue(id, out var patient))
            {
                patient.Cases.Add(patientCase);
            }
        }

        public abstract void SyncDataBase();
    }

    internal class PatientDatabaseFormFile : PatientDatabase
    {
        private readonly string _filePath;

        public PatientDatabaseFormFile(string filePath) : base()
        {
            this._filePath = filePath;

            InitDataBaseFormFile();
        }

        private void InitDataBaseFormFile()
        {
            var document = File.ReadAllText(this._filePath);
            var patients = JsonSerializer.Deserialize<List<Patient>>(document);

            if (patients != null)
            {
                foreach (var patient in patients)
                {
                    _patients.Add(patient.Id, patient);
                }
            }
        }

        public override void SyncDataBase()
        {
            var document = JsonSerializer.Serialize(this._patients.Values, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(this._filePath, document);
        }
    }
}
