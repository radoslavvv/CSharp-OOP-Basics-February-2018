using System;

public class StartUp
{
    public static void Main()
    {
        Family family = new Family();

        int peopleCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person()
            {
                Name = input[0],
                Age = int.Parse(input[1])
            };

            family.AddMember(currentPerson);
        }
        Console.WriteLine(family.GetOldestMember());
    }
}

