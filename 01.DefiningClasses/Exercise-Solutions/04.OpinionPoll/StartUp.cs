using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        int peopleCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person()
            {
                Name = input[0],
                Age = int.Parse(input[1])
            };

            people.Add(currentPerson);
        }
        foreach (var person in people.Where(p=>p.Age >30).OrderBy(p=>p.Name))
        {
            Console.WriteLine(person);
        }
    }
}

