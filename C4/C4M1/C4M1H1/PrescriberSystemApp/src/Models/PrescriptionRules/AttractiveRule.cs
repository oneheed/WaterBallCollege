using PrescriberSystemApp.Enums;
using PrescriberSystemApp.Models.Prescriptions;

namespace PrescriberSystemApp.Models.PrescriptionRules
{
    internal class AttractiveRule : PrescriptionRule
    {
        public override string Name => "Attractive";

        public override IPrescription Prescription => new Attractive();

        public override List<string> MathSymptom => new List<string> { "Sneeze" };

        // 正直 18 歲的女性，而且還打噴嚏 (sneeze)
        public override bool PrescriptionDemand(Patient patient, List<string> symptom)
            => patient.Age == 18 && patient.Gender == Gender.Female && Match(symptom);
    }
}
