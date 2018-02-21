using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private string name;
    private int number;
    private List<string> badges;
    private List<Pokemon> pokemons;

    public Trainer()
    {
        this.badges = new List<string>();
        this.pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Number
    {
        get => number;
        set => number = value;
    }

    public List<string> Badges
    {
        get => badges;
        set => badges = value;
    }

    public List<Pokemon> Pokemons
    {
        get => pokemons;
        set => pokemons = value;
    }

    public bool ContainsPokemonOfElement(string pokemonElement)
    {
        return this.Pokemons.Any(p => p.Element == pokemonElement);
    }

    public void AddBadge(string type)
    {
        switch (type)
        {
            case "Fire":
                this.Badges.Add("Fire");
                break;
            case "Water":
                this.Badges.Add("Water");
                break;
            case "Electricity":
                this.Badges.Add("Electricity");
                break;
        }
    }

    public void DecreaseAllPokemonsHealth()
    {
        for (int i = 0; i < this.Pokemons.Count; i++)
        {
            this.Pokemons[i].Health -= 10;
            if (this.Pokemons[i].Health <= 0)
            {
                this.Pokemons.RemoveAt(i);
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Badges.Count} {this.Pokemons.Count}";
    }
}
