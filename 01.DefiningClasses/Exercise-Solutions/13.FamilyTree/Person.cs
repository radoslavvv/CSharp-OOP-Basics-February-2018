using System.Collections.Generic;

public class Person
{
    private string fullName;
    private string birthDay;
    private List<Person> parents;
    private List<Person> children;

    public Person()
    {
        this.parents = new List<Person>();
        this.children = new List<Person>();
    }

    public Person(string fullName, string birthDay, List<Person> parents, List<Person> children)
    {
        this.fullName = fullName;
        this.birthDay = birthDay;
        this.parents = parents;
        this.children = children;
    }

    public string FullName { get => fullName; set => fullName = value; }
    public string BirthDay { get => birthDay; set => birthDay = value; }
    public List<Person> Parents { get => parents; set => parents = value; }
    public List<Person> Children { get => children; set => children = value; }
}
