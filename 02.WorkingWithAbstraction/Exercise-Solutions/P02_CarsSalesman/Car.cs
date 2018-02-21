using System.Linq;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public Car(string[] parameters, Engine engine)
    {
        this.model = parameters[0];
        this.engine = engine;
        this.color = "n/a";
        this.weight = -1;

        if (parameters.Length >= 3)
        {
            if (int.TryParse(parameters[2], out int result))
            {
                this.weight = result;
            }
            else
            {
                this.color = parameters[2];
            }
            if (parameters.Length == 4)
            {
                this.color = parameters[3];
            }
        }
    }
  
    public string Model { get => model; set => model = value; }
    public Engine Engine { get => engine; set => engine = value; }
    public int Weight { get => weight; set => weight = value; }
    public string Color { get => color; set => color = value; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("{0}:\n", this.Model);
        sb.Append(this.Engine);

        if (this.Weight == -1)
        {
            sb.Append("  Weight: n/a\n");
        }
        else
        {
            sb.Append($"  Weight: {this.Weight}\n");
        }
        sb.AppendFormat("  Color: {0}", this.Color);

        return sb.ToString();
    }
}


