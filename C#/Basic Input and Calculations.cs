using System;
using System.Runtime.InteropServices;
class Program
{
    

    static void DisplayReceipt(string productName, decimal price , int quantity)
    {
        decimal totalBeforeTaxInt = price * quantity;
        decimal taxAmount = totalBeforeTaxInt * 0.14m;
        decimal finalTotal = totalBeforeTaxInt + taxAmount;
        Console.WriteLine("Receipt:");
        Console.WriteLine($"Product Name: {productName}");
        Console.WriteLine($"Total Before Tax: {totalBeforeTaxInt:C}");
        Console.WriteLine($"Tax Amount (14% VAT): {taxAmount:C}");
        Console.WriteLine($"Final Total: {finalTotal:C}");
        if (finalTotal > 1000)
            Console.WriteLine("You are a VIP Customer!");
        else
            Console.WriteLine("Thank you for shopping!");
    }
    static void Main(string[] args)
    {
        DisplayReceipt("Sample Product", 200m, 50);
    }
}



