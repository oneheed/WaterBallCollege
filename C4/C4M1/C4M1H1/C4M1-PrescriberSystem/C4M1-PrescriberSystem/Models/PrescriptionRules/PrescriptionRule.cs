using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
{
    internal abstract class PrescriptionRule
    {
        public abstract string Name { get; }

        public abstract IPrescription Prescription { get; }

        public abstract List<string> MathSymptom { get; }

        public abstract bool PrescriptionDemand(Patient patient, List<string> symptom);

        public bool Match(List<string> symptom)
            => !MathSymptom.Any() || MathSymptom.All(m => symptom.Contains(m, StringComparer.OrdinalIgnoreCase));
    }
}
