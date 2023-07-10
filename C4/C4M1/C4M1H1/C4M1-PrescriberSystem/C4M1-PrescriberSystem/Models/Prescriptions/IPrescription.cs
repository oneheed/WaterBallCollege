namespace C4M1_PrescriberSystem_.Models.Prescriptions
{
    internal interface IPrescription
    {
        string Name { get; }

        string PotentialDisease { get; }

        string Medicines { get; }

        string Usage { get; }
    }
}
