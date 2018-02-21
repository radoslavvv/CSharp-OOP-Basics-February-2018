using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public string Name
    {
        get => name;

        private set
        {
            if (value == "" || value == " " || value == null)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get => money;

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> Bag
    {
        get => bag;
        private set => bag = value;
    }

    public bool CanAffordProduct(Product product)
    {
        return this.Money - product.Cost > 0;
    }

    public void BuyProduct(Product product)
    {
        this.Money -= product.Cost;
        this.Bag.Add(product);
    }

    public override string ToString()
    {
        if (this.bag.Count != 0)
        {
            return $"{this.Name} - {string.Join(", ", this.Bag.Select(p => p.Name))}";
        }
        else
        {
            return $"{this.Name} - Nothing bought";
        }
    }
}
