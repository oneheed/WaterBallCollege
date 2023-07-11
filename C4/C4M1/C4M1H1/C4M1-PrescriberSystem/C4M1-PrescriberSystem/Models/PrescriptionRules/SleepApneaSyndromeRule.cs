// Ignore Spelling: Apnea

using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
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
