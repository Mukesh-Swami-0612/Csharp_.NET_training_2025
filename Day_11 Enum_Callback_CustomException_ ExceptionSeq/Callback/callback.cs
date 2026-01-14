using System;

public delegate void CallBack(string message);

public class Program
{
    //Callback method
    public static void ShowMessage(string message)
    {
        Console.WriteLine("Callback called: " + message);
    }

    // Method that takes callback as parameter
    public static void DoWork(CallBack callback)
    {
        Console.WriteLine("Doing some work...");
        callback("Work completed successfully!");
    }

    public static void Main(string[] args)
    {
        // Passing method as callback
        DoWork(ShowMessage);
    }
}
