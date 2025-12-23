// Problem: Count number of students using static variable

using System;
// Using System namespace to access Console class

// Student class
public class Student
{
    // Static variable
    // This variable is shared by all Student objects
    public static int Count = 0;

    // Instance variable to store student ID
    public int Id;

    // Instance variable to store student Name
    public string Name;

    // Method to display student details
    public void Display()
    {
        // Print student ID and Name
        Console.WriteLine(Id + " " + Name);

        // Increase count whenever Display() is called
        // Static variable remembers value across all objects
        Count++;
    }
}

// Main program class
class Program
{
    // Program execution starts from Main method
    public static void Main()
    {
        // Creating first Student object
        Student s1 = new Student { Id = 1, Name = "A" };

        // Creating second Student object
        Student s2 = new Student { Id = 2, Name = "B" };

        // Calling Display method for first student
        s1.Display();

        // Calling Display method for second student
        s2.Display();

        // Accessing static variable using class name
        // Prints total number of students displayed
        Console.WriteLine("Total Students: " + Student.Count);
    }
}
