// Ignore Spelling: COVID

using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
{
    internal class COVID19Rule : IPrescriptionRule
    {
        public string Name => "COVID-19";

        public IPrescription Prescription => new COVID19();

        // 打噴嚏(Sneeze)、頭痛 (Headache) 和咳嗽 (Cough)
        public bool PrescriptionDemand(Patient patient, Symptom symptom)
            => new Symptom("Sneeze", "Headache", "Cough").Match(symptom);
    }
}
