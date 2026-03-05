using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            // Handle final exception
            Console.WriteLine("Main caught: " + ex.Message);
        }

        Console.ReadLine();
    }

    static void ProcessData()
    {
        try
        {
            // This will cause error
            int.Parse("ABC");
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine("ProcessData logged: " + ex.Message);

            // Rethrow while preserving stack trace
            throw;
        }
    }
}
