using System;

class DatabaseConnection
{
    static void Main()
    {
        bool isConnected = false;

        try
        {
            // Open connection
            Console.WriteLine("Opening database connection...");
            isConnected = true;

            // Simulate some operation
            Console.WriteLine("Performing database operation...");

            // Simulate failure
            throw new Exception("Database operation failed!");
        }
        catch (Exception ex)
        {
            // Handle error
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Ensure connection is closed
            if (isConnected)
            {
                Console.WriteLine("Closing database connection...");
                isConnected = false;
            }

            Console.WriteLine("Connection closed safely.");
        }

        Console.ReadLine();
    }
}
