using System.Text.Json.Serialization;

namespace PrescriberSystemApp.Models
{
    internal class Case
    {
        public DateTime CaseTime { get; private set; } = DateTime.Now;

        public List<string> Symptom { get; private set; } = new List<string>();

        [JsonConstructor]
        public Case(DateTime caseTime, List<string> symptom)
        {
            CaseTime = caseTime;
            Symptom = symptom ?? new List<string>();
        }

        public Case(List<string> symptom)
        {
            Symptom = symptom;
        }
    }
}