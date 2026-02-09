using System;
using System.Runtime.InteropServices;
class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a long string of product tags (e.g., \"electronics, sale, winter\"):");
        string input = Console.ReadLine();
        string[] tags = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Product Tags:");
        foreach (string tag in tags)
        {
            Console.WriteLine(tag.Trim());
        }
        string[] items = { "Laptop", "Smartphone", "Headphones", "Camera" };
        Console.WriteLine("Enter a product name to search:");
        string productName = Console.ReadLine();
        int index = Array.IndexOf(items, productName);
        if (index != -1)
        {
            Console.WriteLine($"Product found at index: {index}");
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }
}



