using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        NationsBuilder nb = new NationsBuilder();

        while (input != "Quit")
        {
            List<string> args = input.Split(new char[] {' '}, StringSplitOptions.None).ToList();

            string action = args[0];

            args = args.Skip(1).ToList();

            switch (action)
            {
                case "Bender":
                    nb.AssignBender(args);
                    break;
                case "Monument":
                    nb.AssignMonument(args);
                    break;
                case "Status":
                    Console.Write(nb.GetStatus(args[0]));
                    break;
                case "War":
                    nb.IssueWar(args[0]);
                    break;
            }
            input = Console.ReadLine();
        }
        Console.Write(nb.GetWarsRecord());

    }
}

