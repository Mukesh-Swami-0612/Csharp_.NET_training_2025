
using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        foreach (int orderId in orders)
        {
            try
            {
                // Process each order
                ProcessOrder(orderId);
            }
            catch (Exception ex)
            {
                // Handle error for this order only
                Console.WriteLine("Failed to process order " + orderId + ": " + ex.Message);
            }
        }

        Console.WriteLine("All orders processed.");
        Console.ReadLine();
    }

    static void ProcessOrder(int orderId)
    {
        // Throw exception for invalid order ID
        if (orderId <= 0)
        {
            throw new Exception("Invalid Order ID");
        }

        // Simulate order processing
        Console.WriteLine("Order " + orderId + " processed successfully.");
    }
}
