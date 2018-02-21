using System;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get => name;

        private set
        {
            if (value == "" || value == " " || value == null)
            {
                throw  new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Cost
    {
        get => cost;

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.cost = value;
        }
    }
}