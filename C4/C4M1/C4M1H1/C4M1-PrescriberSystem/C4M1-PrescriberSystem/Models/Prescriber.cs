using C4M1_PrescriberSystem_.Models.PrescriptionRules;
using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem.Models
{
    internal class Prescriber
    {
        private readonly PatientDatabase _patientDatabase;

        private readonly List<string> _settingRules = new List<string>();

        private readonly List<IPrescriptionRule> _prescriptionRules = new List<IPrescriptionRule>();

        private readonly Queue<Task<IPrescription?>> requestQueue = new Queue<Task<IPrescription?>>();

        public Prescriber(PatientDatabase patientDatabase, IEnumerable<IPrescriptionRule> prescriptionRules)
        {
            _patientDatabase = patientDatabase;

            _prescriptionRules.AddRange(prescriptionRules);
        }

        public void SetPrescriptionRules(IEnumerable<string> rules)
        {
            _settingRules.AddRange(rules);
        }

        private readonly object lockObject = new object();



        public Task Start()
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    Task<IPrescription?> request;
                    lock (lockObject)
                    {
                        while (!requestQueue.Any())
                        {
                            Monitor.Wait(lockObject); // 等待新的请求到达
                        }

                        request = requestQueue.Dequeue();
                    }

                    await request;
                }
            });
        }

        public Task<IPrescription?> PrescriptionDemand(string id, Symptom symptom)
        {
            Console.WriteLine(id);

            var test = default(Task<IPrescription?>);
            lock (lockObject)
            {
                test = Task.Delay(TimeSpan.FromSeconds(3))
                    .ContinueWith(t => Test(id, symptom));

                requestQueue.Enqueue(test);
                Monitor.Pulse(lockObject); // 通知处理任务有新的请求
            }

            return test;
        }

        private IPrescription? Test(string id, Symptom symptom)
        {
            var patient = _patientDatabase.Search(id);

            if (patient != null)
            {
                foreach (var rule in _prescriptionRules.Where(p => _settingRules.Contains(p.Name)))
                {
                    if (rule.PrescriptionDemand(patient, symptom))
                    {
                        return rule.Prescription;
                    }
                    else
                    {
                        // TODO: not find Prescription
                        //throw new ArgumentException();
                    }
                }
            }
            else
            {
                // TODO: not find patient
                //throw new ArgumentException();
            }

            return default;
        }
    }
}
