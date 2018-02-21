using System;
using System.Collections.Generic;
using System.Linq;

public class Potato
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();

        for (int i = 0; i < input.Length; i += 2)
        {
            string itemName = input[i];
            long itemAmount = long.Parse(input[i + 1]);

            string itemType = GetItemType(itemName);

            if (BagIsTooHeavy(bagCapacity, bag, itemAmount) ||
               (itemType != "Gold" && !ItemCanBeAdded(bag, itemType, itemAmount)))
            {
                continue;
            }
            AddItemToBag(bag, itemName, itemAmount, itemType);
        }
        PrintResult(bag);
    }

    private static bool BagIsTooHeavy(long bagCapacity, Dictionary<string, Dictionary<string, long>> bag, long itemAmount)
    {
        return bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + itemAmount;
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var itemType in bag)
        {
            Console.WriteLine($"<{itemType.Key}> ${itemType.Value.Values.Sum()}");
            foreach (var item in itemType.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }

    private static void AddItemToBag(Dictionary<string, Dictionary<string, long>> bag, string itemName, long itemAmount, string itemType)
    {
        if (!bag.ContainsKey(itemType))
        {
            bag[itemType] = new Dictionary<string, long>();
        }

        if (!bag[itemType].ContainsKey(itemName))
        {
            bag[itemType][itemName] = 0;
        }
        bag[itemType][itemName] += itemAmount;
    }

    private static string GetItemType(string itemName)
    {
        string itemType = "";
        if (itemName.Length == 3)
        {
            itemType = "Cash";
        }
        else if (itemName.ToLower().EndsWith("gem"))
        {
            itemType = "Gem";
        }
        else if (itemName.ToLower() == "gold")
        {
            itemType = "Gold";
        }

        return itemType;
    }

    private static bool ItemCanBeAdded(Dictionary<string, Dictionary<string, long>> bag, string itemType, long itemAmount)
    {
        string biggerItem = "";
        if (itemType == "Cash")
        {
            biggerItem = "Gem";
        }
        else if (itemType == "Gem")
        {
            biggerItem = "Gold";
        }

        if (!bag.ContainsKey(itemType))
        {
            if (bag.ContainsKey(biggerItem))
            {
                if (itemAmount > bag[biggerItem].Values.Sum())
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (bag[itemType].Values.Sum() + itemAmount > bag[biggerItem].Values.Sum())
        {
            return false;
        }

        return true;
    }
}
