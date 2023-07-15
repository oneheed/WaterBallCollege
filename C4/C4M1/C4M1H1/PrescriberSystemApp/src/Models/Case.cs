using System.Text.Json.Serialization;
using PrescriberSystemApp.Prescriptions;

namespace PrescriberSystemApp.Models
{
    internal class Case
    {
        public DateTime CaseTime { get; private set; } = DateTime.Now;

        public Prescription Prescription { get; private set; }

        public List<string> Symptom { get; private set; } = new List<string>();

        [JsonConstructor]
        public Case(DateTime caseTime, Prescription prescription, List<string> symptom)
        {
            CaseTime = caseTime;
            Prescription = prescription;
            Symptom = symptom ?? new List<string>();
        }

        public Case(Prescription prescription, List<string> symptom)
        {
            Prescription = prescription;
            Symptom = symptom;
        }
    }
}