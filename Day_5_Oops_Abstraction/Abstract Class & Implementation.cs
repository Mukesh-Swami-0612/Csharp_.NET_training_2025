// Problem: Calculate tax using abstract class

using System;
// Using System namespace to access Console class

// Abstract base class
public abstract class Employee
{
    // Abstract method
    // No body here, only declaration
    // Child classes MUST implement this method
    public abstract int CalculateTax(int salary);
}

// IndianEmployee class inherits from Employee
public class IndianEmployee : Employee
{
    // Providing implementation of abstract method
    public override int CalculateTax(int salary)
    {
        // Indian tax calculation (5%)
        return salary * 5 / 100;
    }
}

// USEmployee class inherits from Employee
public class USEmployee : Employee
{
    // Providing implementation of abstract method
    public override int CalculateTax(int salary)
    {
        // US tax calculation (6%)
        return salary * 6 / 100;
    }
}

// Main program class
class Program
{
    public static void Main()
    {
        // Polymorphism:
        // Base class reference holding different child objects
        Employee e1 = new IndianEmployee();
        Employee e2 = new USEmployee();

        // Runtime polymorphism:
        // Correct CalculateTax() method is called at runtime
        Console.WriteLine(e1.CalculateTax(100000));
        Console.WriteLine(e2.CalculateTax(120000));
    }
}
