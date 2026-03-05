
using System;

class Controller
{
    static void Main()
    {
        try
        {
            // Call Service method
            Service.Process();
        }
        catch (Exception ex)
        {
            // Handle exception here (Top layer)
            Console.WriteLine("Controller handled: " + ex.Message);
        }

        Console.ReadLine(); // Keep console open
    }
}

class Service
{
    public static void Process()
    {
        try
        {
            // Call Repository method
            Repository.GetData();
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine("Service logged: " + ex.Message);

            // Rethrow exception
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // Throw an exception here (Bottom layer)
        throw new Exception("Error: Database connection failed!");
    }
}
