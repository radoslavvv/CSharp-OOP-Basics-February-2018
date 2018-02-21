using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();
        string input = Console.ReadLine();
        while (input !="End")
        {
            string[] inputParams = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            string personName = inputParams[0];

            if (!people.ContainsKey(personName))
            {
                people.Add(personName, new Person());
            }

            people[personName].Name = personName;
            if (inputParams.Length == 5)
            {
                people[personName].Company.Name = inputParams[2];
                people[personName].Company.Department = inputParams[3];
                people[personName].Company.Salary = decimal.Parse(inputParams[4]);
            }
            else
            {
                if (inputParams[1] == "car")
                {
                    people[personName].Car.Model = inputParams[2];
                    people[personName].Car.Speed = double.Parse(inputParams[3]);
                }
                else if (inputParams[1] == "children")
                {
                    people[personName].Children.Add(new FamilyMember(inputParams[2], inputParams[3]));
                }
                else if (inputParams[1] == "pokemon")
                {
                    people[personName].Pokemons.Add(new Pokemon(inputParams[2], inputParams[3]));
                }
                else if (inputParams[1] == "parents")
                {
                    people[personName].Parents.Add(new FamilyMember(inputParams[2], inputParams[3]));
                }
            }

            input = Console.ReadLine();
        }
        string personToPrint = Console.ReadLine();

        Console.WriteLine($"{people[personToPrint]}");
    }
}

