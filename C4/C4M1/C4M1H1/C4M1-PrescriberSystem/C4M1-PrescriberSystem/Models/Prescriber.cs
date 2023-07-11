using C4M1_PrescriberSystem_.Models.PrescriptionRules;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem.Models
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

        private async Task<IPrescription?> Diagnosis(string id, List<string> symptom)

        {
            var patient = _patientDatabase.Search(id);
            this._patientDatabase.AddCase(id, new Case(symptom));
            this._patientDatabase.SyncDataBase();

            if (patient != null)
            {
                await Task.Delay(3000);

                return _prescriptionRules.FirstOrDefault(r => r.PrescriptionDemand(patient, symptom))?.Prescription;
            }

            return default;
        }
    }
}
