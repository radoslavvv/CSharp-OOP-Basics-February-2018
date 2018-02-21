using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public string Name
    {
        get => name;
         set
        {
            if (value.Length > 15 || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        get => dough;
        set => dough = value;
    }

    private List<Topping> Toppings
    {
        get => toppings;
        set
        {
            if (value.Count > 10 || value.Count < 0)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings = value;
        }
    }

    
    public int NumberOfToppings
    {
        get { return this.Toppings.Count; }
    }
    public double TotalCalories
    {
        get { return this.CalculateTotalCalories(); }
    }

    private double CalculateTotalCalories()
    {
        return this.Toppings.Sum(t => t.Calories) + this.Dough.Calories;
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}
