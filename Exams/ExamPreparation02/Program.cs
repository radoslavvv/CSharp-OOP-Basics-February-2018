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
        Manager m = new Manager();

        while (input != "Paw Paw Pawah")
        {
            List<string> args = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string action = args[0];

            args = args.Skip(1).ToList();

            switch (action)
            {
                case "RegisterAdoptionCenter":
                    m.RegisterAdoptionCenter(args[0]);
                    break;
                case "RegisterCleansingCenter":
                    m.RegisterCleansingCenter(args[0]);
                    break;
                case "RegisterDog":
                    m.RegisterDog(args);
                    break;
                case "RegisterCat":
                    m.RegisterCat(args);
                    break;
                case "SendForCleansing":
                    m.SendForCleansing(args[0], args[1]);
                    break;
                case "Cleanse":
                    m.Cleanse(args[0]);
                    break;
                case "Adopt":
                    m.Adopt(args[0]);
                    break;
            }
            input = Console.ReadLine();

        }
        m.Terminate();
    }
}

