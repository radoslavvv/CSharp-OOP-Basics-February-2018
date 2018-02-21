using System.Collections.Generic;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<FamilyMember> parents;
    private List<FamilyMember> children;
    private List<Pokemon> pokemons;

    public Person()
    {
        this.Parents = new List<FamilyMember>();
        this.Children = new List<FamilyMember>();
        this.Pokemons = new List<Pokemon>();
        this.Car = new Car("", 0);
        this.Company = new Company("", "", 0);
    }

    public override string ToString()
    {
        return $"{this.Name}\r\n" +
             $"Company:{this.Company}\r\n" +
             $"Car:{this.Car}\r\n" +
             $"Pokemon:{string.Join("", this.Pokemons)}\r\n" +
             $"Parents:{string.Join("", this.Parents)}\r\n" +
             $"Children:{string.Join("", this.Children)}";
    }

    public string Name { get => name; set => name = value; }
    public Company Company { get => company; set => company = value; }
    public Car Car { get => car; set => car = value; }
    public List<FamilyMember> Parents { get => parents; set => parents = value; }
    public List<FamilyMember> Children { get => children; set => children = value; }
    public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }
}
