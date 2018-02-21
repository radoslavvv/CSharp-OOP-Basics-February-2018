using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Team currentTeam = new Team("SoftUni");

        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();
            try
            {
                Person person = new Person(data[0],
                    data[1],
                    int.Parse(data[2]),
                    decimal.Parse(data[3]));

                currentTeam.AddPlayer(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine($"First team has {currentTeam.FirstTeam.Count} players.");

        Console.WriteLine($"Reserve team has {currentTeam.ReserveTeam.Count} players.");
    }
}

