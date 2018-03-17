using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        DraftManager dm = new DraftManager();

        string input = Console.ReadLine();
        while (input != "Shutdown")
        {
            List<string> args = input.Split(new char[] { ' ' }, StringSplitOptions.None).ToList();

            string action = args[0];
            ProcessCommand(dm, args, action);

            input = Console.ReadLine();
        }

        Console.WriteLine(dm.ShutDown());
    }

    private static void ProcessCommand(DraftManager dm, List<string> args, string action)
    {
        args = args.Skip(1).ToList();

        try
        {
            switch (action)
            {
                case "RegisterHarvester":
                    Console.WriteLine(dm.RegisterHarvester(args));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(dm.RegisterProvider(args));
                    break;
                case "Day":
                    Console.WriteLine(dm.Day());
                    break;
                case "Mode":
                    Console.WriteLine(dm.Mode(args));
                    break;
                case "Check":
                    Console.WriteLine(dm.Check(args));
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

