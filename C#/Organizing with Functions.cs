using System;
using System.Runtime.InteropServices;
class Program
{


    static void Main(string[] args)
    {
        string[] names = new string[100];
        decimal[] prices = new decimal[100];
        int itemCount = 0;
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Items");
            Console.WriteLine("2. View All Items");
            Console.WriteLine("3. Search for an Item");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (itemCount < 100)
                    {
                        Console.Write("Enter item name: ");
                        names[itemCount] = Console.ReadLine();
                        Console.Write("Enter item price: ");
                        prices[itemCount] = decimal.Parse(Console.ReadLine());
                        itemCount++;
                    }
                    else
                    {
                        Console.WriteLine("Item limit reached.");
                    }
                    break;
                case "2":
                    Console.WriteLine("All Items:");
                    for (int i = 0; i < itemCount; i++)
                    {
                        Console.WriteLine($"Item: {names[i]}, Price: {prices[i]:C}");
                    }
                    break;
                case "3":
                    Console.Write("Enter item name to search: ");
                    string searchName = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < itemCount; i++)
                    {
                        if (names[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Item: {names[i]}, Price: {prices[i]:C}");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Item not found.");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}



