using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
{
    internal class SleepApneaSyndromeRule : IPrescriptionRule
    {
        public string Name => "SleepApneaSyndrome";

        public IPrescription Prescription => new SleepApneaSyndrome();

        // BMI 大於 26，而且還打呼 (snore)
        public bool PrescriptionDemand(Patient patient, Symptom symptom)
            => patient.BMI > 26 && new Symptom("snore").Match(symptom);
    }
}
