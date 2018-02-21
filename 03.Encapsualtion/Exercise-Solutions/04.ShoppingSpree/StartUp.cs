using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        try
        {
            string[] peopleInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInput.Length; i += 2)
            {
                Person currentPerson = new Person(peopleInput[i], decimal.Parse(peopleInput[i + 1]));
                people.Add(currentPerson);
            }
            for (int i = 0; i < productsInput.Length; i += 2)
            {
                Product currentProduct = new Product(productsInput[i], decimal.Parse(productsInput[i + 1]));
                products.Add(currentProduct);
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Person person = people.First(p => p.Name == inputParams[0]);
                Product product = products.First(p => p.Name == inputParams[1]);

                if (person.CanAffordProduct(product))
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

