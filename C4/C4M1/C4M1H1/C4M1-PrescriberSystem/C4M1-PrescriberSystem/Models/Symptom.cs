namespace C4M1_PrescriberSystem.Models
{
    internal class Symptom
    {
        public List<string> Descriptions { get; private set; } = new List<string>();

        public Symptom(params string[] descriptions)
        {
            Descriptions.AddRange(descriptions);
        }

        public bool Match(Symptom symptom)
        {
            return symptom.Descriptions.All(d => this.Descriptions.Contains(d));
        }
    }
}