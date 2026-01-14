using System;

// Step 1: Create delegate
delegate void Print(string msg);

class Program
{
    // Step 2: Method 1 (Matches delegate signature)
    static void Hello(string msg)
    {
        Console.WriteLine("Hello: " + msg);
    }

    // Step 3: Method 2 (Also matches delegate signature)
    static void Bye(string msg)
    {
        Console.WriteLine("Hii: " + msg);
    }

    static void Main()
    {
        // Step 4: Assign first method to delegate
        Print p = Hello;

        // Step 5: Add another method using +=
        // This makes it a multicast delegate (calls multiple methods)
        p += Bye;

        // Step 6: Call delegate (Both methods will run)
        p("Mukesh");
    }
}
