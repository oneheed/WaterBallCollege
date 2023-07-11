using PrescriberSystemApp.Models.Prescriptions;

namespace PrescriberSystemApp.Models
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

        internal void Complete()
        {
            completionEvent.Set();

            this.IsComplete = true;
        }

        internal void Wait()
        {
            completionEvent.Wait();
        }
    }
}