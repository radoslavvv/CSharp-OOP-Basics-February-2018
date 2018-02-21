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
            Person currentPerson = new Person(data[0], data[1], int.Parse(data[2]));
            persons.Add(currentPerson);
        }

        persons.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p.ToString()));
    }
}

