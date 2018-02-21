using System;

public class StartUp
{
    public static void Main()
    {
        StudentSystem studentSystem = new StudentSystem();

        string input = Console.ReadLine();
        while (input != "Exit")
        {
            studentSystem.ProcessCommand(input);
            input = Console.ReadLine();
        }
    }
}

