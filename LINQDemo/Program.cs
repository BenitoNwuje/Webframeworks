using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQDemo
{

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] personen = {
    new Person("Jan", 60),
    new Person("An", 100),
    new Person("Peter", 15),
    new Person("Hans", 11),
    new Person("Marijke", 40),
    new Person("Judith", 20)
};
            IEnumerable<Person> vijftigPlussers = personen.OrderBy(x => x.Age);
            Console.WriteLine("Personen gerangschikt op leeftijd:");
            foreach (Person persoon in vijftigPlussers)
            {
                Console.WriteLine(persoon.Name);
            }


        }
    }
}
