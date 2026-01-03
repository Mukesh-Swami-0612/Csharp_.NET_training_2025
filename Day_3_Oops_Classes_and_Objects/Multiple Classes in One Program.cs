// Problem: Demonstrate multiple classes in a single program

using System; 
// Using System namespace to access Console class and basic .NET features

// Employee class
public class Emp
{
    // Public field to store employee ID
    public int Id;

    // Public field to store employee Name
    public string Name;

    // Method to display employee details
    public void Display()
    {
        Console.WriteLine(Id + " " + Name);
        // Prints employee ID and Name on console
    }
}

// Company class
public class Company
{
    // Public field to store company ID
    public int CompanyId;

    // Public field to store company name
    public string CompanyName;

    // Method to display company details
    public void Display()
    {
        Console.WriteLine(CompanyId + " " + CompanyName);
        // Prints company ID and company name
    }
}

// Part class
public class Part
{
    // Public field to store part ID
    public int PartId;

    // Public field to store number of parts
    public int PartCount;

    // Method to display part details
    public void Display()
    {
        Console.WriteLine(PartId + " " + PartCount);
        // Prints part ID and part count
    }
}

// Main program class
class Program
{
    // Main method: program execution starts from here
    public static void Main()
    {
        // Creating object of Emp class and assigning values using object initializer
        Emp e = new Emp { Id = 1, Name = "Mukesh" };

        // Creating object of Company class
        Company c = new Company { CompanyId = 101, CompanyName = "ITTech" };

        // Creating object of Part class
        Part p = new Part { PartId = 11, PartCount = 5 };

        // Calling Display method of Emp class
        e.Display();

        // Calling Display method of Company class
        c.Display();

        // Calling Display method of Part class
        p.Display();
    }
}
