using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();
            Person person = new Person(data[0],
                data[1],
                int.Parse(data[2]),
                decimal.Parse(data[3]));

            persons.Add(person);
        }
        decimal bonus = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(bonus));
        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
}

