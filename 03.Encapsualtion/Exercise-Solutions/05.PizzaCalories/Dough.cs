using System;
using System.Collections.Generic;

public class Dough
{ 
    private string type;
    private string bakingTechnique;
    private double weight;
    private double calories;

    public Dough(string type, string bakingTechnique, double weight)
    {
        this.Type = type;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
        this.Calories = CalculateCalories();
    }

    private string Type
    {
        get => type;
        set
        {
            if (!DoughIsValid(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.type = value;
        }
    }

    private string BakingTechnique
    {
        get => bakingTechnique;
        set
        {
            if (!DoughIsValid(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    private double Weight
    {
        get => weight;
        set
        {
            if (value < 1 || value > 200)
            {
                throw  new ArgumentException("Dough weight should be in the range [1..200].");
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
            { "white", 1.5},
            { "wholegrain", 1},
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
            };


        return (this.Weight * 2) * (modifiers[this.BakingTechnique.ToLower()]) * (modifiers[this.Type.ToLower()]);
    }

    private bool DoughIsValid(string value)
    {
        Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "white", 1.5},
            { "wholegrain", 1},
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        return modifiers.ContainsKey(value.ToLower());
    }
}