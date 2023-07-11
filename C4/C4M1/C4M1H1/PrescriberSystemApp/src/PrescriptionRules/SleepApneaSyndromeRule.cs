// Ignore Spelling: Apnea

using PrescriberSystemApp.Models;
using PrescriberSystemApp.Prescriptions;

namespace PrescriberSystemApp.PrescriptionRules
{
    internal class SleepApneaSyndromeRule : PrescriptionRule
    {
        public override string Name => "SleepApneaSyndrome";

        public override IPrescription Prescription => new SleepApneaSyndrome();

        public override List<string> MathSymptom => new List<string> { "Snore" };

        // BMI 大於 26，而且還打呼 (snore)
        public override bool PrescriptionDemand(Patient patient, List<string> symptom)
            => patient.BMI > 26 && Match(symptom);
    }
}
