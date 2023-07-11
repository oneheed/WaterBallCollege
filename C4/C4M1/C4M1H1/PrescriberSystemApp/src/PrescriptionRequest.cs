using PrescriberSystemApp.Prescriptions;

namespace PrescriberSystemApp
{
    public class PrescriptionRequest
    {
        private readonly ManualResetEventSlim completionEvent = new();

        public string Id { get; private set; }

        public string[] Descriptions { get; private set; }

        public bool IsComplete { get; private set; } = false;

        private IPrescription? _prescription;

        public IPrescription? Prescription
        {
            get
            {
                Wait();

                return _prescription;
            }
            set
            {
                _prescription = value;
            }
        }


        public PrescriptionRequest(string id, string[] descriptions)
        {
            Id = id;
            Descriptions = descriptions;
        }

        internal void Complete()
        {
            completionEvent.Set();

            IsComplete = true;
        }

        internal void Wait()
        {
            completionEvent.Wait();
        }
    }
}