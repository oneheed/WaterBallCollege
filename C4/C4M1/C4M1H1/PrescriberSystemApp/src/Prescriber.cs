using PrescriberSystemApp.Models;
using PrescriberSystemApp.PrescriptionRules;
using PrescriberSystemApp.Prescriptions;

namespace PrescriberSystemApp
{
    internal class Prescriber
    {
        private readonly PatientDatabase _patientDatabase;

        private readonly Queue<PrescriptionRequest> requestQueue = new Queue<PrescriptionRequest>();

        private readonly List<PrescriptionRule> _prescriptionRules = new List<PrescriptionRule>();

        public Prescriber(PatientDatabase patientDatabase, IEnumerable<PrescriptionRule> prescriptionRules)
        {
            _patientDatabase = patientDatabase;

            _prescriptionRules.AddRange(prescriptionRules);
        }

        private readonly object lockObject = new object();

        public Task Start()
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    PrescriptionRequest request;
                    lock (lockObject)
                    {
                        while (!requestQueue.Any())
                        {
                            Monitor.Wait(lockObject);
                        }

                        request = requestQueue.Dequeue();
                    }

                    request.Prescription = await Diagnosis(request.Id, request.Descriptions.ToList());

                    Console.WriteLine($"{request.Id} 診斷完畢");

                    request.Complete();
                }
            });
        }

        public void PrescriptionDemand(PrescriptionRequest prescriptionRequest)
        {
            Console.WriteLine($"收到 {prescriptionRequest.Id} 診斷需求");

            lock (lockObject)
            {
                requestQueue.Enqueue(prescriptionRequest);
                Monitor.Pulse(lockObject);
            }
        }

        private async Task<Prescription?> Diagnosis(string id, List<string> symptom)

        {
            var patient = _patientDatabase.Search(id);

            if (patient != null)
            {
                await Task.Delay(3000);

                var prescription = _prescriptionRules.FirstOrDefault(r => r.PrescriptionDemand(patient, symptom))?.Prescription;

                if (prescription != null)
                {
                    _patientDatabase.AddCase(id, new Case(prescription, symptom));
                    _patientDatabase.SyncDataBase();
                }

                return prescription;
            }

            return default;
        }
    }
}
