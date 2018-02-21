using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

        string input = Console.ReadLine();
        while (input != "Tournament")
        {
            string[] inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string trainerName = inputParams[0];
            string pokemonName = inputParams[1];
            string pokemonParam = inputParams[2];
            double pokemonHealth = double.Parse(inputParams[3]);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName, new Trainer()
                {
                    Name = trainerName,
                });
            }
            trainers[trainerName].Pokemons.Add(new Pokemon()
            {
                Name = pokemonName,
                Element = pokemonParam,
                Health = pokemonHealth
            });

            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (input != "End")
        {
            foreach (var trainer in trainers.Values)
            {
                if (trainer.ContainsPokemonOfElement(input))
                {
                    trainer.AddBadge(input);
                }
                else
                {
                    trainer.DecreaseAllPokemonsHealth();
                }
            }

            input = Console.ReadLine();
        }
        foreach (var trainer in trainers.OrderByDescending(t=>t.Value.Badges.Count))
        {
            Console.WriteLine(trainer.Value);
        }
    }
}

