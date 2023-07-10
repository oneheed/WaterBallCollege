using C4M1_PrescriberSystem.Enums;
using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
{
    internal class AttractiveRule : IPrescriptionRule
    {
        public string Name => "Attractive";

        public IPrescription Prescription => new Attractive();

        // 正直 18 歲的女性，而且還打噴嚏 (sneeze)
        public bool PrescriptionDemand(Patient patient, Symptom symptom)
            => patient.Age == 18 && patient.Gender == Gender.Female && new Symptom("Sneeze").Match(symptom);
    }
}
