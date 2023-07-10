using C4M1_PrescriberSystem.Enums;
using C4M1_PrescriberSystem.Models;

namespace C4M1_PrescriberSystem_.Models.Prescriptions
{
    internal class Attractive : IPrescription
    {
        public string Name => "青春抑制劑";

        public string PotentialDisease => "有人想你了 (專業學名：Attractive)";

        public string Medicines => "假鬢角、臭味";

        public string Usage => "把假鬢角黏在臉的兩側，讓自己異性緣差一點，自然就不會有人想妳了。";

        // 正直 18 歲的女性，而且還打噴嚏 (sneeze)
        public bool Condition(Patient patient, Symptom symptom)
            => patient.Age == 18 && patient.Gender == Gender.Female && new Symptom("Sneeze").Match(symptom);
    }
}
