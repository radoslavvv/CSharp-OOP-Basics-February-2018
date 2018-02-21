using System;

public class StartUp
{
    public static void Main()
    {
        Person firstPerson = new Person();
        firstPerson.Name = "Pesho";
        firstPerson.Age = 18;

        Person secondPerson = new Person("Gosho", 21);
    }
}
