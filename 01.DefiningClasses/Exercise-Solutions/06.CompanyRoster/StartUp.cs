using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();
        int lineCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < lineCount; i++)
        {
            string[] input = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            string department = input[3];

            Employee currentEmployee = new Employee(input);

            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<Employee>());
            }
            departments[department].Add(currentEmployee);
        }

        var highestPaidDepartment = departments
            .OrderByDescending(d => d.Value.Average(e => e.Salary))
            .First();

        Console.WriteLine($"Highest Average Salary: {highestPaidDepartment.Key}");
        foreach (var employee in highestPaidDepartment.Value.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:0.00} {employee.Email} {employee.Age}");
        }
    }
}

