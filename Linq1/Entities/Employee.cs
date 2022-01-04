using System.Globalization;

namespace Linq1.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Sallary { get; set; }

        public Employee(string line)
        {
            string[] vet = line.Split(',');

            Name = vet[0];
            Email = vet[1];
            Sallary = double.Parse(vet[2], CultureInfo.InvariantCulture);
        }
    }
}
