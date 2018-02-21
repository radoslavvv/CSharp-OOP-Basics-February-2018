using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private int rating;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
        this.rating = 0;
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public double Rating
    {
        get { return Math.Round(this.Players.Average(p => p.OverallSkillLevel)); }
    }

    public List<Player> Players
    {
        get => players;
        private set => players = value;
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (this.Players.All(p => p.Name != playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        this.Players.Remove(this.Players.First(p => p.Name == playerName));
    }
}
