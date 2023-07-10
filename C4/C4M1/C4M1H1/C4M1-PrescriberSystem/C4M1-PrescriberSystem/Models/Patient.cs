// Ignore Spelling: BMI

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

        public Patient(string id, string name, Gender gender, int age, double height, double weight)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;

            Height = height;
            Weight = weight;
        }

        public double BMI => this.Weight / Math.Pow(this.Height / 100, 2);

        public List<Case> Case { get; private set; } = new List<Case>();

        public void AddCase(Case @case)
        {
            this.Case.Add(@case);
        }
    }
}