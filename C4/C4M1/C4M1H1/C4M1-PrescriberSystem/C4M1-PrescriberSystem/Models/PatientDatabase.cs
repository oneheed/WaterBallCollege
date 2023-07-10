namespace C4M1_PrescriberSystem.Models
{
    internal class PatientDatabase
    {
        private readonly Dictionary<string, Patient> _patients = new();

        public void SetData(IEnumerable<Patient> patients)
        {
            foreach (var patient in patients)
            {
                _patients.Add(patient.Id, patient);
            }
        }

        public Patient? Search(string id)
        {
            return _patients.TryGetValue(id, out var patient) ? patient : default;
        }

        //public void AddCase(string id, Case case)
        //{

        //}
    }
}
