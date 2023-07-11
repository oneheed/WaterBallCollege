// Ignore Spelling: BMI

using System.Text.Json.Serialization;
using C4M1_PrescriberSystem.Enums;

namespace C4M1_PrescriberSystem.Models
{
    internal class Patient
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public Gender Gender { get; private set; }

        public int Age { get; private set; }

        public double Height { get; private set; }

        public double Weight { get; private set; }

        [JsonConstructor]
        public Patient(string id, string name, Gender gender, int age, double height, double weight, List<Case> cases)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;

            Height = height;
            Weight = weight;

            Cases = cases ?? new List<Case>();
        }

        [JsonIgnore]
        public double BMI => this.Weight / Math.Pow(this.Height / 100, 2);

        public List<Case> Cases { get; private set; } = new List<Case>();
    }
}