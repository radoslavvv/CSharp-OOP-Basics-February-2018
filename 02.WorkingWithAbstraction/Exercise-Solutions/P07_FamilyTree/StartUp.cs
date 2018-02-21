using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> familyTree = new List<Person>();
        string personInput = Console.ReadLine();

        Person mainPerson = new Person();
        if (IsBirthday(personInput))
        {
            mainPerson.Birthday = personInput;
        }
        else
        {
            mainPerson.Name = personInput;
        }

        familyTree.Add(mainPerson);

        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] tokens = command.Split(" - ");
            if (tokens.Length > 1)
            {
                string parent = tokens[0];
                string child = tokens[1];

                Person currentPerson = GetCurrentPersonInfo(familyTree, parent);

                SetChild(familyTree, currentPerson, child);
            }
            else
            {
                string[] input = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = $"{input[0]} {input[1]}";
                string birthday = input[2];

                Person person = FindPersonInfo(familyTree, name, birthday);

                AddPersonToFamilyTree(familyTree, name, birthday, person);
            }
            command = Console.ReadLine();
        }

        PrintResult(mainPerson);
    }

    private static void AddPersonToFamilyTree(List<Person> familyTree, string name, string birthday, Person person)
    {
        int index = familyTree.IndexOf(person) + 1;
        int count = familyTree.Count - index;

        Person[] copy = new Person[count];
        familyTree.CopyTo(index, copy, 0, count);

        Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

        if (copyPerson != null)
        {
            familyTree.Remove(copyPerson);
            person.Parents.AddRange(copyPerson.Parents);
            person.Parents = person.Parents.Distinct().ToList();

            person.Children.AddRange(copyPerson.Children);
            person.Children = person.Children.Distinct().ToList();
        }
    }

    private static Person FindPersonInfo(List<Person> familyTree, string name, string birthday)
    {
        Person person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
        if (person == null)
        {
            person = new Person();
            familyTree.Add(person);
        }
        person.Name = name;
        person.Birthday = birthday;
        return person;
    }

    private static Person GetCurrentPersonInfo(List<Person> familyTree, string firstPerson)
    {
        Person currentPerson;
        if (IsBirthday(firstPerson))
        {
            currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

            if (currentPerson == null)
            {
                currentPerson = new Person
                {
                    Birthday = firstPerson
                };
                familyTree.Add(currentPerson);
            }
        }
        else
        {
            currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

            if (currentPerson == null)
            {
                currentPerson = new Person
                {
                    Name = firstPerson
                };
                familyTree.Add(currentPerson);
            }
        }

        return currentPerson;
    }

    private static void PrintResult(Person mainPerson)
    {
        Console.WriteLine(mainPerson);
        Console.WriteLine("Parents:");
        foreach (var p in mainPerson.Parents)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine("Children:");
        foreach (var c in mainPerson.Children)
        {
            Console.WriteLine(c);
        }
    }

    private static void SetChild(List<Person> familyTree, Person parentPerson, string childInfo)
    {
        Person childPerson = new Person();

        if (IsBirthday(childInfo))
        {
            if (familyTree.All(p => p.Birthday != childInfo))
            {
                childPerson.Birthday = childInfo;
            }
            else
            {
                childPerson = familyTree.First(p => p.Birthday == childInfo);
            }
        }
        else
        {
            if (familyTree.All(p => p.Name != childInfo))
            {
                childPerson.Name = childInfo;
            }
            else
            {
                childPerson = familyTree.First(p => p.Name == childInfo);
            }
        }

        parentPerson.Children.Add(childPerson);
        childPerson.Parents.Add(parentPerson);

        familyTree.Add(childPerson);
    }

    static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }
}
