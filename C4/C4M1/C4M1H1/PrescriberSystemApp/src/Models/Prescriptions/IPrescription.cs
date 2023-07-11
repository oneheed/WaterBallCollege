namespace PrescriberSystemApp.Models.Prescriptions
{
    public interface IPrescription
    {

        string Name { get; }

        string PotentialDisease { get; }

        string Medicines { get; }

        string Usage { get; }
    }
}
