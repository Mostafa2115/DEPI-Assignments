using System;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of items you want to buy: ");
        int itemCount = int.Parse(Console.ReadLine());
        string[] itemNames = new string[itemCount];
        decimal[] itemPrices = new decimal[itemCount];
        for (int i = 0; i < itemCount; i++)
        {
            Console.Write($"Enter the name of item {i + 1}: ");
            itemNames[i] = Console.ReadLine();
            decimal price;
            do
            {
                Console.Write($"Enter the price of {itemNames[i]}: ");
                price = decimal.Parse(Console.ReadLine());
                if (price < 0)
                {
                    Console.WriteLine("Price cannot be negative. Please enter a valid price.");
                }
            } while (price < 0);
            itemPrices[i] = price;
        }
        Console.WriteLine("\nItems Purchased:");
        Console.WriteLine("Name\t\tPrice");
        for (int i = 0; i < itemCount; i++)
        {
            Console.WriteLine($"{itemNames[i]}\t\t{itemPrices[i]:C}");
        }

    }
}



