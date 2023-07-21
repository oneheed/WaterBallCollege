namespace PrescriberSystemApp.Prescriptions
{
    public abstract class Prescription
    {
        public abstract string Name { get; }

        public abstract string PotentialDisease { get; }

        public abstract string Medicines { get; }

        public abstract string Usage { get; }
    }
}
