﻿public class Person
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

    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public int Age { get => age; set => age = value; }
    public decimal Salary { get => salary; set => salary = value; }

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
