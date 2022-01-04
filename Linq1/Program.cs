using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Linq1.Entities;
using System.Globalization;

namespace Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the file path: ");
            string path = Console.ReadLine();

            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    employees.Add(new Employee(sr.ReadLine()));
                }
            }

            Console.Write("Enter base Sallary: ");
            double sallary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Email of those with sallary greater than " + sallary.ToString("F2", CultureInfo.InvariantCulture));

            var r1 = employees.Where(e => e.Sallary > sallary).OrderBy(e => e.Email).Select(e => e.Email);

            foreach (string email in r1)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine();
            Console.Write("Sum of Sallary of thos whose started with M: ");

            var r2 = employees.Where(e => e.Name[0] == 'M').Select(e => e.Sallary).DefaultIfEmpty(0.0).Sum();

            Console.WriteLine(r2.ToString("F2", CultureInfo.InvariantCulture));
        }

    }
}
