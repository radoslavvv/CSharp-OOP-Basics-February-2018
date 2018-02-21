public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee()
    {
        this.email = "n/a";
        this.age = -1;
    }

    public Employee(string[] input)
        : this()
    {
        this.name = input[0];
        this.salary = decimal.Parse(input[1]);
        this.position = input[2];
        this.department = input[3];

        if (input.Length > 4)
        {
            for (int j = 4; j < input.Length; j++)
            {
                if (input[j].Contains("@"))
                {
                    this.email = input[j];
                }
                else
                {
                    this.age = int.Parse(input[j]);
                }
            }
        }
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public decimal Salary
    {
        get => this.salary;
        set => this.salary = value;
    }

    public string Position
    {
        get => this.position;
        set => this.position = value;
    }

    public string Department
    {
        get => this.department;
        set => this.department = value;
    }

    public string Email
    {
        get => this.email;
        set => this.email = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }
}
