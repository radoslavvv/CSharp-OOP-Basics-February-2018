using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string personInfo = Console.ReadLine();
        List<Person> people = new List<Person>();

        List<string> inputLines = new List<string>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] inputParams = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (inputParams.Length == 2)
            {
                inputLines.Add(input);
            }
            else
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string fullName = $"{tokens[0]} {tokens[1]}";
                string birthDay = tokens[2];

                Person currentPerson = new Person()
                {
                    FullName = fullName,
                    BirthDay = birthDay
                };

                people.Add(currentPerson);
            }
            input = Console.ReadLine();
        }

        foreach (string line in inputLines)
        {
            string[] tokens = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            string parent = tokens[0].Trim();
            string child = tokens[1].Trim();

            if (parent.Contains("/"))
            {
                if (child.Contains("/"))
                {
                    Person childPerson = new Person()
                    {
                        BirthDay = child,
                        FullName = people.First(p => p.BirthDay == child).FullName
                    };

                    people.First(p => p.BirthDay == parent).Children.Add(childPerson);
                    people.First(c => c.BirthDay == child).Parents.Add(people.First(p => p.BirthDay == parent));
                }
                else
                {
                    Person childPerson = new Person()
                    {
                        FullName = child,
                        BirthDay = people.First(c => c.FullName == child).BirthDay
                    };

                    people.First(p => p.BirthDay == parent).Children.Add(childPerson);
                    people.First(c => c.FullName == child).Parents.Add(people.First(p => p.BirthDay == parent));
                }
            }
            else
            {
                if (child.Contains("/"))
                {
                    Person childPerson = new Person()
                    {
                        BirthDay = child,
                        FullName = people.First(c => c.BirthDay == child).FullName
                    };

                    people.First(p => p.FullName == parent).Children.Add(childPerson);
                    people.First(c => c.BirthDay == child).Parents.Add(people.First(p => p.FullName == parent));
                }
                else
                {
                    Person childPerson = new Person()
                    {
                        FullName = child,
                        BirthDay = people.First(c => c.FullName == child).BirthDay
                    };

                    people.First(p => p.FullName == parent).Children.Add(childPerson);
                    people.First(c => c.FullName == child).Parents.Add(people.First(p => p.FullName == parent));
                }
            }
        }

        Person result = new Person();
        if (personInfo.Contains("/"))
        {
            result = people.First(p => p.BirthDay == personInfo);
        }
        else
        {
            result = people.First(p => p.FullName == personInfo);
        }

        Console.WriteLine($"{result.FullName} {result.BirthDay}");
        Console.WriteLine($"Parents:");
        foreach (var parent in result.Parents)
        {
            Console.WriteLine($"{parent.FullName} {parent.BirthDay}");
        }
        Console.WriteLine($"Children:");
        foreach (var child in result.Children)
        {
            Console.WriteLine($"{child.FullName} {child.BirthDay}");
        }
    }
}

