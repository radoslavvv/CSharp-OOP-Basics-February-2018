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
        CarManager cm = new CarManager();

        while (input != "Cops Are Here")
        {
            List<string> args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string action = args[0];

            args = args.Skip(1).ToList();
            switch (action)
            {
                case "register":
                    cm.Register(int.Parse(args[0]), args[1], args[2], args[3], int.Parse(args[4]),
                        int.Parse(args[5]), int.Parse(args[6]), int.Parse(args[7]), int.Parse(args[8]));
                    break;
                case "check":
                    Console.WriteLine(cm.Check(int.Parse(args[0])));
                    break;
                case "open":
                    if (args.Count == 6)
                    {
                        cm.Open(int.Parse(args[0]), args[1], int.Parse(args[2]), args[3], int.Parse(args[4]),
                            args[5]);
                    }
                    else
                    {
                        cm.Open(int.Parse(args[0]), args[1], int.Parse(args[2]), args[3], int.Parse(args[4]));
                    }
                    break;
                case "participate":
                    cm.Participate(int.Parse(args[0]), int.Parse(args[1]));
                    break;
                case "start":
                    Console.WriteLine(cm.Start(int.Parse(args[0])));
                    break;
                case "park":
                    cm.Park(int.Parse(args[0]));
                    break;
                case "unpark":
                    cm.Unpark(int.Parse(args[0]));
                    break;
                case "tune":
                    cm.Tune(int.Parse(args[0]), args[1]);
                    break;
            }

            input = Console.ReadLine();
        }
    }
}

