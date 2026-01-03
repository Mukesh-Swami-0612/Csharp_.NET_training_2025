using System;

// Interface
public interface IPrint
{
    void Print();
}

// Class implementing the interface
public class PrintData : IPrint
{
    public void Print()
    {
        Console.WriteLine("Printing the data");
    }
}

// Main class
public class Program
{
    public static void Main(string[] args)
    {
        IPrint p1 = new PrintData(); // Interface reference
        p1.Print();                  // Method call
    }
}
