using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

        string command = Console.ReadLine();
        while (command != "Output")
        {
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string departament = tokens[0];
            string fullName = tokens[1] + tokens[2];
            string patient = tokens[3];

            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool hasEnoughSpace = departments[departament].SelectMany(p => p).Count() < 60;
            if (hasEnoughSpace)
            {
                AddPatient(doctors, departments, departament, fullName, patient);
            }

            command = Console.ReadLine();
        }

        command = Console.ReadLine();
        while (command != "End")
        {
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            PrintPatients(doctors, departments, tokens);

            command = Console.ReadLine();
        }
    }

    private static void PrintPatients(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] tokens)
    {
        if (tokens.Length == 1)
        {
            string department = tokens[0];
            foreach (var patient in departments[department].Where(r => r.Count > 0).SelectMany(p => p))
            {
                Console.WriteLine($"{patient}");
            }
        }
        else if (tokens.Length == 2 && int.TryParse(tokens[1], out int room))
        {
            string department = tokens[0];
            foreach (var patient in departments[department][room - 1].OrderBy(p => p))
            {
                Console.WriteLine($"{patient}");
            }
        }
        else
        {
            string doctorFullName = tokens[0] + tokens[1];
            foreach (var patient in doctors[doctorFullName].OrderBy(p => p))
            {
                Console.WriteLine($"{patient}");
            }
        }
    }

    private static void AddPatient(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string fullName, string patient)
    {
        int roomNumber = 0;
        doctors[fullName].Add(patient);
        for (int room = 0; room < departments[departament].Count; room++)
        {
            if (departments[departament][room].Count < 3)
            {
                roomNumber = room;
                break;
            }
        }
        departments[departament][roomNumber].Add(patient);
    }
}

