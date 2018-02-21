public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public Person()
    {
        
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }
    public int Age
    {
        get => this.age;
        set => this.age = value;
    }
}
