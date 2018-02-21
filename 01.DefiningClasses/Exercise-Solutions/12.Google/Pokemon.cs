public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return $"\r\n{this.Name} {this.Type}";
    }

    public string Name { get => name; set => name = value; }
    public string Type { get => type; set => type = value; }
}