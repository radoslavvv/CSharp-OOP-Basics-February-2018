using System;
using System.Collections.Generic;

public class Topping
{
    private string type;
    private double weight;
    private double calories;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
        this.Calories = CalculateCalories();
    }

    private string Type
    {
        get => type;
        set
        {
            if (!ToppingTypeIsValid(value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    private bool ToppingTypeIsValid(string topping)
    {
        Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9 }
        };

        return modifiers.ContainsKey(topping.ToLower());
    }

    private double Weight
    {
        get => weight;
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double Calories
    {
        get => calories;
        private set => calories = value;
    }

    private double CalculateCalories()
    {
        Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9 }
        };


        return (this.Weight * 2) * (modifiers[this.type.ToLower()]);
    }
}