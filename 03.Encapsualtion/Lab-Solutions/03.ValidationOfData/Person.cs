using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get => firstName;
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.salary = value;
        }
    }

    public decimal Salary
    {
        get => salary;
        set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:0.00} leva.";
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age < 30)
        {
            this.Salary += (this.Salary * (percentage / 100) / 2);
        }
        else
        {
            this.Salary += this.Salary * (percentage / 100);
        }
    }
}
