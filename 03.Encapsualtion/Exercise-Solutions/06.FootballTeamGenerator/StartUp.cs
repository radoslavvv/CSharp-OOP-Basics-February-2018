using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Team> teams = new List<Team>();

        while (input != "END")
        {
            string[] data = input.Split(new char[] { ';' });

            try
            {
                if (data[0] == "Team")
                {
                    Team currentTeam = new Team(data[1]);
                    teams.Add(currentTeam);
                }
                else if (data[0] == "Add")
                {
                    AddPlayer(teams, data);
                }
                else if (data[0] == "Remove")
                {
                    RemovePlayer(teams, data);
                }
                else if (data[0] == "Rating")
                {
                    GetTeamRating(teams, data);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            input = Console.ReadLine();
        }
    }

    private static void GetTeamRating(List<Team> teams, string[] data)
    {
        string teamName = data[1];

        CheckIfTeamExists(teams, data, teamName);

        double rating = 0;
        if (teams.First(t => t.Name == teamName).Players.Any())
        {
            rating = teams.First(t => t.Name == teamName).Rating;
        }

        Console.WriteLine($"{teamName} - {rating}");
    }

    private static void RemovePlayer(List<Team> teams, string[] data)
    {
        string teamName = data[1];
        string playerName = data[2];

        CheckIfTeamExists(teams, data, teamName);

        teams.First(t => t.Name == teamName).RemovePlayer(playerName);
    }

    private static void AddPlayer(List<Team> teams, string[] data)
    {
        string teamName = data[1];
        string playerName = data[2];
        int endurance = int.Parse(data[3]);
        int sprint = int.Parse(data[4]);
        int dribble = int.Parse(data[5]);
        int passing = int.Parse(data[6]);
        int shooting = int.Parse(data[7]);

        CheckIfTeamExists(teams, data, teamName);

        Player currentPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
        teams.First(t => t.Name == teamName).AddPlayer(currentPlayer);
    }

    private static void CheckIfTeamExists(List<Team> teams, string[] data, string teamName)
    {
        if (teams.All(t => t.Name != data[1]))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }
}

