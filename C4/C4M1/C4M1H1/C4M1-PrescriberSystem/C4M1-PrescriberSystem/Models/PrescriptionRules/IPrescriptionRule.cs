using C4M1_PrescriberSystem.Models;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem_.Models.PrescriptionRules
{
    internal interface IPrescriptionRule
    {
        string Name { get; }

        IPrescription Prescription { get; }

        bool PrescriptionDemand(Patient patient, Symptom symptom);
    }
}
