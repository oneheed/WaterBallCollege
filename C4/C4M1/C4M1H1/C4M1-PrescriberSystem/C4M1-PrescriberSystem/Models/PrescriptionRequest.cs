using C4M1_PrescriberSystem_.Models.Prescriptions;

namespace C4M1_PrescriberSystem.Models
{
    internal class PrescriptionRequest
    {
        private readonly ManualResetEventSlim completionEvent = new ManualResetEventSlim();

        public string Id { get; private set; }

        public string[] Descriptions { get; private set; }

        public bool IsComplete { get; private set; } = false;

        private IPrescription? _prescription;

        public IPrescription? Prescription
        {
            get
            {
                this.Wait();

                return this._prescription;
            }
            set
            {
                this._prescription = value;
            }
        }


        public PrescriptionRequest(string id, string[] descriptions)
        {
            this.Id = id;
            this.Descriptions = descriptions;
        }

        public void Complete()
        {
            completionEvent.Set();

            this.IsComplete = true;
        }

        public void Wait()
        {
            completionEvent.Wait();
        }
    }
}