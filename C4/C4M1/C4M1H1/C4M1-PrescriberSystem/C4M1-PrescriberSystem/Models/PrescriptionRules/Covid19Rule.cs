// Ignore Spelling: COVID

using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
{
    internal class Covid19Rule : PrescriptionRule
    {
        public override string Name => "COVID-19";

        public override IPrescription Prescription => new Covid19();

        public override List<string> MathSymptom => new List<string> { "Sneeze", "Headache", "Cough" };

        // 打噴嚏(Sneeze)、頭痛 (Headache) 和咳嗽 (Cough)
        public override bool PrescriptionDemand(Patient patient, List<string> symptom)
            => Match(symptom);
    }
}
