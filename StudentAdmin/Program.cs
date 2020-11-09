using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Quentin", LastName = "Vanhoutte", Grade = 77},
                new Student { FirstName = "Brian", LastName = "Leroy", Grade = 55},
                new Student { FirstName = "Chiara", LastName = "Vancluysen", Grade = 80},
                new Student { FirstName = "Bavo", LastName = "Van Daele", Grade = 30},
                new Student { FirstName = "Timothy", LastName = "Borremans", Grade = 60},
                new Student { FirstName = "Lisa", LastName = "Peeters", Grade = 75},
                new Student { FirstName = "Lenny", LastName = "Louage", Grade = 45},
                new Student { FirstName = "Ayoub", LastName = "Edris", Grade = 90},
                new Student { FirstName = "Jeroen", LastName = "Callens", Grade = 60},
                new Student { FirstName = "Anke", LastName = "De Smedt", Grade = 70},
                new Student { FirstName = "Hans", LastName = "Leroy", Grade = 55},
                new Student { FirstName = "Arnaud", LastName = "Blindeman", Grade = 88},
                new Student { FirstName = "Brian", LastName = "Dujardin", Grade = 45},
                new Student { FirstName = "Perrine", LastName = "Desmet", Grade = 50},
                new Student { FirstName = "Abdullah", LastName = "Taslim", Grade = 70},
                new Student { FirstName = "Zaira", LastName = "Akman", Grade = 55}
};
            IEnumerable<Student> geslaagdeStudent = students.Where(x => x.Grade >= 50).OrderBy(x => x.Grade);
            Console.WriteLine("Geslaagden:");
            foreach (Student student in geslaagdeStudent)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Grade}");
            }
            IEnumerable<Student> nietGeslaagdeStudent = students.Where(x => x.Grade < 50).OrderBy(x => x.Grade);
            Console.WriteLine();
            Console.WriteLine("Niet Geslaagden:");
            foreach (Student student in nietGeslaagdeStudent)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Grade}");
            }
            IEnumerable<Student> TopStudent = students.Where(x => x.Grade >= 50).OrderByDescending(x => x.Grade).Take(3);

            Console.WriteLine();
            Console.WriteLine("Top 3:");
            foreach (Student student in TopStudent)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Grade}");
            }

            IEnumerable<Student> BesteStudent = students.Where(x => x.Grade >= 50).OrderByDescending(x => x.Grade).Take(1);

            Console.WriteLine();
            Console.WriteLine("Beste Student:");
            foreach (Student student in BesteStudent)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Grade}");
            }
            Console.WriteLine();
            IEnumerable<double> getallenInArray = students.Select(x => (double)x.Grade / 10).ToArray();
            Console.WriteLine("Overzicht punten op 10:");
            foreach (var item in getallenInArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Gemiddelde:");
            IEnumerable<int> getallen = students.Select(x => x.Grade);
            Console.WriteLine((double)getallen.Aggregate((prev, curr) => prev + curr) / getallen.Count());

            Console.WriteLine();
            Console.WriteLine("Alle Studenten:");
            Console.WriteLine(students.Select(p => p.FirstName).Aggregate((prev, curr) => prev + "," + curr));


        }
    }
}
