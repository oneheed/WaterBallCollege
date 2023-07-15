namespace PrescriberSystemApp.Prescriptions
{
    public class Prescription
    {
        public string Name { get; set; }

        public string PotentialDisease { get; set; }

        public string Medicines { get; set; }

        public string Usage { get; set; }

        public Prescription(string name, string potentialDisease, string medicines, string usage)
        {
            Name = name;
            PotentialDisease = potentialDisease;
            Medicines = medicines;
            Usage = usage;
        }
    }
}
