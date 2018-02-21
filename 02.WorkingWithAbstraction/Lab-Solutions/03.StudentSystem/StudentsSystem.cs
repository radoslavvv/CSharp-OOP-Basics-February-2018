using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public void ProcessCommand(string command)
    {
        string[] input = command
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        if (input[0] == "Create")
        {
            string name = input[1];

            if (!this.Repo.ContainsKey(name))
            {
                Student student = new Student()
                {
                    Name = input[1],
                    Age = int.Parse(input[2]),
                    Grade = double.Parse(input[3])
                };

                this.Repo[name] = student;
            }
        }
        else if (input[0] == "Show")
        {
            string name = input[1];

            if (this.Repo.ContainsKey(name))
            {
                Student searchedPerson = this.Repo[name];

                string commentary = "";
                if (searchedPerson.Grade >= 5.00)
                {
                    commentary = "Excellent student.";
                }
                else if (searchedPerson.Grade < 5.00 && searchedPerson.Grade >= 3.50)
                {
                    commentary = "Average student.";
                }
                else
                {
                    commentary = "Very nice person.";
                }

                string result = $"{searchedPerson.Name} is {searchedPerson.Age} years old. {commentary}";
                Console.WriteLine(result);
            }

        }
    }
}

