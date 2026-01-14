using System;

class ExSeq
{
    // This method divides two numbers
    static int Div(int a, int b)
    {
        // If b = 0, this will throw DivideByZeroException
        return a / b;
    }

    static void Main(string[] args)
    {
        try
        {
            // Calling Div() with 10 and 0 (this will cause an exception)
            int m = Div(10, 0);

            // This line will not execute because exception happens above
            Console.WriteLine(m);
        }
        catch (DivideByZeroException ex)
        {
            // This block runs when we try to divide by 0
            Console.WriteLine("Cannot divide by zero");

            // 'throw;' rethrows the SAME exception again
            // BEST PRACTICE because it keeps the original error details & stack trace
            throw;
        }
        catch (Exception ex)
        {
            // This block runs for any other exception
            Console.WriteLine("General exception occurred");
        }
        finally
        {
            // This block always executes (whether exception happens or not)
            Console.WriteLine("Finally block executed");
        }
    }
}
