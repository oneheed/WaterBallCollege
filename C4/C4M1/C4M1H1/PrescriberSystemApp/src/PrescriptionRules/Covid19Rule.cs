// Ignore Spelling: COVID

using PrescriberSystemApp.Models;
using PrescriberSystemApp.Prescriptions;

namespace PrescriberSystemApp.PrescriptionRules
{
    internal class Covid19Rule : PrescriptionRule
    {
        public override string Name => "COVID-19";

        public override Prescription Prescription => new Covid19();

        public override List<string> MathSymptom => new() { "Sneeze", "Headache", "Cough" };

        // 打噴嚏(Sneeze)、頭痛 (Headache) 和咳嗽 (Cough)
        public override bool PrescriptionDemand(Patient patient, List<string> symptom)
            => Match(symptom);
    }
}
