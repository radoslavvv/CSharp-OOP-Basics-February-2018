public class FamilyMember
{
    private string name;
    private string birthday;

    public FamilyMember(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"\r\n{this.Name} {this.Birthday}";
    }

    public string Name { get => name; set => name = value; }
    public string Birthday { get => birthday; set => birthday = value; }
}
