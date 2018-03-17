using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Manager
{
    private Dictionary<string, CleansingCenter> cleansingCenters = new Dictionary<string, CleansingCenter>();
    private Dictionary<string, AdoptionCenter> adoptionCenters = new Dictionary<string, AdoptionCenter>();

    List<string> adoptedAnimals = new List<string>();
    List<string> cleansedAnimals = new List<string>();

    public void RegisterCleansingCenter(string name)
    {
        CleansingCenter cc = new CleansingCenter(name);

        cleansingCenters.Add(name, cc);
    }

    public void RegisterAdoptionCenter(string name)
    {
        AdoptionCenter ac = new AdoptionCenter(name);

        adoptionCenters.Add(name, ac);
    }

    public void RegisterDog(List<string> args)
    {
        string name = args[0];
        int age = int.Parse(args[1]);
        int learnedCommands = int.Parse(args[2]);
        string adoptionCenterName = args[3];

        Dog dog = new Dog(name, age, learnedCommands, adoptionCenterName);
        adoptionCenters[adoptionCenterName].Animals.Add(dog);
    }

    public void RegisterCat(List<string> args)
    {
        string name = args[0];
        int age = int.Parse(args[1]);
        int intelligenceCoefficient = int.Parse(args[2]);
        string adoptionCenterName = args[3];

        Cat cat = new Cat(name, age, intelligenceCoefficient, adoptionCenterName);
        adoptionCenters[adoptionCenterName].Animals.Add(cat);
    }

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        foreach (var animal in adoptionCenters[adoptionCenterName].Animals.Where(a => a.CleansingStatus == "UNCLEANSED"))
        {
            cleansingCenters[cleansingCenterName].Animals.Add(animal);
        }

        adoptionCenters[adoptionCenterName].Animals.
            RemoveAll(a => a.CleansingStatus == "UNCLEANSED");
    }

    public void Cleanse(string cleansingCenterName)
    {
        foreach (var animal in cleansingCenters[cleansingCenterName].Animals)
        {
            animal.CleansingStatus = "CLEANSED";

            adoptionCenters[animal.AdoptionCenter].Animals.Add(animal);
            cleansedAnimals.Add(animal.Name);
        }

        cleansingCenters[cleansingCenterName].Animals.Clear();
    }

    public void Adopt(string adoptionCenterName)
    {
        adoptionCenters[adoptionCenterName]
            .Animals.Where(a => a.CleansingStatus == "CLEANSED").ToList()
            .ForEach(a => adoptedAnimals.Add(a.Name));

        adoptionCenters[adoptionCenterName].Animals.RemoveAll(a => a.CleansingStatus == "CLEANSED");
    }

    public void Terminate()
    {
        Console.WriteLine($"Paw Incorporative Regular Statistics\r\n" +
                          $"Adoption Centers: {adoptionCenters.Count}\r\n" +
                          $"Cleansing Centers: {cleansingCenters.Count}");
        Console.WriteLine(adoptedAnimals.Count == 0
            ? $"Adopted Animals: None"
            : $"Adopted Animals: {string.Join(", ", adoptedAnimals.OrderBy(a => a))}");
        Console.WriteLine(cleansedAnimals.Count == 0
            ? $"Cleansed Animals: None"
            : $"Cleansed Animals: {string.Join(", ", cleansedAnimals.OrderBy(a => a))}");
        Console.WriteLine($"Animals Awaiting Adoption: {adoptionCenters.Sum(ac => ac.Value.Animals.Count(a => a.CleansingStatus == "CLEANSED"))}\r\n" +
                          $"Animals Awaiting Cleansing: {cleansingCenters.Sum(c => c.Value.Animals.Count)}");

    }
}

